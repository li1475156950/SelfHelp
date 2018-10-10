using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
   public class Norm_Explain_Relation
    {
       [Key]
       public int NE_ID { get; set; }
        [StringLength(150)]
       public string NormCode { get; set; }
        [StringLength(150)]
       public string ExplainCode { get; set; }
       public DateTime? CreateTime { get; set; }
       public int IS_Delete { get; set; }
    }
}
