using System.Collections.Generic;
using System.Web.UI;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Logging;
using SystemGroup.General.UniversityManagement.Common;
using SystemGroup.Web.UI;
using SystemGroup.Web.UI.Controls;

namespace SystemGroup.General.UniversityManagement.Web.PresentationPages
{
    public partial class Edit : SgEditorPage<Presentation>
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
                    .With<Presentation>(p => p.TimeSlots);
            }
        }

        protected override IEnumerable<string> ClientSideDetailDataSources
        {
            get
            {
                yield return ".TimeSlots";
            }
        }

        #endregion

        #region Methods

        protected override void OnEntityLoaded(object sender, EntityLoadedEventArgs e)
        {
            base.OnEntityLoaded(sender, e);

            TimeSlot.FillExtraProperties(CurrentEntity.TimeSlots);
        }

        #endregion


    }
}