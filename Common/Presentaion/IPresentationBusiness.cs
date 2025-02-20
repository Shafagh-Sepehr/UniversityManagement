using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Service;

namespace SystemGroup.General.UniversityManagement.Common
{
    [ServiceInterface]
    public interface IPresentationBusiness : IBusinessBase<Presentation>
    {
        [EntityView("AllPresentations", "Views_AllPresentations", typeof(PresentationProjection), "CourseTitle", IsDefaultView = true)]
        new IQueryable<Presentation> FetchAll();
    }
}
