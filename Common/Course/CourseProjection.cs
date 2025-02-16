﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Common;

namespace SystemGroup.General.UniversityManagement.Common
{
    public class CourseProjection : EntityProjection<Course>
    {
        #region Methods

        public override IQueryable Project(IQueryable<Course> inputs)
        {
            return from input in inputs
                   select input;

        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new EntityColumnInfo<Course>(nameof(Course.Title)));
            columns.Add(new EntityColumnInfo<Course>(nameof(Course.Credits)));
        }

        #endregion
    }
}
