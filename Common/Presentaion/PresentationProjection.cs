using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Common;

namespace SystemGroup.General.UniversityManagement.Common
{
    public class PresentationProjection : EntityProjection<Presentation>
    {
        #region Methods

        public override IQueryable Project(IQueryable<Presentation> inputs)
        {
            return from input in inputs
                   select input;

        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            //columns.Add(new TextColumnInfo("Field1", "Presentaion_Field1"));
        }

        #endregion
    }
}
