using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Common;

namespace SystemGroup.General.UniversityManagement.Common
{
    public class SemesterProjection : EntityProjection<Semester>
    {
        #region Methods

        public override IQueryable Project(IQueryable<Semester> inputs)
        {
            return from input in inputs
                   select input;

        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            //columns.Add(new TextColumnInfo("Field1", "Semester_Field1"));
        }

        #endregion
    }
}
