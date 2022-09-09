using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace LostNelsonFound.Models.Binding
{
    public class RoleModel
    {

        [Key]
        public int RoleId
        {
            get; set;
        }
        public string RoleName
        {
            get
; set;
        }
    }
}
