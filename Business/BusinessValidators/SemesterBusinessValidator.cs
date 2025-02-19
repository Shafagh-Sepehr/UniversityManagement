using System;
using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Filtering;
using SystemGroup.Framework.Localization;
using SystemGroup.Framework.Service;
using SystemGroup.General.UniversityManagement.Common;

namespace SystemGroup.General.UniversityManagement.Business
{
    internal class SemesterBusinessValidator : BusinessValidator<Semester>
    {
        public override void Validate(Semester record, EntityActionType action)
        {
            base.Validate(record, action);

            switch (action)
            {
                case EntityActionType.Insert:
                    AssertSemesterIsUnique(record);
                    break;
                case EntityActionType.Update:
                    AssertNoReferenceExists(record);
                    AssertSemesterIsUnique(record);
                    break;
                case EntityActionType.Delete:
                    AssertNoReferenceExists(record);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }
        }

        private void AssertSemesterIsUnique(Semester record)
        {
            var semesters = ServiceFactory.Create<ISemesterBusiness>().FetchAll();
            if (semesters.Any( s => s.Season == record.Season && s.Year == record.Year))
            {
                throw this.CreateException("Messages_SemesterAlreadyExists");
            }
        }

        private void AssertNoReferenceExists(Semester record)
        {
            var loadOptions = LoadOptions.With<Semester>(s => s.Enrollments).With<Semester>(s => s.Presentations);
            var semester = ServiceFactory.Create<ISemesterBusiness>().FetchByID(record.ID, loadOptions).Single();

            if (record.Year == semester.Year && record.Season == semester.Season)
            {
                return;
            }
            if (semester.Presentations.Any() || semester.Enrollments.Any())
            {
                throw this.CreateException("Messages_SemesterHasOtherEntitiesAssociatedWithItThusCantBeChanged");
            }
        }
    }
}
