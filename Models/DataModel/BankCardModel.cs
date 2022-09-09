using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostNelsonFound.Models.DataModel
{
    public class BankCardModel
    {
         [Key]

        public Guid BankCardId { get; set; }
        [Display(Name="Surname")]
        [Required]
        public string Surname { get; set; }
        [Display(Name = "Initials")]
        [Required]
        public IniatialModel iniatials { get; set; }
        public Guid FoundId { get; set; }
        [ForeignKey("FoundId")]
        public FoundModel FoundModel { get; set; }

    }
}
