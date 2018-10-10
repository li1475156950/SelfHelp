using SelfHelp.IDAL;
using SelfHelp.Models;
using SelfHelp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SelfHelp.DAL.DAL
{
    public class PsychologyVideoDAL : DaoBase, IPsychologyVideoDAL
    {
        public int RemoveMovieAppreciations(string[] mAIDArray)
        {
            for (int i = 0; i < mAIDArray.Length; i++)
            {
                var mAID = Convert.ToInt32(mAIDArray[i]);
                var entity = context.MovieAppreciations.FirstOrDefault(m => m.MAID == mAID);
                context.MovieAppreciations.Remove(entity);
            }
            return context.SaveChanges();
        }
        public int RemoveVideoClips(string[] vCIDArray)
        {
            for (int i = 0; i < vCIDArray.Length; i++)
            {
                var vCID = Convert.ToInt32(vCIDArray[i]);
                var entity = context.VideoClips.FirstOrDefault(m => m.VCID == vCID);
                context.VideoClips.Remove(entity);
            }
            return context.SaveChanges();
        }
        public int RemoveCourse(string[] couIDArray)
        {
            for (int i = 0; i < couIDArray.Length; i++)
            {
                var couID = Convert.ToInt32(couIDArray[i]);
                var entity = context.Courses.FirstOrDefault(m => m.CouID == couID);
                var entityList = context.Chapters.Where(m => m.CouID == couID);
                context.Courses.Remove(entity);
                context.Chapters.RemoveRange(entityList);
            }
            return context.SaveChanges();
        }
        public int AddCourse(Course course, List<Chapter> chapter)
        {
            var result = 0;
            context.Courses.Add(course);
            result = context.SaveChanges();
            chapter.ForEach(m => m.CouID = course.CouID);
            context.Chapters.AddRange(chapter);
            result += context.SaveChanges();
            return result;
        }
        public MovieAppreciationTableViewModel GetMovieAppreciationList(int pageSize, int pageIndex, string movieName)
        {
            var tempTable = new MovieAppreciationTableViewModel();
            var totalCount = context.MovieAppreciations.Where(m => m.MAName.Contains(movieName)).ToList().Count;
            tempTable.PageCount = totalCount / pageSize;
            if (totalCount < pageSize)
            {
                tempTable.PageCount = 1;
            }
            if (totalCount % pageSize != 0 && totalCount > pageSize)
            {
                tempTable.PageCount += 1;
            }
            SqlParameter[] param = { 
                new SqlParameter("@movieName","%"+movieName+"%")
                                   };
            var convertList = new List<MovieAppreciation>();
            convertList = context.Database.SqlQuery<MovieAppreciation>("select * from MovieAppreciation where MAName like @movieName order by CreateTime desc", param).ToList().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            tempTable.ModelList = convertList;
            return tempTable;
        }
        public VideoClipTableViewModel GetVideoClipList(int pageSize, int pageIndex, string videoClipName)
        {
            var tempTable = new VideoClipTableViewModel();
            var totalCount = context.VideoClips.Where(m => m.VCName.Contains(videoClipName)).ToList().Count;
            tempTable.PageCount = totalCount / pageSize;
            if (totalCount < pageSize)
            {
                tempTable.PageCount = 1;
            }
            if (totalCount % pageSize != 0 && totalCount > pageSize)
            {
                tempTable.PageCount += 1;
            }
            SqlParameter[] param = { 
                new SqlParameter("@videoClipName","%"+videoClipName+"%")
                                   };
            var convertList = new List<VideoClip>();
            convertList = context.Database.SqlQuery<VideoClip>("select * from VideoClip where VCName like @videoClipName order by CreateTime desc", param).ToList().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            tempTable.ModelList = convertList;
            return tempTable;
        }
        public CourseTableViewModel GetCourseList(int pageSize, int pageIndex, string courseName)
        {
            var tempTable = new CourseTableViewModel();
            var totalCount = context.Courses.Where(m => m.CouName.Contains(courseName)).ToList().Count;
            tempTable.PageCount = totalCount / pageSize;
            if (totalCount < pageSize)
            {
                tempTable.PageCount = 1;
            }
            if (totalCount % pageSize != 0 && totalCount > pageSize)
            {
                tempTable.PageCount += 1;
            }
            SqlParameter[] param = { 
                new SqlParameter("@courseName","%"+courseName+"%")
                                   };
            var convertList = new List<Course>();
            convertList = context.Database.SqlQuery<Course>("select * from Course where CouName like @courseName order by CreateTime desc", param).ToList().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            tempTable.ModelList = convertList;
            return tempTable;
        }
    }
}
