using LostNelsonFound.Models.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LostNelsonFound.Models.Binding
{
    public class LostInsertModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        
        public string PhoneNumber { get; set; }
        [Display(Name = "Email Address")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Display(Name = "Location")]
        [Required]
        public string Location { get; set; }
        [Display(Name = "Category")]
        [Required]
        public Guid CategoryLostId { get; set; }
        [ForeignKey("CategoryLostId")]
        public CategoryLostModel CategoryModel { get; set; }

        [Display(Name = "Lost Date")]
        [Required]
        public DateTime LostDate { get; set; }
       

        [Display(Name = "Description")]
        [Required]
        public string LostDescription { get; set; }
        [Display(Name = "Campus")]
        [Required]
        public Guid CampusId { get; set; }
        [ForeignKey("CampusId")]
        public CampusModel CampusModel { get; set; }
        [Display(Name = "Tip Founder")]
        [Required]
        public  TipModel tip { get; set; }
    }
}
