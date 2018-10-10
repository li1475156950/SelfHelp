using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
  public  class AnswerAdd
    {
       [Key]
      public int AnswerAdd_ID { get; set; }
       [StringLength(300)]
      public string AnswerAdd_Code { get; set; }
      [MaxLength]
       public string AnswerAdd_Record { get; set; }
      [StringLength(300)]
      public string Amount_Code { get; set; }

      public int AnswerAdd_score { get; set;  }  
      public int AnswerPeople { get; set; }     
      public int AnswerIsDelete { get; set; }  
      public DateTime? Answer_CreateTime { get; set; }
      [MaxLength]
      public string NewRecord { get; set; }
    }
}
