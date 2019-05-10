using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATManager
{
    public class CustomValidation
    {
        public sealed class checkCountry : ValidationAttribute
        {
            public String AllowCountry { get; set; }
            protected override ValidationResult IsValid(object test, ValidationContext validationContext)
            {
                string[] myarr = AllowCountry.ToString().Split(',');
                if (myarr.Contains(test))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Please choose a valid country eg.(India,Pakistan,Nepal");
                }
            }
        }
    }
}