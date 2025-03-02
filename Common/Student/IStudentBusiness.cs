using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Service;

namespace SystemGroup.General.UniversityManagement.Common
{
    [ServiceInterface]
    public interface IStudentBusiness : IBusinessBase<Student>
    {
        [EntityView("AllStudents", "Views_AllStudents", typeof(StudentProjection), nameof(Student.Name), IsDefaultView = true)]
        new IQueryable<Student> FetchAll();

        [EntityView("NotEnrolledStudents", "Views_NotEnrolledStudents", typeof(StudentProjection), nameof(Student.Name))]
        IQueryable<Student> FetchNotEnrolledStudents();
    }
}
