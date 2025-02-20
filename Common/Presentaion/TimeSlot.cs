using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Lookup;
using SystemGroup.Framework.MetaData;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Service;

namespace SystemGroup.General.UniversityManagement.Common
{
    [Serializable]
    [DetailOf(typeof(Presentation),nameof(PresentationRef))]
    [SearchFields(nameof(Day), nameof(StartTime), nameof(EndTime))]
    partial class TimeSlot : Entity
    {
        #region Properties

        public string DayText { get; set; }

        #endregion


        #region Methods

        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new LookupColumnInfo(nameof(Day), "TimeSlot_Day",nameof(TimeSlotDayOfWeek)));
            columns.Add(new TimeColumnInfo(nameof(StartTime), "TimeSlot_StartTime"));
            columns.Add(new TimeColumnInfo(nameof(EndTime), "TimeSlot_EndTime"));
            columns.Add(new ReferenceColumnInfo(nameof(PresentationRef), "_"));
        }

        #endregion

        public static void FillExtraProperties(EntitySet<TimeSlot> list)
        {
            foreach (var timeSlot in list)
            {
                timeSlot.DayText = LookupService.Lookup(timeSlot.Day).Value;
            }
        }
    }
}
