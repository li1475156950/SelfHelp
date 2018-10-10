using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
   public class Amount_Subject_Relation
    {
       [Key]
       public int AS_RelationID { get; set; }
        [StringLength(150)]
       public string SubjectCode { get; set; }
        [StringLength(150)]
       public string Amount_Code { get; set; }
       public DateTime? CreateTime { get; set; }
       public int Is_Delete { get; set; }
    }
}
