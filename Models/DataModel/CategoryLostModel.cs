using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostNelsonFound.Models.DataModel
{
    public class CategoryLostModel
    {
        [Key]

        public Guid CategoryLostId { get; set; }
        [Required(ErrorMessage = "Category")]
        [Display(Name = "Category")]
        public string CategoryLostName { get; set; }

    }
}
