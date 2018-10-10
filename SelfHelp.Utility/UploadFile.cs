using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace SelfHelp.Utility
{
    public class UploadFile:Controller
    {
        public string SaveFile(HttpFileCollection files, string path, string name)
        {
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            var suffix = files[0].ContentType.Split('/');
            //获取文件格式  
            //var _suffix = suffix[1].Equals("jpeg", StringComparison.CurrentCultureIgnoreCase) ? "" : suffix[1];
            var _suffix = suffix[1] + "" + DateTime.Now.Ticks;
            var _temp = DateTime.Now.Ticks + name;
            //如果不修改文件名，则创建随机文件名  
            if (!string.IsNullOrEmpty(_temp))
            {
                name = _temp;
            }
            else
            {
                Random rand = new Random(24 * (int)DateTime.Now.Ticks);
                name = rand.Next() + "." + _suffix;
            }
            //文件保存  
            var full = path + name;
            files[0].SaveAs(full);
            return "/upload/images/"+name;
        }
        public void Upload(HttpContextBase context)
        {
            var relativePath = context.Request["savePath"];
            string fileName = context.Request["name"];
            int index = Convert.ToInt32(context.Request["chunk"]);//当前分块序号
            var guid = context.Request["guid"];//前端传来的GUID号
            var dir = context.Server.MapPath(relativePath);//文件上传目录
            dir = Path.Combine(dir, guid);//临时保存分块的目录
            if (!System.IO.Directory.Exists(dir))
                System.IO.Directory.CreateDirectory(dir);
            string filePath = Path.Combine(dir, index.ToString());//分块文件名为索引名，更严谨一些可以加上是否存在的判断，防止多线程时并发冲突
            var data = context.Request.Files["file"];//表单中取得分块文件
            if (data != null)//为null可能是暂停的那一瞬间
            {
                data.SaveAs(filePath);//报错
            }
        }
        public void Merge(HttpContextBase context)
        {
            var relativePath = context.Request["savePath"];
            var guid = context.Request["guid"];//GUID
            var uploadDir = context.Server.MapPath(relativePath);//Upload 文件夹
            var dir = Path.Combine(uploadDir, guid);//临时文件夹
            var fileName = context.Request["fileName"];//文件名
            var files = System.IO.Directory.GetFiles(dir);//获得下面的所有文件
            var finalPath = Path.Combine(uploadDir, fileName);//最终的文件名（demo中保存的是它上传时候的文件名，实际操作肯定不能这样）
            var fs = new FileStream(finalPath, FileMode.Create);
            foreach (var part in files.OrderBy(x => x.Length).ThenBy(x => x))//排一下序，保证从0-N Write
            {
                var bytes = System.IO.File.ReadAllBytes(part);
                fs.Write(bytes, 0, bytes.Length);
                bytes = null;
                System.IO.File.Delete(part);//删除分块
            }
            fs.Close();
            System.IO.Directory.Delete(dir);//删除文件夹
        }
    }
}
