using System;
using System.Collections.Generic;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.MetaData;

namespace SystemGroup.General.UniversityManagement.Common
{
    [Serializable]
    [DetailOf(typeof(Course), nameof(CourseRef))]
    //[SearchFields] TODO check if this throws exception
    partial class Prerequisite : Entity
    {
        #region Methods

        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new ReferenceColumnInfo(nameof(CourseRef), "_"));
            columns.Add(new ReferenceColumnInfo(nameof(PrerequisiteRef), "_"));
        }

        #endregion
    }
}
