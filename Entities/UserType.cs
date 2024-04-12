using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GULLEM_NEW_MVC.Entities;

public partial class UserType
{
    public int Id { get; set; }

    [Required(ErrorMessage =  "User Type name is required")]
    public string? Name { get; set; }
}
