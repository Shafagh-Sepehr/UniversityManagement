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

        [EntityView("EnrollmentsInEnrollmentPhase", "Views_EnrollmentsInEnrollmentPhase", typeof(EnrollmentProjection), "Year")]
        IQueryable<Enrollment> FetchEnrollmentsInEnrollmentPhase();

        [EntityView("ActiveEnrollments", "Views_ActiveEnrollments", typeof(EnrollmentProjection), "Year")]
        IQueryable<Enrollment> FetchActiveEnrollments();

        [EntityView("FinishedEnrollments", "Views_FinishedEnrollments", typeof(EnrollmentProjection), "Year")]
        IQueryable<Enrollment> FetchFinishedEnrollments();

        [EntityView("FetchAllowedPresentationsForStudentInThisSemester", "_", typeof(PresentationProjection), "CourseTitle")]
        IQueryable<Presentation> FetchAllowedPresentationsForStudent(long studentRef);
    }
}