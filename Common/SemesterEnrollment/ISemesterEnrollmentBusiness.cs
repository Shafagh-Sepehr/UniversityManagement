using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Security;
using SystemGroup.Framework.Service;

namespace SystemGroup.General.UniversityManagement.Common
{
    [ServiceInterface]
    public interface ISemesterEnrollmentBusiness : IBusinessBase<SemesterEnrollment>
    {
        [EntityView("AllSemesterEnrollment", "Views_AllSemesterEnrollment", typeof(SemesterEnrollmentProjection), "Name", IsDefaultView = true)]
        new IQueryable<SemesterEnrollment> FetchAll();
    }
}
