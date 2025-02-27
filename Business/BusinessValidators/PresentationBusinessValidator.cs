using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Exceptions;
using SystemGroup.Framework.Localization;
using SystemGroup.Framework.Lookup;
using SystemGroup.Framework.Service;
using SystemGroup.General.UniversityManagement.Common;
using ExpressionExtensions = SystemGroup.Framework.LegacyFiltering.ExpressionExtensions;

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
            if (TimeSlotsCollideWithEachOther(record.TimeSlots, record.TimeSlots))
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

            if (TimeSlotsCollideWithEachOther2(instructorTimeSlots, record.TimeSlots, out var otherCollidingTimeSlot, out var thisCollidingTimeSlot))
            {
                var otherStartHour = FixString(otherCollidingTimeSlot.StartTime / 60);
                var otherStartMinute = FixString(otherCollidingTimeSlot.StartTime % 60);
                var otherEndHour = FixString(otherCollidingTimeSlot.EndTime / 60);
                var otherEndMinute = FixString(otherCollidingTimeSlot.EndTime % 60);

                var thisStartHour = FixString(thisCollidingTimeSlot.StartTime / 60);
                var thisStartMinute = FixString(thisCollidingTimeSlot.StartTime % 60);
                var thisEndHour = FixString(thisCollidingTimeSlot.EndTime / 60);
                var thisEndMinute = FixString(thisCollidingTimeSlot.EndTime % 60);

                var otherLoadOptions = LoadOptions.With<Presentation>(p => p.Course);
                var presentation = ServiceFactory.Create<IPresentationBusiness>()
                    .FetchByID(otherCollidingTimeSlot.PresentationRef,otherLoadOptions)
                    .Single();

                throw this.CreateException(
                    "Messages_InstructorIsNotFree",
                    $"{LookupService.Lookup(otherCollidingTimeSlot.Day).Value}",
                    $"{thisStartHour}:{thisStartMinute}",
                    $"{thisEndHour}:{thisEndMinute}",
                    $"{presentation.Course.Title}",
                    $"{otherStartHour}:{otherStartMinute}",
                    $"{otherEndHour}:{otherEndMinute}"
                    );
            }   
        }

        private string FixString(int value)
        {
            if (value == 0)
            {
                return "00";
            }
            else if (value / 10 == 0)
            {
                return $"0{value}";
            }
            else
            {
                return value.ToString();
            }
        }

        private static bool TimeSlotsCollideWithEachOther2(EntitySet<TimeSlot> timeSlots, EntitySet<TimeSlot> otherTimeSlots, out TimeSlot firstCollidingTimeSlot, out TimeSlot secondCollidingTimeSlot)
        {
            foreach (var timeSlot in timeSlots)
            {
                foreach (var otherTimeSlot in otherTimeSlots)
                {
                    if (DoesTimeSlotsCollide(timeSlot, otherTimeSlot))
                    {
                        firstCollidingTimeSlot = timeSlot;
                        secondCollidingTimeSlot = otherTimeSlot;
                        return true;
                    }
                }
            }

            firstCollidingTimeSlot = null;
            secondCollidingTimeSlot = null;
            return false;
        }

        private static bool TimeSlotsCollideWithEachOther(EntitySet<TimeSlot> timeSlots, EntitySet<TimeSlot> otherTimeSlots)
        {
            return timeSlots.Any(timeSlot => TimeSlotHasCollision(timeSlot, otherTimeSlots));
        }

        private static bool TimeSlotHasCollision(TimeSlot timeSlot, EntitySet<TimeSlot> timeSlots)
        {
            return timeSlots
                    .Where(other => timeSlot != other)
                    .Any(other => DoesTimeSlotsCollide(timeSlot, other));
        }

        private static bool DoesTimeSlotsCollide(TimeSlot timeSlot, TimeSlot otherTimeSlot)
        {
            var isSameDay = timeSlot.Day == otherTimeSlot.Day;

            var doesNotCollide = timeSlot.EndTime <= otherTimeSlot.StartTime || otherTimeSlot.EndTime <= timeSlot.StartTime;
            return isSameDay && !doesNotCollide;
        }
    }
}