using System;
using System.Collections.Generic;
using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Localization;
using SystemGroup.Framework.MetaData;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Service;

namespace SystemGroup.General.UniversityManagement.Common
{
    [Serializable]
    [Master(typeof(IEnrollmentBusiness))]
    [SearchFields]
    partial class Enrollment : Entity
    {

        #region Properties

        public override DetailLoadOptions DeleteLoadOptions
        {
            get
            {
                return LoadOptions.With<Enrollment>(i => i.EnrollmentItems);
            }
        }

        #endregion

        #region Methods

        public override void SetDefaultValues()
        {
            base.SetDefaultValues();

            SemesterRef = ServiceFactory.Create<ISemesterBusiness>()
                .FetchAll()
                .Where(s => s.State == SemesterState.EnrollmentPhase)
                .Select(s => s.ID)
                .SingleOrDefault();

            if (SemesterRef == 0)
            {
                throw this.CreateException("Messages_EnrollmentPhaseHasNotBegun");
            }
        }

        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new ReferenceColumnInfo(nameof(StudentRef), "_"));
            columns.Add(new ReferenceColumnInfo(nameof(SemesterRef), "_"));
        }

        #endregion
    }
}
