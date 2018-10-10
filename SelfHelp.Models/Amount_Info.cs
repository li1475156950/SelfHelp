using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
   public class Amount_Info
    {
       public Amount_Info() 
       {
           TabID = 0;
       }
       /// <summary>
        ///量表表ID
        /// </summary>
       [Key]
       public int Amount_ID { get; set;  }
       /// <summary>
       /// 量表编码
       /// </summary>
       [StringLength(50)]
       public string Amount_Code { get; set; }
       /// <summary>
       /// 量表名称
       /// </summary>
        [StringLength(300)]
       public string Amount_Name { get; set; }
       /// <summary>
       /// 量表别名
       /// </summary>
        [StringLength(300)]
       public string Amount_DisplayName { get; set; }
       [MaxLength]
        public string Amount_JianPin { get; set; }
       [MaxLength]
        public string Amount_Pinyin { get; set; }
       /// <summary>
       /// 量表类型
       /// </summary>

       public int Amount_TypeID { get; set; }
       /// <summary>
       /// 量表题数
       /// </summary>
       public int Amount_SubjectNum { get; set; }
        [StringLength(300)]
       public string Start_ApplyPeoples { get; set; }
        [StringLength(300)]
       public string End_ApplyPeoples { get; set; }
       
       public int Amount_Source { get; set; }
      /// <summary>
      /// 备注
      /// </summary>
        [MaxLength]
       public string Amount_Marks { get; set; }
       /// <summary>
       /// 指导语
       /// </summary>
        [MaxLength]
       public string Amount_Guidance { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>      
        public int U_ID { get; set; }   
       /// <summary>
       /// 创建时间
       /// </summary>
       public DateTime? CreateTime { get; set; }
       public decimal CompleteAmount { get; set; }
       public int? IS_Delete { get; set; }
       public int? AnswerMin_Time { get; set; }
       public int? AnswerMax_Time { get; set; }
       [StringLength(300)]
       public string LicenseCode { get; set; }
       public int? AmountCreatePerson { get; set; }
       public int TabID { get; set; }
    }
}
