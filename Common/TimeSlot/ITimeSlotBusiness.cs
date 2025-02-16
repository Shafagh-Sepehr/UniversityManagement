using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Service;

namespace SystemGroup.General.UniversityManagement.Common
{
    [ServiceInterface]
    public interface ITimeSlotBusiness : IBusinessBase<TimeSlot>
    {
        [EntityView("AllTimeSlot", "Views_AllTimeSlot", typeof(TimeSlotProjection), nameof(TimeSlot.Day), IsDefaultView = true)]
        new IQueryable<TimeSlot> FetchAll();
    }
}
