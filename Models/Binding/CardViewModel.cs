using LostNelsonFound.Models.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LostNelsonFound.Models.Binding
{
    public class CardViewModel
    {
        [Display(Name="Surname")]
        public string Surname { get; set; }
        [Display(Name = "Initials")]
        public IniatialModel iniatials { get; set; }
    }
}
