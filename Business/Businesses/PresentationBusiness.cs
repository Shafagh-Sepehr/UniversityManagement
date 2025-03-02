using System;
using System.Data.Linq;
using System.Linq;
using System.Threading;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Eventing;
using SystemGroup.Framework.Exceptions;
using SystemGroup.Framework.Host;
using SystemGroup.Framework.Localization;
using SystemGroup.Framework.Lookup;
using SystemGroup.Framework.Service;
using SystemGroup.General.UniversityManagement.Common;


namespace SystemGroup.General.UniversityManagement.Business
{
    [Service]
    public class PresentationBusiness : BusinessBase<Presentation>, IPresentationBusiness
    {
        [SubscribeTo(typeof(IHostService), nameof(IHostService.HostStarted))]
        private void OnHostStarted(object s, EventArgs e)
        {
            BusinessValidationProvider.RegisterValidator(new PresentationBusinessValidator());
        }

        public static bool TimeSlotsCollideWithEachOther(EntitySet<TimeSlot> timeSlots, EntitySet<TimeSlot> otherTimeSlots, out TimeSlot firstCollidingTimeSlot, out TimeSlot secondCollidingTimeSlot)
        {
            foreach (var timeSlot in timeSlots)
            {
                foreach (var otherTimeSlot in otherTimeSlots)
                {
                    if (timeSlot != otherTimeSlot && DoesTimeSlotsCollide(timeSlot, otherTimeSlot))
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

        public static bool TimeSlotsCollideWithEachOther(EntitySet<TimeSlot> timeSlots, EntitySet<TimeSlot> otherTimeSlots)
        {
            return timeSlots.Any(timeSlot => TimeSlotHasCollision(timeSlot, otherTimeSlots));
        }

        public static bool TimeSlotHasCollision(TimeSlot timeSlot, EntitySet<TimeSlot> timeSlots)
        {
            return timeSlots
                    .Where(other => timeSlot != other)
                    .Any(other => DoesTimeSlotsCollide(timeSlot, other));
        }

        public static bool DoesTimeSlotsCollide(TimeSlot timeSlot, TimeSlot otherTimeSlot)
        {
            var isSameDay = timeSlot.Day == otherTimeSlot.Day;

            var doesNotCollide = timeSlot.EndTime <= otherTimeSlot.StartTime || otherTimeSlot.EndTime <= timeSlot.StartTime;
            return isSameDay && !doesNotCollide;
        }

        public static (string, object[]) CreateTimeSlotCollisionExceptionDetail(TimeSlot thisCollidingTimeSlot, TimeSlot otherCollidingTimeSlot)
        {
            var otherStartHour = FixString(otherCollidingTimeSlot.StartTime / 60);
            var otherStartMinute = FixString(otherCollidingTimeSlot.StartTime % 60);
            var otherEndHour = FixString(otherCollidingTimeSlot.EndTime / 60);
            var otherEndMinute = FixString(otherCollidingTimeSlot.EndTime % 60);

            var thisStartHour = FixString(thisCollidingTimeSlot.StartTime / 60);
            var thisStartMinute = FixString(thisCollidingTimeSlot.StartTime % 60);
            var thisEndHour = FixString(thisCollidingTimeSlot.EndTime / 60);
            var thisEndMinute = FixString(thisCollidingTimeSlot.EndTime % 60);

            var loadOptions = LoadOptions.With<Presentation>(p => p.Course);

            var presentation = ServiceFactory.Create<IPresentationBusiness>()
                .FetchByID(thisCollidingTimeSlot.PresentationRef, loadOptions)
                .Single();

            var otherPresentation = ServiceFactory.Create<IPresentationBusiness>()
                .FetchByID(otherCollidingTimeSlot.PresentationRef, loadOptions)
                .Single();

            return ("Messages_TimeSlotsCollide",
                new object[]{
                    $"{LookupService.Lookup(otherCollidingTimeSlot.Day).Value}",
                    $"{thisStartHour}:{thisStartMinute}",
                    $"{thisEndHour}:{thisEndMinute}",
                    $"{otherPresentation.Course.Title}",
                    $"{otherStartHour}:{otherStartMinute}",
                    $"{otherEndHour}:{otherEndMinute}",
                    $"{presentation.Course.Title}"
                });
        }

        private static string FixString(int value)
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
    }
}
