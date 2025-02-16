using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Service;

namespace SystemGroup.General.UniversityManagement.Common
{
    public class PresentationProjection : EntityProjection<Presentation>
    {
        #region Methods

        public override IQueryable Project(IQueryable<Presentation> inputs)
        {
            var courses = ServiceFactory.Create<ICourseBusiness>().FetchAll();
            return from presentation in inputs
                   join course in courses
                       on presentation.CourseRef equals course.ID
                   select new
                   {
                       presentation.ID,
                       presentation.Capacity,
                       CourseTitle = course.Title,
                   };
        }

        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new TextColumnInfo("CourseTitle", "Presentation_CourseTitle"));
            columns.Add(new EntityColumnInfo<Presentation>(nameof(Presentation.Capacity)));
        }

        #endregion
    }
}
