using System.Collections.Generic;
using System.Linq;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Service;

namespace SystemGroup.General.UniversityManagement.Common
{
    public class StudentProjection : EntityProjection<Student>
    {
        #region Methods

        public override IQueryable Project(IQueryable<Student> inputs)
        {
            var instructors = ServiceFactory.Create<IInstructorBusiness>().FetchAll();
            return from student in inputs
                join instructor in instructors on student.AdvisorRef equals instructor.ID
                   select new
                   {
                       student.ID,
                       student.Name,
                       student.TotalCredits,
                       AdvisorName = instructor.Name
                   };

        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new EntityColumnInfo<Student>(nameof(Student.Name)));
            columns.Add(new EntityColumnInfo<Student>(nameof(Student.TotalCredits)));
            columns.Add(new TextColumnInfo("AdvisorName", "Student_Advisor"));
        }

        #endregion
    }
}
