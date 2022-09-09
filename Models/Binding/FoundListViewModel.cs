using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LostNelsonFound.Models.DataModel;

namespace LostNelsonFound.Models.Binding
{
    public class FoundListViewModel
    {
        [Key]
        public Guid FoundId { get; set; }
        public FoundModel FoundModel { get; set; }
      
        public CategoryModel CategoryModel { get; set; }

      
        public StatuseModel statuseModel { get; set; }


    }
}
