using System.Collections.Generic;
using System.Linq;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Localization;
using SystemGroup.Framework.Lookup;
using SystemGroup.Framework.Service;

namespace SystemGroup.General.UniversityManagement.Common
{
    public class PresentationProjection : EntityProjection<Presentation>
    {
        #region Methods

        public override IQueryable Project(IQueryable<Presentation> inputs)
        {
            var courses = ServiceFactory.Create<ICourseBusiness>().FetchAll();
            var instructors = ServiceFactory.Create<IInstructorBusiness>().FetchAll();
            var semesters = ServiceFactory.Create<ISemesterBusiness>().FetchAll();

            return from presentation in inputs
                   join course in courses on presentation.CourseRef equals course.ID
                   join instructor in instructors on presentation.InstructorRef equals instructor.ID
                   join semester in semesters on presentation.SemesterRef equals semester.ID
                   select new
                   {
                       presentation.ID,
                       presentation.Capacity,
                       CourseTitle = course.Title,
                       InstructorName = instructor.Name,
                       SemesterTime = $"{this.ServerTranslate($"Semester_{semester.Season}")} {semester.Year}"
                   };
        }

        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new TextColumnInfo("CourseTitle", "Presentation_CourseTitle"));
            columns.Add(new TextColumnInfo("InstructorName", "Presentation_InstructorName"));
            columns.Add(new TextColumnInfo("SemesterTime", "Presentation_SemesterTime"));
            columns.Add(new EntityColumnInfo<Presentation>(nameof(Presentation.Capacity)));
        }

        #endregion
    }
}
