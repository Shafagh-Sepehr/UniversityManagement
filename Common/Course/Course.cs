﻿using System;
using System.Collections.Generic;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.MetaData;
using SystemGroup.Framework.MetaData.Mapping;

namespace SystemGroup.General.UniversityManagement.Common
{
    [Serializable]
    [Master(typeof(ICourseBusiness))]
    [SearchFields(nameof(Title), nameof(Credits))]
    partial class Course : Entity
    {
        #region Properties

        public override DetailLoadOptions DeleteLoadOptions
        {
            get
            {
                return LoadOptions.With<Course>(c => c.Prerequisites).With<Course>(c => c.Prerequisites1);
            }

        }

        #endregion

        #region Methods

        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new TextColumnInfo(nameof(Title), "Course_Title"));
            columns.Add(new NumericColumnInfo(nameof(Credits), "Course_Credits", NumericType.Integer));
        }

        #endregion
    }
}
