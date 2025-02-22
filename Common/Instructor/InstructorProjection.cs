﻿using System.Collections.Generic;
using System.Linq;
using SystemGroup.Framework.Common;

namespace SystemGroup.General.UniversityManagement.Common
{
    public class InstructorProjection : EntityProjection<Instructor>
    {
        #region Methods

        public override IQueryable Project(IQueryable<Instructor> inputs)
        {
            return from input in inputs
                   select input;

        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new EntityColumnInfo<Instructor>(nameof(Instructor.Name)));
        }

        #endregion
    }
}
