using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.MetaData;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Service;

namespace SystemGroup.General.UniversityManagement.Common
{
    [Serializable]
    [DetailOf(typeof(Enrollment), nameof(EnrollmentRef))]
    [SearchFields(nameof(Grade), nameof(GradeState))]
    partial class EnrollmentItem : Entity
    {

        #region Properties

        public string CourseTitleText { get; set; } 

        #endregion

        #region Methods

        public override void SetDefaultValues()
        {
            base.SetDefaultValues();

            GradeState = EnrollmentItemGradeState.NotEntered;
        }

        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new ReferenceColumnInfo(nameof(EnrollmentRef), "_"));
            columns.Add(new ReferenceColumnInfo(nameof(PresentationRef), "_"));
            columns.Add(new NumericColumnInfo(nameof(Grade), "EnrollmentItem_Grade", NumericType.Integer));
            columns.Add(new StateColumnInfo(nameof(GradeState), "EnrollmentItem_State", typeof(EnrollmentItemGradeState)));
        }

        public static void FillExtraProperties(IEnumerable<EnrollmentItem> list)
        {
            var enrollmentItems = list.ToList();
            var presentationIDs = enrollmentItems.Select(p => p.PresentationRef);

            var loadOptions = LoadOptions.With<Presentation>(p => p.Course);

            var idCourseTitleDictionary = ServiceFactory.Create<IPresentationBusiness>()
                .FetchAll(loadOptions)
                .Select(p => new { p.ID, CourseTitle = p.Course.Title })
                .Where(p => presentationIDs.Contains(p.ID))
                .ToDictionary(p => p.ID, p => new {  p.CourseTitle });

            foreach (var item in enrollmentItems)
            {
                var part = idCourseTitleDictionary[item.PresentationRef];
                item.CourseTitleText = part.CourseTitle;
            }
        }

        #endregion
    }
}
