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
                    AssertSemesterDidNotChangeOutsideRegisteredState(record);
                    AssertSemesterIsUnique(record);
                    break;
                case EntityActionType.Delete:
                    AssertNoReferenceExists(record);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }
        }

        private void AssertSemesterDidNotChangeOutsideRegisteredState(Semester record)
        {
            var semesterBusiness = ServiceFactory.Create<ISemesterBusiness>();
            var originalSemester = semesterBusiness.FetchByID(record.ID).Single();

            if (record.State != SemesterState.Registered && HasRecordChanged(record, originalSemester))
            {
                throw this.CreateException("Messages_SemesterCantChangeOutsideRegisteredState");
            }
        }

        private void AssertSemesterIsUnique(Semester record)
        {
            var semesters = ServiceFactory.Create<ISemesterBusiness>().FetchAll().Where(s => s.ID != record.ID);

            if (semesters.Any( s => s.Season == record.Season && s.Year == record.Year))
            {
                throw this.CreateException("Messages_SemesterAlreadyExists");
            }
        }

        private static bool HasRecordChanged(Semester record, Semester originalSemester)
        {
            return originalSemester.Year != record.Year || originalSemester.Season != record.Season;
        }

        private void AssertNoReferenceExists(Semester record)
        {
            var loadOptions = LoadOptions.With<Semester>(s => s.Enrollments).With<Semester>(s => s.Presentations);
            var originalSemester = ServiceFactory.Create<ISemesterBusiness>().FetchByID(record.ID, loadOptions).Single();

            if (originalSemester == null || !HasRecordChanged(record, originalSemester))
            {
                return;
            }
            if (originalSemester.Presentations.Any() || originalSemester.Enrollments.Any())
            {
                throw this.CreateException("Messages_SemesterHasOtherEntitiesAssociatedWithItThusCantBeChanged");
            }
        }
    }
}
