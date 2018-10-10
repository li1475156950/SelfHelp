using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
  public  class Operation_Info
  {
      [Key]
      public int OperationID { get; set; }
       [StringLength(150)]
      public string OperationCode { get; set; }
       [StringLength(500)]
      public string OperationContent { get; set; }
      public int OperationTypeID { get; set; }
       [StringLength(20)]
      public string OperationNum { get; set; }
    [StringLength(150)]
      public  string OperationFraction { get; set; }
       [StringLength(150)]
      public string OperationImage { get; set; }
      public DateTime? CreateTime { get; set; }
      public int U_ID { get; set; }
      public int IsDelete { get; set; }
    }
}
