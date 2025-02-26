using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Service;

namespace SystemGroup.General.UniversityManagement.Common
{
    [ServiceInterface]
    public interface ISemesterBusiness : IBusinessBase<Semester>
    {
        [EntityView("AllSemesters", "Views_AllSemesters", typeof(SemesterProjection), "SemesterTime", IsDefaultView = true)]
        new IQueryable<Semester> FetchAll();

        [EntityView("UnstartedSemesters", "Views_UnstartedSemesters", typeof(SemesterProjection), "SemesterTime")]
        IQueryable<Semester> FetchAllUnstartedSemesters();
    }
}
