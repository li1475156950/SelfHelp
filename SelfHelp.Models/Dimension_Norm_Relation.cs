using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
   public class Dimension_Norm_Relation
    {
        [Key]
       public int Dimension_Norm_RelationID { get; set; }
       [StringLength(150)]
       public string DimensionCode { get; set; }
       [StringLength(150)]
       public string NormCode { get; set; }
       public DateTime? CreateTime { get; set; }
       public int Is_Used { get; set; }
    }
}
