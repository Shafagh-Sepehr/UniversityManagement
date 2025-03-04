using System;
using System.Collections.Generic;
using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.MetaData;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Service;

namespace SystemGroup.General.UniversityManagement.Common
{
    [Serializable]
    [Master(typeof(IStudentBusiness))]
    [SearchFields(nameof(Name), nameof(TotalCredits))]
    partial class Student : Entity
    {
        #region Methods

        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new TextColumnInfo(nameof(Name), "Student_Name"));
            columns.Add(new NumericColumnInfo(nameof(TotalCredits), "Student_TotalCredits", NumericType.Integer));
            columns.Add(new ReferenceColumnInfo(nameof(AdvisorRef), "_"));
        }

        public virtual int MaxCreditsAllowed()
        {
            int maxCredits;

            var loadOptions = LoadOptions
                .With<Enrollment>(e => e.EnrollmentItems)
                .With<EnrollmentItem>(e => e.Presentation)
                .With<Presentation>(e => e.Course);

            var enrollmentBiz = ServiceFactory.Create<IEnrollmentBusiness>();
            var lastEnrollment = enrollmentBiz.FetchAll(loadOptions).Where(e => e.StudentRef == ID).Skip(1).FirstOrDefault();

            if (lastEnrollment == null)
            {
                maxCredits = 20;
            }
            else
            {
                var lastEnrollmentGrade =
                    lastEnrollment.EnrollmentItems.Sum(ei => ei.Grade * (int)ei.Presentation.Course.Credits) /
                                          lastEnrollment.EnrollmentItems.Sum(ei => (int)ei.Presentation.Course.Credits);

                if (lastEnrollmentGrade >= 17)
                {
                    maxCredits = 24;
                }
                else if (lastEnrollmentGrade >= 12)
                {
                    maxCredits = 20;
                }
                else
                {
                    maxCredits = 16;
                }
            }

            return maxCredits;
        }
        #endregion
    }
}
