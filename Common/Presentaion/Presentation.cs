using System;
using System.Collections.Generic;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.MetaData;
using SystemGroup.Framework.MetaData.Mapping;

namespace SystemGroup.General.UniversityManagement.Common
{
    [Serializable]
    [Master(typeof(IPresentationBusiness))]
    [SearchFields(nameof(Capacity))]
    partial class Presentation : Entity
    {
        public override DetailLoadOptions DeleteLoadOptions
        {
            get
            {
                return LoadOptions.With<Presentation>(c => c.TimeSlots);
            }
        }

        #region Methods


        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new NumericColumnInfo(nameof(Capacity), "Presentation_Capacity", NumericType.Integer));
            columns.Add(new ReferenceColumnInfo(nameof(CourseRef), "_"));
            columns.Add(new ReferenceColumnInfo(nameof(SemesterRef), "_"));
            columns.Add(new ReferenceColumnInfo(nameof(InstructorRef), "_"));
        }

        #endregion
    }
}
