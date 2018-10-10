using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
   public class DimensionFormula_Info
    {
       [Key]
       public int FormulaID { get; set; }
       [StringLength(150)]
       public string FormulaCode { get; set; }
       [StringLength(150)]
       public string DimensionCode { get; set; }
       [MaxLength]
       public string FormulaStr { get; set; }
       public int U_ID { get; set; }
       public DateTime? CreateTime { get; set; }
      
       public int IsDelete { get; set; }
    }
}
