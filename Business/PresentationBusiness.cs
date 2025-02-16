using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Eventing;
using SystemGroup.Framework.Exceptions;
using SystemGroup.Framework.Localization;
using SystemGroup.Framework.Service;
using SystemGroup.Framework.Service.Attributes;
using SystemGroup.General.UniversityManagement.Common;


namespace SystemGroup.General.UniversityManagement.Business
{
    [Service]
    public class PresentationBusiness : BusinessBase<Presentation>, IPresentationBusiness
    {
        public IQueryable<Presentation> FetchAllPresentationsWithTitle()
        {
            var courses = ServiceFactory.Create<ICourseBusiness>().FetchAll();
            var presentations = FetchAll();

            var presentationsTitlePair= from presentation in presentations
                                           join course in courses
                                               on presentation.CourseRef equals course.ID
                                           select new
                                           {
                                               presentation,
                                               course.Title,
                                           };


            foreach (var pair in presentationsTitlePair)
            {
                pair.presentation.CourseTitle = pair.Title;
            }

            return presentationsTitlePair.Select( p => p.presentation);
        }
    }
}
