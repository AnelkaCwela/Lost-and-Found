using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace LostNelsonFound.Models.Binding
{
    public class RegisterUserModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "SurName")]
        [Required]
        public string SurName { get; set; }
        [Display(Name ="Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        [Remote(action: "EmailIsInUsE", controller: "Account")]
        public string Email { get;set; }
        [Display(Name = "Phone")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
       
    }
}
