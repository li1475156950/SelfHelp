using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
   public class MsgDelete
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MsgDeleteID { get; set; }
      
        public int DeleteUserID { get; set; }
        public int TiTleID { get; set; }
    }
}
