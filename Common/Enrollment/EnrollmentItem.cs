﻿using System;
using System.Collections.Generic;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.MetaData;
using SystemGroup.Framework.MetaData.Mapping;

namespace SystemGroup.General.UniversityManagement.Common
{
    [Serializable]
    [DetailOf(typeof(Enrollment), nameof(EnrollmentRef))]
    [SearchFields(nameof(Grade), nameof(GradeState))]
    partial class EnrollmentItem : Entity
    {
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

        #endregion
    }
}
