using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            //we add customer.membershiptypeid==0 because if the user 
            //dont select a membershypetype we dont have to display
            //a validation message about birthdate.
            //0 is for null and  1 is for
            if (customer.MembershipTypeId == MembershipType.Unknown ||customer.MembershipTypeId ==MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required");
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age >= 18) ? ValidationResult.Success 
            :new ValidationResult("Customer should be at least 18 years old to go on a membership.");
        }
    }
}