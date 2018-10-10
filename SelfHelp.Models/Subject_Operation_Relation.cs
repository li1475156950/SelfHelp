using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
   public class Subject_Operation_Relation
    {
       /// <summary>
       /// 关系表id
       /// </summary>
       [Key]
       public int Subject_Operation_RelationID { get; set; }
       /// <summary>
       /// 题干code
       /// </summary>
        [StringLength(150)]
       public string SubjectCode { get; set; }
       /// <summary>
       /// 题支编码
       /// </summary>
        [StringLength(150)]
       public string OperationCode { get; set; }
       /// <summary>
       /// 创建时间
       /// </summary>
       public DateTime? CreateTime { get; set; }
       public int Is_Delete { get; set; }
    }
    

}
