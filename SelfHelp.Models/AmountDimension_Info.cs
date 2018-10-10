using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
   public class AmountDimension_Info
    {
         [Key]
       public int DimensionID { get; set; }
        [StringLength(150)]
       public string DimensionCode { get; set; }
       [StringLength(300)]
       public string DimensionName { get; set; }
       public int SubjectNum { get; set; }
       public int ScoringMode { get; set; }
       public int Sort { get; set; }
       public DateTime? CreateTime { get; set; }
       public int U_ID { get; set; }
       public int IS_Delete { get; set; }
    }
}
