using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
   public class MessageTitle
    {
         [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int MsgTitleID { get; set; }
       [StringLength(300)]
       public string TiTle { get; set; }
       public int IsOpen { get; set; }//0是不公开的，1是公开的
       public DateTime? CreateTime { get; set; }
       public int CreateUID { get; set; }
    }
}
