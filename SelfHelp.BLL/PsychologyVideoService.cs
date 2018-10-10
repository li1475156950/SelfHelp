using SelfHelp.Contract;
using SelfHelp.DAL.DAL;
using SelfHelp.IDAL;
using SelfHelp.Models;
using SelfHelp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.BLL
{
    public class PsychologyVideoService:IPsychologyVideoService
    {
        public IPsychologyVideoDAL dal {
            get 
            {
                return new PsychologyVideoDAL();
            }
        }
        public MovieAppreciationTableViewModel GetMovieAppreciationList(int pageSize, int pageIndex, string movieName)
        {
            return dal.GetMovieAppreciationList(pageSize,pageIndex,movieName);
        }
        public int RemoveMovieAppreciations(string[] mAIDArray)
        {
            return dal.RemoveMovieAppreciations(mAIDArray);
        }
        public int AddMovieAppreciation(MovieAppreciation model)
        {
            return dal.InsertEntity(model);
        }
        public VideoClipTableViewModel GetVideoClipList(int pageSize, int pageIndex, string videoClipName)
        {
            return dal.GetVideoClipList(pageSize,pageIndex,videoClipName);
        }
        public int RemoveVideoClips(string[] vCIDArray)
        {
            return dal.RemoveVideoClips(vCIDArray);
        }
        public int AddVideoClip(VideoClip model)
        {
            return dal.InsertEntity(model);
        }
        public List<VideoClip> GetAllVideoClip()
        {
            return dal.FindAll<VideoClip>();
        }
        public List<MovieAppreciation> GetAllMovieAppreciation()
        {
            return dal.FindAll<MovieAppreciation>();
        }
        public CourseTableViewModel GetCourseList(int pageSize, int pageIndex, string courseName)
        {
            return dal.GetCourseList(pageSize,pageIndex,courseName);
        }
        public List<Course> GetAllCourse()
        {
            return dal.FindAll<Course>();
        }
        public List<Chapter> GetChapterByCouID(int couID)
        {
            return dal.FindAll<Chapter>(m=>m.CouID == couID);
        }
        public int RemoveCourse(string[] couIDArray)
        {
            return dal.RemoveCourse(couIDArray);
        }
        public int AddCourse(Course course,List<Chapter> chapter)
        {
            return dal.AddCourse(course,chapter);
        }
    }
}
