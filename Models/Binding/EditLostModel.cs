using LostNelsonFound.Models.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LostNelsonFound.Models.Binding
{
    public class EditLostModel
    {

        [Key]
        public Guid LostId { get; set; }
        [Display(Name = "Lost Location")]
        [Required]
        public string Location { get; set; }
        public Guid PersonId { get; set; }
        [ForeignKey("PersonId")]
        public PersonModel PersonModel { get; set; }
        [Display(Name = "Category")]
        public Guid CategoryLostId { get; set; }
        [ForeignKey("CategoryLostId")]
        public CategoryLostModel CategoryModel { get; set; }
        [Display(Name = "Statuse")]
        public Guid StatuseLostId { get; set; }
        [ForeignKey("StatuseLostId")]
        public StatuseLostModel statuseModel { get; set; }

        [Display(Name = "Lost Date")]
        [Required]
        public DateTime LostDate { get; set; }
        [Display(Name = "Date Posted")]
        [Required]
        public DateTime DatePosted { get; set; }
        [Display(Name = "Date Found")]
        [Required]
        public DateTime DateFound { get; set; }

        [Display(Name = "Description")]
        [Required]
        public string LostDescription { get; set; }
        [Display(Name = "Campus")]
        public Guid CampusId { get; set; }
        [ForeignKey("CampusId")]
        public CampusModel CampusModel { get; set; }
        [Display(Name = "Do You Have tip")]
        public TipModel tip { get; set; }
    }
}
