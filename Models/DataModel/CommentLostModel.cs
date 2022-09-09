using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostNelsonFound.Models.DataModel
{
    public class CommentLostModel
    {
        [Key]

        public Guid CommentLostId { get; set; }
        public string LostDescription { get; set; }


        [ForeignKey("PersonId")]
        public Guid PersonId { get; set; }
        public PersonModel PersonModel { get; set; }


        [ForeignKey("LostId")]
        public Guid LostId { get; set; }
        public LostModel FoundModel { get; set; }
    }
}
