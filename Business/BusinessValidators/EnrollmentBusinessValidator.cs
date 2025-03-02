using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Localization;
using SystemGroup.Framework.Service;
using SystemGroup.General.UniversityManagement.Common;

namespace SystemGroup.General.UniversityManagement.Business
{
    internal class EnrollmentBusinessValidator : BusinessValidator<Enrollment>
    {
        public override void Validate(Enrollment record, EntityActionType action)
        {
            base.Validate(record, action);

            switch (action)
            {
                case EntityActionType.Insert:
                case EntityActionType.Update:
                    AssertTakenPresentationIsNotAlreadyPassed(record);
                    AssertStudentEnrollmentItemsDoesNotCollide(record);
                    break;
                case EntityActionType.Delete:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }
        }

        private void AssertStudentEnrollmentItemsDoesNotCollide(Enrollment record)
        {
            var loadOptions = LoadOptions.With<Presentation>(p => p.TimeSlots);
            var presentations = ServiceFactory.Create<IPresentationBusiness>().FetchAll(loadOptions);

            var timeSlots = (from enrollmentItem in record.EnrollmentItems
                            join presentation in presentations on enrollmentItem.PresentationRef equals presentation.ID
                            select presentation.TimeSlots into timeSlotEntitySets
                            from timeSlot in timeSlotEntitySets
                            select timeSlot).ToEntitySet();

            if (PresentationBusiness.TimeSlotsCollideWithEachOther(timeSlots, timeSlots, out var otherCollidingTimeSlot, out var thisCollidingTimeSlot))
            {
                var (errorMessageKey, parameters) = PresentationBusiness.CreateTimeSlotCollisionExceptionDetail(thisCollidingTimeSlot, otherCollidingTimeSlot);
                throw this.CreateException(errorMessageKey, parameters);
            }
        
        }

        private void AssertTakenPresentationIsNotAlreadyPassed(Enrollment record)
        {

            var loadOptions = LoadOptions.With<Presentation>(p => p.Course);
            var presentations = ServiceFactory.Create<IPresentationBusiness>().FetchAll(loadOptions);

            var passedCoursesIDs = CourseBusiness.GetStudentPassedCourses(record.SemesterRef).Select(c => c.ID);

            var pairs = from enrollmentItem in record.EnrollmentItems
            join presentation in presentations on enrollmentItem.PresentationRef equals presentation.ID
            select new
            {
                enrollmentItem,
                presentation
            };

            var passedCourse = pairs.FirstOrDefault(p => passedCoursesIDs.Contains(p.presentation.CourseRef));
            if(passedCourse != null)
            {
                throw this.CreateException("Messages_CourseIsAlreadyPassed", passedCourse.presentation.Course.Title);
            }
        }
    }
}
