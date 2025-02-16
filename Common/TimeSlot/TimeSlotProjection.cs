using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Common;

namespace SystemGroup.General.UniversityManagement.Common
{
    public class TimeSlotProjection : EntityProjection<TimeSlot>
    {
        #region Methods

        public override IQueryable Project(IQueryable<TimeSlot> inputs)
        {
            return from input in inputs
                   select input;

        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            //columns.Add(new TextColumnInfo("Field1", "TimeSlot_Field1"));
        }

        #endregion
    }
}
