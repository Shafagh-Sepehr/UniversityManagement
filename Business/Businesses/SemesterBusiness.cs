using System;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Eventing;
using SystemGroup.Framework.Host;
using SystemGroup.Framework.Service;
using SystemGroup.General.UniversityManagement.Common;


namespace SystemGroup.General.UniversityManagement.Business
{
    [Service]
    public class SemesterBusiness : BusinessBase<Semester>, ISemesterBusiness
    {
        [SubscribeTo(typeof(IHostService), nameof(IHostService.HostStarted))]
        private void OnHostStarted(object s, EventArgs e)
        {
            BusinessValidationProvider.RegisterValidator(new SemesterBusinessValidator());
        }
    }
}
