﻿using System;
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
    public interface IEnrollmentBusiness : IBusinessBase<Enrollment>
    {
        [EntityView("AllEnrollment", "Views_AllEnrollments", typeof(EnrollmentProjection), "Year", IsDefaultView = true)]
        new IQueryable<Enrollment> FetchAll();
    }
}