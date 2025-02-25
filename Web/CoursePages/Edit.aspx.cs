using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.General.UniversityManagement.Common;
using SystemGroup.Web.UI;
using SystemGroup.Web.UI.Controls;
using Telerik.Web.UI;

namespace SystemGroup.General.UniversityManagement.Web.CoursePages
{
    public partial class Edit : SgEditorPage<Course>
    {
        #region Properties

        public override SgFormView FormView
        {
            get { return null; }
        }

        public override SgUpdatePanel UpdatePanel
        {
            get { return updMain; }
        }

        public override bool HasFormView
        {
            get
            {
                return false;
            }
        }

        public override Control MainContentContainer
        {
            get
            {
                return dvMain;
            }
        }

        public override DetailLoadOptions EntityLoadOptions
        {
            get
            {
                return LoadOptions
                    .With<Course>(c => c.Prerequisites)
                    .With<Prerequisite>(p => p.PrerequisiteCourse);
            }
        }

        protected override IEnumerable<string> ClientSideDetailDataSources
        {
            get
            {
                yield return ".Prerequisites";
            }
        }

        #endregion

        #region Methods

        protected override void OnEditorBinding(EditorBindingEventArgs<Course> e)
        {
            base.OnEditorBinding(e);

            e.Context.BindProperty(c => c.Title).To(txtTitle);
            e.Context.BindValueTypeProperty(c => c.Credits).To(lkpCredits);
        }

        protected override void OnEntityLoaded(object sender, EntityLoadedEventArgs e)
        {
            base.OnEntityLoaded(sender, e);

            Prerequisite.FillExtraProperties(CurrentEntity.Prerequisites);
        }

        protected void sltPrerequisite_itemsRequested(object sender, RadComboBoxItemsRequestedEventArgs args)
        {
            var slt = (SgSelector)sender;
            var ignoredIDs = ((IEnumerable)args.Context["IgnoredIDs"])
                .Cast<object>()
                .Select(Convert.ToInt64)
                .ToList();

            ignoredIDs.Add(CurrentEntity.ID);

            slt.FilterExpression = o => !ignoredIDs.Contains(((Entity)o).ID);
        }

        #endregion
    }
}