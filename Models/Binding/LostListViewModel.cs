using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LostNelsonFound.Models.DataModel;

namespace LostNelsonFound.Models.Binding
{
    public class LostListViewModel
    {
        [Key]
        public Guid Id { get; set; }
       public LostModel LostModel { get; set; }
        public CategoryLostModel CategoryModel { get; set; }

        public StatuseLostModel statuseModel { get; set; }
        
        public CampusModel CampusMode { get; set; }
      

    }
}
