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

        // GET: Loan/Loan
        public IActionResult Loan(int id)
        {
            // Load the loan details based on the id
            var model = new Loan
            {
                Borrower = id
                // Load other details
            };
            return View(model); // It will now automatically look for Views/Loan/Loan.cshtml
        }

        // GET: Loan/AddLoan
        public IActionResult AddLoan(int id)
        {
            var model = new Loan
            {
                Borrower = id
            };
            return View(model); // It will now automatically look for Views/Loan/AddLoan.cshtml
        }

        // POST: Loan/AddLoan
        [HttpPost]
        public IActionResult AddLoan(Loan model)
        {
            if (ModelState.IsValid)
            {
                // Save the loan details to the database here

                return RedirectToAction("Loan", "Client", new { id = model.Borrower });
            }
            return View(model); // It will now automatically look for Views/Loan/AddLoan.cshtml
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

        // GET: Loan/Loan/5
        // public async Task<IActionResult> Loan(int id)
        // {
        //     var loans = await _context.Loans.Where(l => l.Borrower == id).ToListAsync();
        //     if (loans == null || !loans.Any())
        //     {
        //         return NotFound();
        //     }
        //     ViewBag.ClientName = (await _context.ClientInfos.FindAsync(id))?.FirstName;
        //     return View(loans);
        // }

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
