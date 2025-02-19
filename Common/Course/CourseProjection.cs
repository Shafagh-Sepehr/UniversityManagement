using System.Collections.Generic;
using System.Linq;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Localization;
using SystemGroup.Framework.Service;

namespace SystemGroup.General.UniversityManagement.Common
{
    public class CourseProjection : EntityProjection<Course>
    {
        #region Methods

        public override IQueryable Project(IQueryable<Course> inputs)
        {
            var prerequisites = ServiceFactory
                .Create<ICourseBusiness>()
                .FetchDetail<Prerequisite>()
                .Select(p => p.CourseRef);
            return from course in inputs
                   select new
                   {
                       course.ID,
                       course.Title,
                       course.Credits,
                       HasPrerequisite = prerequisites.Contains(course.ID) ? this.ServerTranslate("Course_Yes") : this.ServerTranslate("Course_No")
                   };

        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new EntityColumnInfo<Course>(nameof(Course.Title)));
            columns.Add(new EntityColumnInfo<Course>(nameof(Course.Credits)));
            columns.Add(new TextColumnInfo("HasPrerequisite", "Course_HasPrerequisite"));
        }

        #endregion
    }
}
