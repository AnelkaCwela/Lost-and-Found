using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostNelsonFound.Models.DataModel
{
    public class ClaimModel
    {
        [Key]

        public Guid ClaimId { get; set; }
       
        [Required]
        public Guid FoundId { get; set; }
        [ForeignKey("FoundId")]
      public  FoundModel FoundModel { get; set; }
       
        public bool IsOwner { get; set; } = false;


        [Display(Name = "Surname")]
        [Required]
        public string Surname { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        //Claimed,Pading ,Collected
        [Display(Name = "Staff/Student/Identity Number")]
        [Required]
        [MinLength(9),MaxLength(13)]
        public string StudentStaffNo { get; set; }
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email Address")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
    }
}
