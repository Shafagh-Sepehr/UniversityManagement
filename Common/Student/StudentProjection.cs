using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Common;

namespace SystemGroup.General.UniversityManagement.Common
{
    public class StudentProjection : EntityProjection<Student>
    {
        #region Methods

        public override IQueryable Project(IQueryable<Student> inputs)
        {
            return from input in inputs
                   select input;

        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new EntityColumnInfo<Student>(nameof(Student.Name)));
            columns.Add(new EntityColumnInfo<Student>(nameof(Student.TotalCredits)));
        }

        #endregion
    }
}
