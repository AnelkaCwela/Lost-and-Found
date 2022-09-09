using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LostNelsonFound.Models.DataModel
{
    public class CampusModel
    {
        [Key]

        public Guid CampusId { get; set; }
        [Display(Name = "Campus")]
        public string Campus { get; set; }
    }
}
