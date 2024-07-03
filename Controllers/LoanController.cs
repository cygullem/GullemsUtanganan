using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GULLEM_NEW_MVC.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GULLEM_NEW_MVC.Controllers
{
    public class LoanController : Controller
    {
        private readonly GullemsUtangananContext _context;

        public LoanController(GullemsUtangananContext context)
        {
            _context = context;
        }



        // GET: Loan/UserLoans
        public async Task<IActionResult> UserLoans(int id)
        {
            var clientInfo = await _context.ClientInfos
                                            .Include(c => c.Loans)
                                            .FirstOrDefaultAsync(c => c.Id == id);

            if (clientInfo == null)
            {
                return NotFound();
            }

            return View(clientInfo);
        }

    
    
        // GET: Loan/AddLoan
        public IActionResult AddLoan(int clientId)
        {
            var loan = new Loan
            {
                Borrower = clientId
            };

            return View(loan);
        }



        // POST: Loan/AddLoan
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLoan(Loan model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.DueDate = CalculateDueDate(model); 
                    model.DateCreated = DateTime.Now; 

                    _context.Add(model);
                    await _context.SaveChangesAsync();
                    
                    return RedirectToAction("UserLoans", "Loan", new { id = model.Borrower });
                }
                catch (DbUpdateException ex)
                {
                    var innerException = ex.InnerException;
                    while (innerException != null)
                    {
                        Console.WriteLine(innerException.Message);
                        innerException = innerException.InnerException;
                    }
                    throw; // Rethrow the exception or handle as needed
                }
            }
            return View(model); 
}



        private DateTime CalculateDueDate(Loan loan)
        {
            DateTime dueDate = DateTime.Now;
            switch (loan.Payment)
            {
                case "Daily":
                    dueDate = dueDate.AddDays(loan.Term);
                    break;
                case "Weekly":
                    dueDate = dueDate.AddDays(loan.Term * 7);
                    break;
                case "Bi-Monthly":
                    dueDate = dueDate.AddMonths(loan.Term * 2);
                    break;
                case "Monthly":
                    dueDate = dueDate.AddMonths(loan.Term);
                    break;
                case "Yearly":
                    dueDate = dueDate.AddYears(loan.Term / 12);
                    break;
                default:
                    break;
            }
            return dueDate;
        }



        // GET: Loan/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var loan = await _context.Loans.FirstOrDefaultAsync(m => m.Id == id);
            if (loan == null)
            {
                return NotFound();
            }
            return View(loan);
        }



        // GET: Loan/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var loan = await _context.Loans.FirstOrDefaultAsync(m => m.Id == id);
            if (loan == null)
            {
                return NotFound();
            }
            return View(loan);
        }



        // POST: Loan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            if (loan != null)
            {
                _context.Loans.Remove(loan);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index), "Client");
        }
    }
}
