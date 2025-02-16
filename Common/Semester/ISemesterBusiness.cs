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
    public interface ISemesterBusiness : IBusinessBase<Semester>
    {
        [EntityView("AllSemester", "Views_AllSemesters", typeof(SemesterProjection), "Year", IsDefaultView = true)]
        new IQueryable<Semester> FetchAll();
    }
}
