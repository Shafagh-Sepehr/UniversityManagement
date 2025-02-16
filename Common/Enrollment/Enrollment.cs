using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Lookup;
using SystemGroup.Framework.MetaData;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Service;
using SystemGroup.Framework.StateManagement;

namespace SystemGroup.General.UniversityManagement.Common
{
    [Serializable]
    [Master(typeof(IEnrollmentBusiness))]
    [SearchFields("Year")] //TODO check if this works
    partial class Enrollment : Entity
    {
        #region Methods

        public override DetailLoadOptions DeleteLoadOptions
        {
            get
            {
                return LoadOptions.With<Enrollment>(i => i.EnrollmentItems);
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
