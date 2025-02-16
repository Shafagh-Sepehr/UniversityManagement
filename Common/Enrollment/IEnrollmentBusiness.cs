using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.MetaData.Mapping;
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