using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LostNelsonFound.Models.DataModel;

namespace LostNelsonFound.Models.Binding
{
    public class ClaimInsert
    {
        [Key]

        public Guid ClaimId { get; set; }
        [Required]
        public Guid PersonId { get; set; }
        [ForeignKey("PersonId")]
        public PersonModel PersonModel { get; set; }

        public byte[] photo { get; set; }

        [Required]
        public Guid FoundId { get; set; }
        [ForeignKey("FoundId")]
        public FoundModel FoundModel { get; set; }     
    }
}
