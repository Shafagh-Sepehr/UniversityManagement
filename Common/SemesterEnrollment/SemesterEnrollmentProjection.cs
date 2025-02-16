using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Common;

namespace SystemGroup.General.UniversityManagement.Common
{
    public class SemesterEnrollmentProjection : EntityProjection<SemesterEnrollment>
    {
        #region Methods

        public override IQueryable Project(IQueryable<SemesterEnrollment> inputs)
        {
            return from input in inputs
                   select input;

        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            //columns.Add(new TextColumnInfo("Field1", "SemesterEnrollment_Field1"));
        }

        #endregion
    }
}
