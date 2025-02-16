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
    public interface IInstructorBusiness : IBusinessBase<Instructor>
    {
        [EntityView("AllInstructor", "Views_AllInstructors", typeof(InstructorProjection), "Name", IsDefaultView = true)]
        new IQueryable<Instructor> FetchAll();
    }
}
