using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Service;
using SystemGroup.General.UniversityManagement.Common;


namespace SystemGroup.General.UniversityManagement.Business
{
    [Service]
    public class EnrollmentBusiness : BusinessBase<Enrollment>, IEnrollmentBusiness
    {
        public virtual IQueryable<Enrollment> FetchEnrollmentsInEnrollmentPhase()
        {
            var loadOptions = LoadOptions.With<Enrollment>(e => e.Semester);
            return FetchAll().Where(e => e.Semester.State == SemesterState.EnrollmentPhase);
        }

        public virtual IQueryable<Enrollment> FetchActiveEnrollments()
        {
            var loadOptions = LoadOptions.With<Enrollment>(e => e.Semester);
            return FetchAll().Where(e => e.Semester.State == SemesterState.Active);
        }

        public virtual IQueryable<Enrollment> FetchFinishedEnrollments()
        {
            var loadOptions = LoadOptions.With<Enrollment>(e => e.Semester);
            return FetchAll().Where(e => e.Semester.State == SemesterState.Finished);
        }

        public virtual IQueryable<Presentation> FetchAllowedPresentationsForStudent(long studentRef)
        {
            var presentations = ServiceFactory.Create<IPresentationBusiness>().FetchAll();
            var enrollmentItems = ServiceFactory.Create<IEnrollmentBusiness>().FetchDetail<EnrollmentItem>();
            var enrollments = ServiceFactory.Create<IEnrollmentBusiness>().FetchAll();
            var courses = ServiceFactory.Create<ICourseBusiness>().FetchAll();
            var semesters = ServiceFactory.Create<ISemesterBusiness>().FetchAll();



            var passedCourses =
                  from course in courses
                  join presentation in presentations on course.ID equals presentation.CourseRef
                  join enrollmentItem in enrollmentItems on presentation.ID equals enrollmentItem.PresentationRef
                  join enrollment in enrollments on enrollmentItem.EnrollmentRef equals enrollment.ID
                  where enrollment.StudentRef == studentRef &&
                        enrollmentItem.Grade >= 10 &&
                        enrollmentItem.GradeState == EnrollmentItemGradeState.Announced
                  select course;

            var allowedPresentations = from course in courses.Except(passedCourses)
                                       join presentation in presentations on course.ID equals presentation.CourseRef
                                       join semester in semesters on presentation.SemesterRef equals semester.ID
                                       select presentation;

            return allowedPresentations;
        }
    }
}
