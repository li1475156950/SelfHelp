using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
   public class NormExplain_Info
    {
        [Key]
       public int ExplainID { get; set; }
        [StringLength(300)]
       public string ExplainCode { get; set; }
        [StringLength(300)]
       public string ExplainName { get; set; }

       public int NormSex { get; set; }
       public decimal NormStartAge { get; set; }
       public decimal NormEndAge { get; set; }
       public decimal StartFraction { get; set; }
       public decimal EndFraction { get; set; }
       [MaxLength]
       public string NormExplain { get; set; }
       [MaxLength]
       public string NormProposal { get; set; }
       public DateTime? CreateTime { get; set; }
       [StringLength(100)]
       public string First_Symbol { get; set; }
        [StringLength(100)]
       public string Second_Symbol { get; set; }
    }
}
