using SelfHelp.Models;
using SelfHelp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.IDAL
{
    public interface IPsychologyVideoDAL:IRepository
    {
        int RemoveMovieAppreciations(string[] mAIDArray);
        int RemoveVideoClips(string[] vCIDArray);
        int RemoveCourse(string[] couIDArray);
        int AddCourse(Course course, List<Chapter> chapter);
        MovieAppreciationTableViewModel GetMovieAppreciationList(int pageSize, int pageIndex, string movieName);
        VideoClipTableViewModel GetVideoClipList(int pageSize, int pageIndex, string videoClipName);
        CourseTableViewModel GetCourseList(int pageSize, int pageIndex, string courseName);
    }
}
