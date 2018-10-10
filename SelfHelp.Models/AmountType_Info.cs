using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
   public class AmountType_Info
    {
         [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int Amount_TypeID { get; set; }
        [StringLength(200)]
       public string AmountType_Name { get; set; }
       public int U_ID { get; set; }
       public DateTime? CreateTime { get; set; }
       public int IS_Delete { get; set; }
    }
}
