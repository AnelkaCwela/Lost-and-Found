using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LostNelsonFound.Models.DataModel;

namespace LostNelsonFound.Models.Binding
{
    public class FoundModeldopleCate
    {
        [Key]
        public Guid FoundId { get; set; }
        [Display(Name = "Location Found On")]
        [Required]
        public string Location { get; set; }
        [Display(Name = "Email Address")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        public Guid PersonId { get; set; }
        [ForeignKey("PersonId")]
        public PersonModel PersonModel { get; set; }
        [Display(Name = "Image/Photo")]
        [Required]
        public byte[] PhotoFound { get; set; }
        [Display(Name = "Category")]
        [Required]
        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public CategoryModel CategoryModel { get; set; }
        [Display(Name = "Statuse")]
        [Required]
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
        //  Guid StudentStaffCradid = new Guid("D37E0883-B6C6-46DF-C97F-08D935C07142");
        public Guid Id { get; set; } 
        public bool FoundIs { get; set; } = false;
    }
}
