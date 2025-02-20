using System.Web.UI;
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

        #endregion

        protected override void OnEntitySaving(object sender, EntitySavingEventArgs e)
        {
            base.OnEntitySaving(sender, e);

            SgLogger.Log($"**********************************************************************\n\nCapacity:{CurrentEntity.Capacity}\ncourseref:{CurrentEntity.CourseRef}\ninstref:{CurrentEntity.InstructorRef}\nsemester:{CurrentEntity.SemesterRef}\n\n**********************************************************************", "");
        }
    }
}