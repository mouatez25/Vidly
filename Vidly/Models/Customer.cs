﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        // 
        //we can customize the displayed message
        //[Required(ErrorMessage ="Please enter customer's name.")]
        [Required] //default message
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        //implicitly required because byte not ?byte
        //entity framework recognizes this convention and treats
        //this property as a foreign key 
        public Byte MembershipTypeId { get; set; }
        [Display(Name ="Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}