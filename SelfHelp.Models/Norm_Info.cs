using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
  public  class Norm_Info
    {
       [Key]
      public int NormID { get; set; }
       [StringLength(150)]
      public string NormCode { get; set; }
       [StringLength(150)]
      public string NormTitle { get; set; }
       public int U_ID { get; set; }
      public DateTime? CreateTime { get; set; }
      public int IS_Delete { get; set; }
    }
}
