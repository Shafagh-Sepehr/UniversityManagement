using System.Collections.Generic;
using System.Linq;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Service;

namespace SystemGroup.General.UniversityManagement.Common
{
    public class TimeSlotProjection : EntityProjection<TimeSlot>
    {
        #region Methods

        public override IQueryable Project(IQueryable<TimeSlot> inputs)
        {
            var presentations = ServiceFactory.Create<IPresentationBusiness>().FetchAll();
            var courses = ServiceFactory.Create<ICourseBusiness>().FetchAll();
            return from timeSlot in inputs
                   join presentation in presentations on timeSlot.PresentationRef equals presentation.ID
                   join course in courses on presentation.CourseRef equals course.ID
                   select new
                   {
                       timeSlot.ID,
                       timeSlot.Day,
                       timeSlot.StartTime,
                       timeSlot.EndTime,
                       PresentedCourseTitle = course.Title
                   };
        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new EntityColumnInfo<TimeSlot>(nameof(TimeSlot.Day)));
            columns.Add(new EntityColumnInfo<TimeSlot>(nameof(TimeSlot.StartTime)));
            columns.Add(new EntityColumnInfo<TimeSlot>(nameof(TimeSlot.EndTime)));
            columns.Add(new EntityColumnInfo<TimeSlot>("PresentedCourseTitle"));
        }

        #endregion
    }
}
