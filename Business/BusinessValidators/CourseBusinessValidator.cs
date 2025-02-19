using System;
using System.Collections.Generic;
using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Localization;
using SystemGroup.Framework.Service;
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
                    AssertRecursivePrerequisitationDoesNotExistWithoutDbCall(record);
                    break;
                case EntityActionType.Update:
                    AssertRecursivePrerequisitationDoesNotExistWithoutDbCall(record);
                    AssertCourseIsNotPrerequisiteOfAnyOtherCourse(record);
                    break;
                case EntityActionType.Delete:
                    AssertCourseIsNotPrerequisiteOfAnyOtherCourse(record);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }
        }

        private void AssertCourseIsNotPrerequisiteOfAnyOtherCourse(Course record)
        {
            var loadOptions = LoadOptions.With<Course>(r => r.OtherCoursesWhoPrerequisite);
            var course = ServiceFactory.Create<ICourseBusiness>()
                .FetchByID(record.ID, loadOptions)
                .Single();

            if (course.OtherCoursesWhoPrerequisite.Any())
            {
                throw this.CreateException("Messages_CourseIsPrerequisiteOfOtherCoursesThereforeCantBeChanged");
            }
        }

        private void AssertRecursivePrerequisitationDoestExistMultipleDbCalls(Course course)
        {
            var courseBiz = ServiceFactory.Create<ICourseBusiness>();
            var remainingCoursesQueue = new Stack<Course>();

            AddPrerequisitesToStack(course);

            while (remainingCoursesQueue.Any())
            {
                if (remainingCoursesQueue.Peek().ID == course.ID)
                {
                    throw this.CreateException("Messages_CourseCantBePrerequisiteOfItSelf");
                }
                AddPrerequisitesToStack(remainingCoursesQueue.Pop());
            }

            return;

            void AddPrerequisitesToStack(Course c)
            {
                foreach (var coursePrerequisite in c.Prerequisites)
                {

                    remainingCoursesQueue.Push(courseBiz.FetchByID(coursePrerequisite.PrerequisiteRef, LoadOptions.With<Course>(co => co.Prerequisites)).Single());
                }
            }
        }

        private void AssertRecursivePrerequisitationDoesNotExistWithoutDbCall(Course course)
        {
            var prerequisitesDictionary = ServiceFactory.Create<ICourseBusiness>()
                .FetchDetail<Prerequisite>()
                .GroupBy(p => p.CourseRef, p => p.PrerequisiteRef)
                .ToDictionary(g => g.Key, g => g.ToList());

            prerequisitesDictionary[course.ID] = course.Prerequisites.Select(p => p.PrerequisiteRef).ToList();

            var remainingCoursesQueue = new Stack<long>();

            AddPrerequisitesToStack(course.ID);

            while (remainingCoursesQueue.Any())
            {
                if (remainingCoursesQueue.Peek() == course.ID)
                {
                    throw this.CreateException("Messages_CourseCantBePrerequisiteOfItSelf");
                }
                AddPrerequisitesToStack(remainingCoursesQueue.Pop());
            }

            return;

            void AddPrerequisitesToStack(long id)
            {
                if (prerequisitesDictionary.TryGetValue(id, out var prerequisiteIdList))
                {
                    foreach (var prerequisiteId in prerequisiteIdList)
                    {

                        remainingCoursesQueue.Push(prerequisiteId);
                    }
                }
            }
        }
    }
}