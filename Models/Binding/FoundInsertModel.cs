using LostNelsonFound.Models.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LostNelsonFound.Models.Binding
{
    public class FoundInsertModel
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Location")]
        [Required]
        public string Location { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email Address")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        
       
        [Required]
        [Display(Name = "Select Image/Photo")]
        public byte[] PhotoFound { get; set; }
        [Required]
     [Display(Name ="Category")]
        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public CategoryModel CategoryModel { get; set; }

        [Display(Name = "Date Found")]
        [Required]
        public DateTime DateFound { get; set; }
        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }
        

    }
}
