using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Exceptions;
using SystemGroup.Framework.Localization;
using SystemGroup.Framework.Utilities;
using SystemGroup.General.UniversityManagement.Common;

namespace SystemGroup.General.UniversityManagement.Business
{
    public class CourseBusinessValidator : BusinessValidator<Course>
    {
        public override void Validate(Course record, EntityActionType action)
        {
            base.Validate(record, action);

            switch (action)
            {
                case EntityActionType.Insert:
                case EntityActionType.Update:
                    AssertCourseIsNotPrerequisiteOfItSelf(record);
                    break;
                case EntityActionType.Delete:
                    break;
                default:
                    AssertCourseIsNotPrerequisiteOfAnyOtherCourse(record);
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }
        }

        private void AssertCourseIsNotPrerequisiteOfAnyOtherCourse(Course record)
        {
            if (record.OtherCoursesWhoPrerequisite.Any())
            {
                throw this.CreateException("Messages_CourseIsPrerequisiteOfOtherCoursesThereforeCantBeDeleted");
            }
        }

        private void AssertCourseIsNotPrerequisiteOfItSelf(Course record)
        {
            if (record.Prerequisites.Any(recordPrerequisite => recordPrerequisite.PrerequisiteRef == record.ID))
            {
                throw this.CreateException("Messages_CourseCantBePrerequisiteOfItSelf");
            }
        }
    }
}