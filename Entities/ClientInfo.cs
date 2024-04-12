using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace GULLEM_NEW_MVC.Entities;


public partial class ClientInfo
{
    public int Id { get; set; }

    public int? UerType { get; set; }

    [Required(ErrorMessage = "First name is required")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Middle name is required")]
    public string? MiddleName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Address is required")]
    public string? Address { get; set; }

    [Required(ErrorMessage = "ZipCode is required")]
    public int? ZipCode { get; set; }

    [Required(ErrorMessage = "Birthday is required")]
    public DateTime? Birthday { get; set; }

    public int? Age { get; set; }

    [Required(ErrorMessage = "Father's name is required")]
    public string? NameOfFather { get; set; }

    [Required(ErrorMessage = "Mother's name is required")]
    public string? NameOfMother { get; set; }

    [Required(ErrorMessage = "Civil Status is required")]
    public string? CivilStatus { get; set; }

    [Required(ErrorMessage = "Religion is required")]
    public string? Religion { get; set; }

    [Required(ErrorMessage = "Occupation is required")]
    public string? Occupation { get; set; }
}
