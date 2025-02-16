using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Service;

namespace SystemGroup.General.UniversityManagement.Common
{
    [ServiceInterface]
    public interface ICourseBusiness : IBusinessBase<Course>
    {
        [EntityView("AllCourse", "Views_AllCourses", typeof(CourseProjection), nameof(Course.Title), IsDefaultView = true)]
        new IQueryable<Course> FetchAll();
    }
}
