using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostNelsonFound.Models.DataModel
{
    public class CommentModel
    {
        [Key]

        public Guid CommentId { get; set; }
        [Required]
        public string Description { get; set; }


        [ForeignKey("PersonId")]
        public Guid PersonId { get; set; }
        public PersonModel PersonModel { get; set; }


        [ForeignKey("FoundId")]
        public Guid FoundId { get; set; }
        public LostModel FoundModel { get; set; }
    }
}
