using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Service;

namespace SystemGroup.General.UniversityManagement.Common
{
    [ServiceInterface]
    public interface IEnrollmentBusiness : IBusinessBase<Enrollment>
    {
        [EntityView("AllEnrollments", "Views_AllEnrollments", typeof(EnrollmentProjection), "Year", IsDefaultView = true)]
        new IQueryable<Enrollment> FetchAll();

        [EntityView("FetchAllowedPresentationsForStudentInThisSemester", "_", typeof(PresentationProjection), "CourseTitle")]
        IQueryable<Presentation> FetchAllowedPresentationsForStudent(long studentRef);
    }
}