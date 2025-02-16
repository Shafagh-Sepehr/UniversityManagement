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
    [Master(typeof(IPresentationBusiness))]
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
