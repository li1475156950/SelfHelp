using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
  public  class Dimension_Subject_Relation
    {
      [Key]
      public int Dimension_Subject_Relation_ID { get; set; } 
      [StringLength(150)]
      public string DimensionCode { get; set; }
      [StringLength(150)]
      public string SubjectCode { get; set; }
      public DateTime? CreateTime { get; set; }
      public int Is_Delete { get; set; }
    }
}
