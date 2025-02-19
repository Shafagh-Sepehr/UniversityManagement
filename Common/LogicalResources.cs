using System.Collections.Generic;
using SystemGroup.Framework.Security;
using SystemGroup.Framework.Service;

namespace SystemGroup.General.UniversityManagement.Common
{
    internal class LogicalResources : ILogicalResourceDeclarator
    {
        public void DeclareLogicalResourceTree(IList<LogicalResourceTreeNode> list)
        {
            var res = new LogicalResourceCategory("University", "Labels_University", new LogicalResourceTreeNode[]
            {
                new CompositeLogicalResource(nameof(Course), "Course_Course", typeof(Course), new[]
                {
                    new LogicalResource("Add", "Course_Add"),
                    new LogicalResource("Edit", "Course_Edit"),
                    new LogicalResource("Delete", "Course_Delete"),
                }),
                new CompositeLogicalResource(nameof(Enrollment), "Enrollment_Enrollment", typeof(Enrollment), new[]
                {
                    new LogicalResource("Add", "Enrollment_Add"),
                    new LogicalResource("Edit", "Enrollment_Edit"),
                    new LogicalResource("Delete", "Enrollment_Delete"),
                }),
                new CompositeLogicalResource(nameof(Instructor), "Instructor_Instructor", typeof(Instructor), new[]
                {
                    new LogicalResource("Add", "Instructor_Add"),
                    new LogicalResource("Edit", "Instructor_Edit"),
                    new LogicalResource("Delete", "Instructor_Delete"),
                }),
                new CompositeLogicalResource(nameof(Presentation), "Presentation_Presentation", typeof(Presentation), new[]
                {
                    new LogicalResource("Add", "Presentation_Add"),
                    new LogicalResource("Edit", "Presentation_Edit"),
                    new LogicalResource("Delete", "Presentation_Delete"),
                }),
                new CompositeLogicalResource(nameof(Semester), "Semester_Semester", typeof(Semester), new[]
                {
                    new LogicalResource("Add", "Semester_Add"),
                    new LogicalResource("Edit", "Semester_Edit"),
                    new LogicalResource("Delete", "Semester_Delete"),
                }),
                new CompositeLogicalResource(nameof(Student), "Student_Student", typeof(Student), new[]
                {
                    new LogicalResource("Add", "Student_Add"),
                    new LogicalResource("Edit", "Student_Edit"),
                    new LogicalResource("Delete", "Student_Delete"),
                }),
                new CompositeLogicalResource(nameof(TimeSlot), "TimeSlot_TimeSlot", typeof(TimeSlot), new[]
                {
                    new LogicalResource("Add", "TimeSlot_Add"),
                    new LogicalResource("Edit", "TimeSlot_Edit"),
                    new LogicalResource("Delete", "TimeSlot_Delete"),
                }),
            });
            list.Add(res);
        }
    }
}
