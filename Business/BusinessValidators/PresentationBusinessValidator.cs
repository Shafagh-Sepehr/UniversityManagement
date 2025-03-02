using System;
using System.Data.Linq;
using System.Linq;
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
                    AssertIfPresentationHasNoTimeSlot(record);
                    AssertEndTimeIsAfterStartTime(record);
                    AssertTimeSlotsDoNotCollide(record);
                    AssertThatInstructorIsFreeInTimeSlots(record);
                    break;
                case EntityActionType.Update:
                    AssertIfPresentationHasNoTimeSlot(record);
                    AssertEndTimeIsAfterStartTime(record);
                    AssertTimeSlotsDoNotCollide(record);
                    AssertThatInstructorIsFreeInTimeSlots(record);
                    break;
                case EntityActionType.Delete:
                    AssertNoReferenceExists(record);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }
        }

        private void AssertIfPresentationHasNoTimeSlot(Presentation record)
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