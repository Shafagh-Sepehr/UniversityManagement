using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.MetaData;
using SystemGroup.Framework.Service;
using SystemGroup.Framework.Utilities;

namespace SystemGroup.General.UniversityManagement.Common
{
    [Serializable]
    [DetailOf(typeof(Course), nameof(CourseRef))]
    //[SearchFields] TODO check if this throws exception
    partial class Prerequisite : Entity
    {
        #region Properties

        public string PrerequisiteTitle { get; set; }

        #endregion

        #region Methods

        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);
            
            columns.Add(new ReferenceColumnInfo(nameof(CourseRef), "_"));
            columns.Add(new ReferenceColumnInfo(nameof(PrerequisiteRef), "_"));
        }

        #endregion

        public static void FillExtraProperties(EntitySet<Prerequisite> list)
        {
            var prerequisites = list.ToList();
            var prerequisiteIDs = prerequisites.Select(p => p.PrerequisiteRef);
            var courseIDTitleDictionary = ServiceFactory.Create<ICourseBusiness>()
                .FetchAll()
                .Select(c => new { c.ID, c.Title })
                .Where(c => prerequisiteIDs.Contains(c.ID))
                .ToDictionary(c => c.ID, c => new { c.Title });

            foreach (var prerequisite in prerequisites)
            {
                prerequisite.PrerequisiteTitle = courseIDTitleDictionary[prerequisite.PrerequisiteRef].Title;
            }

        }
    }
}
    