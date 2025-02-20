using System;
using System.Collections.Generic;
using System.Linq;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.MetaData;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Service;

namespace SystemGroup.General.UniversityManagement.Common
{
    [Serializable]
    [Master(typeof(ISemesterBusiness))]
    [SearchFields(nameof(State), nameof(Year), nameof(Season))]
    partial class Semester : Entity
    {
        #region Methods

        public override void SetDefaultValues()
        {
            base.SetDefaultValues();

            Year = ServiceFactory.Create<ISemesterBusiness>().FetchAll().OrderByDescending(s => s.Version).Select(s => s.Year).FirstOrDefault();
            State = SemesterState.Registered;
            Season = SemesterSeason.Fall;
        }

        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new NumericColumnInfo(nameof(Year), "Semester_Year", NumericType.Integer));
            columns.Add(new LookupColumnInfo(nameof(Season), "Semester_Season", nameof(SemesterSeason)));
            columns.Add(new StateColumnInfo(nameof(State), "Semester_State", typeof(Semester)));
        }

        #endregion
    }
}
