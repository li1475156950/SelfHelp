using SelfHelp.Models;
using SelfHelp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Contract
{
    [ServiceContract]
    public interface IPsychologyVideoService
    {
        [OperationContract]
        MovieAppreciationTableViewModel GetMovieAppreciationList(int pageSize, int pageIndex, string movieName);
        [OperationContract]
        int RemoveMovieAppreciations(string[] mAIDArray);
        [OperationContract]
        int AddMovieAppreciation(MovieAppreciation model);
        [OperationContract]
        VideoClipTableViewModel GetVideoClipList(int pageSize, int pageIndex, string videoClipName);
        [OperationContract]
        int RemoveVideoClips(string[] vCIDArray);
        [OperationContract]
        int AddVideoClip(VideoClip model);
        [OperationContract]
        List<VideoClip> GetAllVideoClip();
        [OperationContract]
        List<MovieAppreciation> GetAllMovieAppreciation();
        [OperationContract]
        List<Course> GetAllCourse();
        [OperationContract]
        List<Chapter> GetChapterByCouID(int couID);
        [OperationContract]
        CourseTableViewModel GetCourseList(int pageSize, int pageIndex, string courseName);
        [OperationContract]
        int RemoveCourse(string[] couIDArray);
        [OperationContract]
        int AddCourse(Course course, List<Chapter> chapter);
    }
}
