using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
  public  class Subject_Info
  {
      [Key]
      public int SubjectID { get; set; }
      [StringLength(150)]
      public string SubjectCode { get; set; }
      [StringLength(150)]
      public string SubjectContent { get; set; }
      
      public int SubjectType { get; set; }    
      public int ShowType { get; set; }
      [StringLength(150)]
      public string SubjectImage { get; set; }
    
      public DateTime? CreateTime { get; set; }
     
      public int U_ID { get; set; }
   
      public int Sort { get; set; }
    }
 
}
