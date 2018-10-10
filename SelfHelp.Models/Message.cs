using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
  public  class Message
    {
       [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int MessageID { get; set; }
      
      public int TitleID { get; set; }
       [MaxLength]
      public string Content { get; set; }
      public int Sender { get; set; }
      public int receiver { get; set; }
      public DateTime? CreateTime { get; set; }
    }
}
