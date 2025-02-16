using System;
using System.Collections.Generic;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.MetaData;
using SystemGroup.Framework.MetaData.Mapping;

namespace SystemGroup.General.UniversityManagement.Common
{
    [Serializable]
    [Master(typeof(IStudentBusiness))]
    [SearchFields(nameof(Name), nameof(TotalCredits))]
    partial class Student : Entity
    {
        #region Methods

        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new TextColumnInfo(nameof(Name), "Student_Name"));
            columns.Add(new NumericColumnInfo(nameof(TotalCredits), "Student_TotalCredits", NumericType.Integer));
            columns.Add(new ReferenceColumnInfo(nameof(AdvisorRef), "_"));
        }

        #endregion
    }
}
