﻿using System;
using System.Collections.Generic;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.MetaData;
using SystemGroup.Framework.MetaData.Mapping;

namespace SystemGroup.General.UniversityManagement.Common
{
    [Serializable]
    [Master(typeof(IPresentationBusiness))]
    [SearchFields(nameof(Capacity))]
    partial class Presentation : Entity
    {
        //#region Properties

        //public string CourseTitle { get; set; }

        //#endregion

        #region Methods

        
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new NumericColumnInfo(nameof(Capacity), "Presentation_Capacity", NumericType.Integer));
            //columns.Add(new TextColumnInfo(nameof(CourseTitle), "Presentation_CourseTitle"));
            columns.Add(new ReferenceColumnInfo(nameof(CourseRef), "_"));
            columns.Add(new ReferenceColumnInfo(nameof(SemesterRef), "_"));
            columns.Add(new ReferenceColumnInfo(nameof(InstructorRef), "_"));
        }

        #endregion
    }
}
