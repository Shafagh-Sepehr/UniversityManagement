using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Security;
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
