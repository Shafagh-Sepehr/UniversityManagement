using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Service;
using SystemGroup.General.UniversityManagement.Common;


namespace SystemGroup.General.UniversityManagement.Business
{
    [Service]
    public class StudentBusiness : BusinessBase<Student>, IStudentBusiness
    {
        public virtual IQueryable<Student> FetchNotEnrolledStudents()
        {
            var enrollmentPhaseSemester = ServiceFactory.Create<ISemesterBusiness>()
                .FetchAll()
                .Single(s => s.State == SemesterState.EnrollmentPhase);

            var loadOptions = LoadOptions.With<Student>(s => s.Enrollments);
            return FetchAll(loadOptions).Where(s => !s.Enrollments.Select(e => e.ID).Contains(enrollmentPhaseSemester.ID));
        }
    }
}
