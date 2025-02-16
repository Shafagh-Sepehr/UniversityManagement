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
    public interface IStudentBusiness : IBusinessBase<Student>
    {
        [EntityView("AllStudent", "Views_AllStudents", typeof(StudentProjection), nameof(Student.Name), IsDefaultView = true)]
        new IQueryable<Student> FetchAll();
    }
}
