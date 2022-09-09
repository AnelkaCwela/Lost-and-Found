using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LostNelsonFound.Models.DataModel
{
    public class EditFoundModel
    {
        [Key]
        public Guid FoundId { get; set; }
        [Display(Name = "Location Found On")]
        [Required]
        public string Location { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        public string PhoneNumber { get; set; }

        public Guid PersonId { get; set; }
        [ForeignKey("PersonId")]
        public PersonModel PersonModel { get; set; }
        
        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public CategoryModel CategoryModel { get; set; }

        public Guid StatuseId { get; set; }
        [ForeignKey("StatuseId")]
        public StatuseModel statuseModel { get; set; }

        [Display(Name = "Date Posted")]
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
