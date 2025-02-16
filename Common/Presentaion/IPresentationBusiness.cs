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
    public interface IPresentationBusiness : IBusinessBase<Presentation>
    {
        [EntityView("AllPresentation", "Views_AllPresentations", typeof(PresentationProjection), nameof(Presentation.CourseTitle), IsDefaultView = true)]
        IQueryable<Presentation> FetchAllPresentationsWithTitle();
    }
}
