using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
    [Master(typeof(ISemesterBusiness))]
    partial class Semester : Entity
    {
        #region Methods

        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new StateColumnInfo(nameof(State), "Semester_State", typeof(SemesterState)));
            columns.Add(new NumericColumnInfo(nameof(Year), "Semester_Year", NumericType.Integer));
            columns.Add(new LookupColumnInfo(nameof(Season), "Semester_SemesterNumber", nameof(SemesterSeason)));
        }

        #endregion
    }
}
