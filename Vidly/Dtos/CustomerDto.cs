using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        // 
        //we can customize the displayed message
        //[Required(ErrorMessage ="Please enter customer's name.")]
        [Required] //default message
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        //exclude because is dependancy domain
        //public MembershipType MembershipType { get; set; }
      //  [Display(Name = "Membership Type")]
        //implicitly required because byte not ?byte
        //entity framework recognizes this convention and treats
        //this property as a foreign key 
        public Byte MembershipTypeId { get; set; }
    //because is for the form    [Display(Name = "Date of Birth")]
   //     [Min18YearsIfAMember] because the control is on customer
   //and with automaper the customertdo is affected on customer
        public DateTime? Birthdate { get; set; }
    }
}