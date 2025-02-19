using System.Collections.Generic;
using SystemGroup.Framework.Security;

namespace SystemGroup.General.UniversityManagement.Common
{
    internal class LogicalResources : ILogicalResourceDeclarator
    {
        public void DeclareLogicalResourceTree(IList<LogicalResourceTreeNode> list)
        {
            var res = new LogicalResourceCategory("MyCategory", " Labels_University", new LogicalResourceTreeNode[]
            {
                new CompositeLogicalResource("EducationalAdministrator", "Labels_EducationalAdministrator"),
                new CompositeLogicalResource("Student", "Labels_Student"),
                new CompositeLogicalResource("Instructor", "Labels_Instructor"),
            });
            list.Add(res);
        }
    }
}
