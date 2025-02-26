using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Localization;
using SystemGroup.General.UniversityManagement.Common;
using SystemGroup.Web.UI;
using SystemGroup.Web.UI.Controls;
using Telerik.Web.UI;

namespace SystemGroup.General.UniversityManagement.Web.EnrollmentPages
{
    public partial class Edit : SgEditorPage<Enrollment>
    {
        #region Properties

        public override SgFormView FormView
        {
            get { return formView; }
        }

        public override SgUpdatePanel UpdatePanel
        {
            get { return updMain; }
        }

        public override DetailLoadOptions EntityLoadOptions
        {
            get
            {
                return LoadOptions
                    .With<Enrollment>(e => e.EnrollmentItems)/*
                    .With <EnrollmentItem>(ei => ei.Presentation)*/;
            }
        }

        protected override IEnumerable<string> ClientSideDetailDataSources
        {
            get
            {
                yield return ".EnrollmentItems";
            }
        }

        #endregion

        protected override void OnEntityLoaded(object sender, EntityLoadedEventArgs e)
        {
            base.OnEntityLoaded(sender, e);

            EnrollmentItem.FillExtraProperties(CurrentEntity.EnrollmentItems);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var ds = FindDataSource(".EnrollmentItems");
            ds.OnClientInsertedEntity = "ds_insertedEntity";
            ds.OnClientRemovedEntity = "ds_removedEntity";
        }

        protected void sltPresentation_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs args)
        {
            //if ((bool)args.Context["StudentNotSelected"])
            //{
            //    throw this.CreateException("Student_Student");
            //}

            var slt = (SgSelector)sender;
            var ignoredIDs = ((IEnumerable)args.Context["IgnoredIDs"])
                .Cast<object>()
                .Select(Convert.ToInt64)
                .ToList();

            slt.FilterExpression = o => !ignoredIDs.Contains(((Entity)o).ID);
            slt.ViewParameters.First(v => v.Name == "studentRef").Value = Convert.ToInt64(args.Context["StudentRef"]);
        }
    }
}