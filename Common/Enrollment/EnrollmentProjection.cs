using System.Collections.Generic;
using System.Linq;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Localization;
using SystemGroup.Framework.Service;

namespace SystemGroup.General.UniversityManagement.Common
{
    public class EnrollmentProjection : EntityProjection<Enrollment>
    {
        #region Methods

        public override IQueryable Project(IQueryable<Enrollment> inputs)
        {
            var semesters = ServiceFactory.Create<ISemesterBusiness>().FetchAll();
            var students = ServiceFactory.Create<IStudentBusiness>().FetchAll();

            var enrollmentItems = ServiceFactory.Create<IEnrollmentBusiness>().FetchDetail<EnrollmentItem>();
            var presentations = ServiceFactory.Create<IPresentationBusiness>().FetchAll();
            var courses = ServiceFactory.Create<ICourseBusiness>().FetchAll();

            var enrollmentCredits = from enrollment in inputs
                                    join enrollmentItem in enrollmentItems on enrollment.ID equals enrollmentItem.EnrollmentRef
                                    join presentation in presentations on enrollmentItem.PresentationRef equals presentation.ID
                                    join course in courses on presentation.CourseRef equals course.ID
                                    group course by enrollment.ID into enrollmentGroup
                                    select new
                                    {
                                        EnrollmentID = enrollmentGroup.Key,
                                        TotalCredits = enrollmentGroup.Sum(c => (int)c.Credits)
                                    };

            var enrollmentDetails = from enrollment in inputs
                                    join semester in semesters on enrollment.SemesterRef equals semester.ID
                                    join student in students on enrollment.StudentRef equals student.ID
                                    join credits in enrollmentCredits on enrollment.ID equals credits.EnrollmentID
                                    into CreditGroup
                                    from credits in CreditGroup.DefaultIfEmpty()
                                    select new
                                    {
                                        enrollment.ID,
                                        student.Name,
                                        semester.Year,
                                        semester.Season,
                                        semester.State,
                                        Credits = (credits != null) ? credits.TotalCredits : 0
                                    };

            return enrollmentDetails;
        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new TextColumnInfo("Name", "Student_Name"));
            columns.Add(new NumericColumnInfo("Year", "Semester_Year", NumericType.Integer));
            columns.Add(new LookupColumnInfo("Season", "Semester_Season", nameof(SemesterSeason)));
            columns.Add(new StateColumnInfo("State", "Semester_State", typeof(Semester)));
            columns.Add(new NumericColumnInfo("Credits", "Enrollment_Credits", NumericType.Integer));
        }

        #endregion
    }
}
