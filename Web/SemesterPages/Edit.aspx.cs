using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemGroup.General.UniversityManagement.Common;
using SystemGroup.Web.UI;
using SystemGroup.Web.UI.Controls;

namespace SystemGroup.General.UniversityManagement.Web.SemesterPages
{
    public partial class Edit : SgEditorPage<Semester>
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

        #endregion

        #region Methods

        protected override void OnEditorBinding(EditorBindingEventArgs<Semester> e)
        {
            base.OnEditorBinding(e);

            e.Context.BindValueTypeProperty(s=>s.Season).To(lkpSeason);
        }

        #endregion
    }
}