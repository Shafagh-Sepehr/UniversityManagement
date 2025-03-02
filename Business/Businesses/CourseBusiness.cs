using System;
using System.Collections.Generic;
using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Eventing;
using SystemGroup.Framework.Host;
using SystemGroup.Framework.Logging;
using SystemGroup.Framework.Service;
using SystemGroup.Framework.Utilities;
using SystemGroup.General.UniversityManagement.Common;


namespace SystemGroup.General.UniversityManagement.Business
{
    [Service]
    public class CourseBusiness : BusinessBase<Course>, ICourseBusiness
    {
        [SubscribeTo(typeof(IHostService), nameof(IHostService.HostStarted))]
        private void OnHostStarted(object s, EventArgs e)
        {
            BusinessValidationProvider.RegisterValidator(new CourseBusinessValidator());
        }

        public static IQueryable<Course> GetStudentPassedCourses(long studentRef)
        {
            var presentations = ServiceFactory.Create<IPresentationBusiness>().FetchAll();
            var enrollmentItems = ServiceFactory.Create<IEnrollmentBusiness>().FetchDetail<EnrollmentItem>();
            var enrollments = ServiceFactory.Create<IEnrollmentBusiness>().FetchAll();
            var courses = ServiceFactory.Create<ICourseBusiness>().FetchAll();

            return from course in courses
            join presentation in presentations on course.ID equals presentation.CourseRef
            join enrollmentItem in enrollmentItems on presentation.ID equals enrollmentItem.PresentationRef
            join enrollment in enrollments on enrollmentItem.EnrollmentRef equals enrollment.ID
            where enrollment.StudentRef == studentRef &&
                  enrollmentItem.Grade >= 10 &&
                  enrollmentItem.GradeState == EnrollmentItemGradeState.Announced
            select course;
        }
    }
}
