using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Lookup;
using SystemGroup.Framework.MetaData;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Service;
using SystemGroup.Framework.StateManagement;

namespace SystemGroup.General.UniversityManagement.Common
{
    [Serializable]
    [Master(typeof(ITimeSlotBusiness))]
    partial class TimeSlot : Entity
    {
        #region Methods

        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new LookupColumnInfo(nameof(Day), "TimeSlot_Day",nameof(DayOfWeek)));
            columns.Add(new TimeColumnInfo(nameof(StartTime), "TimeSlot_StartTime"));
            columns.Add(new TimeColumnInfo(nameof(EndTime), "TimeSlot_EndTime"));
            columns.Add(new ReferenceColumnInfo(nameof(PresentationRef), "_"));
        }

        #endregion
    }
}
