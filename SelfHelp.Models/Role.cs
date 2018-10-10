using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SelfHelp.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        [StringLength(20)]
        public string RoleName { get; set; }
    }
}