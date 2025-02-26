using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Exceptions;
using SystemGroup.Framework.Localization;

namespace SystemGroup.General.UniversityManagement.Common
{
    public class SemesterProjection : EntityProjection<Semester>
    {
        #region Methods

        public override IQueryable Project(IQueryable<Semester> inputs)
        {
            return from semester in inputs
                   select new
                   {
                       semester.ID,
                       semester.State,
                       SemesterTime = $"{this.ServerTranslate($"Semester_{semester.Season}")} {semester.Year}"
                   };

        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new TextColumnInfo("SemesterTime", "Semester_SemesterTime"));
            columns.Add(new EntityColumnInfo<Semester>(nameof(Semester.State)));
        }

        #endregion
    }
}
