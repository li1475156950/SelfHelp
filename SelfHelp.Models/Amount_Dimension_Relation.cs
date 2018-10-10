using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
   public class Amount_Dimension_Relation
    {
        [Key]
       public int AD_RelationID { get; set; }
       [StringLength(150)]
       public string Amount_Code { get; set; }
       [StringLength(150)]
       public string DimensionCode { get; set; }
       public DateTime? CreateTime { get; set; }
       public int U_ID { get; set; }
    }
}
