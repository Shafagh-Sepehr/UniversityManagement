using System;
using System.Data.Linq;
using System.Linq;
using System.Runtime.CompilerServices;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Localization;
using SystemGroup.Framework.Lookup;
using SystemGroup.Framework.Service;
using SystemGroup.General.UniversityManagement.Common;

namespace SystemGroup.General.UniversityManagement.Business
{
    public class PresentationBusinessValidator : BusinessValidator<Presentation>
    {
        public override void Validate(Presentation record, EntityActionType action)
        {
            base.Validate(record, action);

            switch (action)
            {
                case EntityActionType.Insert:
                    AssertPresentationHasTimeSlots(record);
                    AssertEndTimeIsAfterStartTime(record);
                    AssertTimeSlotsDoNotCollide(record);
                    AssertThatInstructorIsFreeInTimeSlots(record);
                    break;
                case EntityActionType.Update:
                    AssertPresentationHasTimeSlots(record);
                    AssertEndTimeIsAfterStartTime(record);
                    AssertTimeSlotsDoNotCollide(record);
                    AssertThatInstructorIsFreeInTimeSlots(record);
                    DeleteEnrollmentItemsIfTimeHasChanged(record);
                    break;
                case EntityActionType.Delete:
                    AssertNoReferenceExists(record);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }
        }

        private static void DeleteEnrollmentItemsIfTimeHasChanged(Presentation record)
        {
            var presentationLoadOptions = LoadOptions.With<Presentation>(p => p.TimeSlots);
            var oldPresentation = ServiceFactory.Create<IPresentationBusiness>().FetchByID(record.ID, presentationLoadOptions).Single();

            if (oldPresentation.TimeSlots.Count == record.TimeSlots.Count)
            {
                var shouldReturn = true;
                for (var i = 0; i < record.TimeSlots.Count; i++)
                {
                    if (record.TimeSlots[i].StartTime != oldPresentation.TimeSlots[i].StartTime ||
                        record.TimeSlots[i].EndTime != oldPresentation.TimeSlots[i].EndTime)
                    {
                        shouldReturn = false;
                        break;
                    }
                }

                if (shouldReturn)
                {
                    return;
                }
            }

            var enrollmentBusiness = ServiceFactory.Create<IEnrollmentBusiness>();
            var enrollmentLoadOptions = LoadOptions.With<Enrollment>(e => e.EnrollmentItems);
            var enrollments = enrollmentBusiness.FetchAll(enrollmentLoadOptions).ToList();


            for (var i = 0; i < enrollments.Count(); i++)
            {
                enrollments[i].EnrollmentItems = enrollments[i].EnrollmentItems
                   .Except(enrollments[i].EnrollmentItems.Where(e => e.PresentationRef == record.ID))
                   .ToEntitySet();
            }
            enrollmentBusiness.Save(ref enrollments);
        }

        private void AssertPresentationHasTimeSlots(Presentation record)
        {
            if (record.TimeSlots.Count == 0)
            {
                throw this.CreateException("Messages_PresentationMustHaveTimeSlots");
            }
        }

        private void AssertNoReferenceExists(Presentation record)
        {
            var loadOptions = LoadOptions.With<Presentation>(s => s.EnrollmentItems);
            var originalPresentation = ServiceFactory.Create<IPresentationBusiness>().FetchByID(record.ID, loadOptions).Single();

            if (originalPresentation.EnrollmentItems.Any())
            {
                throw this.CreateException("Messages_PresentationHasOtherEntitiesAssociatedWithItThusCantBeDeleted");
            }
        }

        private void AssertEndTimeIsAfterStartTime(Presentation record)
        {
            if (record.TimeSlots.Any(t => t.StartTime >= t.EndTime))
            {
                throw this.CreateException("Messages_EndTimeMustBeGreaterThanStartTime");
            }
        }

        private void AssertTimeSlotsDoNotCollide(Presentation record)
        {
            if (PresentationBusiness.TimeSlotsCollideWithEachOther(record.TimeSlots, record.TimeSlots))
            {
                throw this.CreateException("Messages_TimeSlotsShouldNotCollide");
            }
        }

        private void AssertThatInstructorIsFreeInTimeSlots(Presentation record)
        {
            var loadOptions = LoadOptions.With<Presentation>(p => p.TimeSlots);
            var presentations = ServiceFactory.Create<IPresentationBusiness>().FetchAll(loadOptions);

            var instructorTimeSlots = presentations
                .Where(p => p.InstructorRef == record.InstructorRef && record.SemesterRef == p.SemesterRef)
                .Select(p => p.TimeSlots)
                .SelectMany(e => e)
                .Where(t => !record.TimeSlots.Contains(t))
                .ToEntitySet();

            if (PresentationBusiness.TimeSlotsCollideWithEachOther(instructorTimeSlots, record.TimeSlots, out var otherCollidingTimeSlot, out var thisCollidingTimeSlot))
            {
                var (errorMessageKey, parameters) = PresentationBusiness.CreateTimeSlotCollisionExceptionDetail(thisCollidingTimeSlot, otherCollidingTimeSlot);
                throw this.CreateException(errorMessageKey, parameters);
            }   
        }
    }
}