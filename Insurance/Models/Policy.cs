using Insurance.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Insurance.Models;

public partial class Policy
{
    public int PolicyNumber { get; set; }

    [Required(ErrorMessage ="Customer First Name is required.")]
    [MinLength(2)]
    public string CustomerFirstName { get; set; } = null!;

    [Required(ErrorMessage = "Customer Last Name is required.")]
    [MinLength(2)]
    public string CustomerLastName { get; set; } = null!;

    [Required(ErrorMessage = "Customer Email is required.")]
    [DisplayName("Email")]
    public string CustomerEmail { get; set; } = null!;

    public bool HomeInsurance { get; set; } = false;

    public bool CarInsurance { get; set; } = false;

    public bool LifeInsurance { get; set; } = false;

    [RequiredIfAttribute("HomeInsurance", true)]
    [Display(Name = "Home Coverage")]
    public string? Coverage { get; set; }

    [RequiredIfAttribute("HomeInsurance", true)]
    [Display(Name = "Monthly Payment")]
    public decimal? MonthlyPayment { get; set; }

    [RequiredIfAttribute("HomeInsurance", true)]
    [Display(Name = "Start Date")]
    public DateTime? StartDate { get; set; }

    [RequiredIfAttribute("HomeInsurance", true)]
    [Display(Name = "End Date")]
    public DateTime? EndDate { get; set; }

    [RequiredIfAttribute("HomeInsurance", true)]
    [Display(Name = "Home Address")]
    public string? HomeAddress { get; set; }

    [RequiredIfAttribute("HomeInsurance", true)]
    [Display(Name = "House Area")]
    public string? HouseArea { get; set; }

    [RequiredIfAttribute("HomeInsurance", true)]
    [Display(Name = "Number of Bedrooms")]
    public int? NumberofBedrooms { get; set; }

    [RequiredIfAttribute("HomeInsurance", true)]
    [Display(Name = "Number of Bathrooms")]
    public int? NumberofBathrooms { get; set; }

    [RequiredIfAttribute("HomeInsurance", true)]
    [Display(Name = "House Price")]
    public decimal? HousePrice { get; set; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public int? Year { get; set; }

    public string? Vin { get; set; }

    public int? MileagePerYear { get; set; }

    public string? ExistingConditions { get; set; }

    public string? Beneficiary { get; set; }
}
