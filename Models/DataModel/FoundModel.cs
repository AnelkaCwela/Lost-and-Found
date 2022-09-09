using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostNelsonFound.Models.DataModel
{
    public class FoundModel
    {
        [Key]
        public Guid FoundId { get; set; }
        [Display(Name = "Location Found On")]
        [Required]
        public string Location { get; set; }
        
        [Display(Name ="Phone Number")]
        [Required]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email Address")]
        [Required]
        public string EmailAddress { get; set; }

        public Guid PersonId { get; set; }
        [ForeignKey("PersonId")]
        public PersonModel PersonModel { get; set; }
        [Required]
        public byte[] PhotoFound { get; set; }
        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public CategoryModel CategoryModel { get; set; }

        public Guid StatuseId { get; set; }
        [ForeignKey("StatuseId")]
        public StatuseModel statuseModel { get; set; }

        [Display(Name ="Date Posted")]
        [Required]
        public DateTime DatePosted { get; set; }
        [Display(Name = "Date Found")]
        [Required]
        public DateTime DateFound { get; set; }
        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }
       

    }
}
