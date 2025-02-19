using System;
using System.Collections.Generic;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Eventing;
using SystemGroup.Framework.Host;
using SystemGroup.Framework.Logging;
using SystemGroup.Framework.Service;
using SystemGroup.Framework.Utilities;
using SystemGroup.General.UniversityManagement.Common;


namespace SystemGroup.General.UniversityManagement.Business
{
    [Service]
    public class CourseBusiness : BusinessBase<Course>, ICourseBusiness
    {
        [SubscribeTo(typeof(IHostService), nameof(IHostService.HostStarted))]
        private void OnHostStarted(object s, EventArgs e)
        {
            BusinessValidationProvider.RegisterValidator(new CourseBusinessValidator());
        }
    }
}
