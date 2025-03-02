using System;
using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Eventing;
using SystemGroup.Framework.Host;
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
            var courses = ServiceFactory.Create<ICourseBusiness>().FetchAll();
            var semesters = ServiceFactory.Create<ISemesterBusiness>().FetchAll();

            var passedCourses = CourseBusiness.GetStudentPassedCourses(studentRef);

            var allowedPresentations = from course in courses.Except(passedCourses)
                                       join presentation in presentations on course.ID equals presentation.CourseRef
                                       join semester in semesters on presentation.SemesterRef equals semester.ID
                                       select presentation;

            return allowedPresentations;
        }

        [SubscribeTo(typeof(IHostService), nameof(IHostService.HostStarted))]
        private void OnHostStarted(object s, EventArgs e)
        {
            BusinessValidationProvider.RegisterValidator(new EnrollmentBusinessValidator());
        }
    }
}
