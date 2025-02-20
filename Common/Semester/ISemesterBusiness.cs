using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Service;

namespace SystemGroup.General.UniversityManagement.Common
{
    [ServiceInterface]
    public interface ISemesterBusiness : IBusinessBase<Semester>
    {
        [EntityView("AllSemesters", "Views_AllSemesters", typeof(SemesterProjection), nameof(Semester.Year), IsDefaultView = true)]
        new IQueryable<Semester> FetchAll();
    }
}
