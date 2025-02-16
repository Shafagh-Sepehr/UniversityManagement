using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Service;

namespace SystemGroup.General.UniversityManagement.Common
{
    [ServiceInterface]
    public interface IInstructorBusiness : IBusinessBase<Instructor>
    {
        [EntityView("AllInstructor", "Views_AllInstructors", typeof(InstructorProjection), nameof(Instructor.Name), IsDefaultView = true)]
        new IQueryable<Instructor> FetchAll();
    }
}
