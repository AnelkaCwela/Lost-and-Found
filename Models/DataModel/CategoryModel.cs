using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostNelsonFound.Models.DataModel
{
    public class CategoryModel
    {
        [Key]

        public Guid CategoryId { get; set; }
        [Required(ErrorMessage = "Category")]
        [Display(Name = "Category")]
        public string CategoryName { get; set; }

    }
}
