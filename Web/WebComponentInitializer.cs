﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemGroup.Framework.Security;
using SystemGroup.Framework.Service;
using SystemGroup.General.UniversityManagement.Common;
using SystemGroup.Web;
using SystemGroup.Web.ApplicationServices;
using SystemGroup.Web.UI;
using SystemGroup.Web.UI.Shell;

namespace SystemGroup.General.UniversityManagement.Web
{
    public class WebComponentInitializer : WebComponentInitializerBase
    {
        #region Instructor EntityActions

        [AddNewEntityAction(typeof(Instructor))]
        public void NewInstructorAction()
        {
            SgShell.Show<InstructorPages.Edit>();
        }

        [ViewDetailEntityAction(typeof(Instructor))]
        public void EditInstructor(long[] ids)
        {
            foreach (var id in ids)
            {
                SgShell.Show<InstructorPages.Edit>($"id={id}");
            }
        }

        [DeleteEntityAction(typeof(Instructor))]
        public void DeleteInstructor(long[] ids)
        {
            ServiceFactory.Create<IInstructorBusiness>().Delete(ids);
        }

        #endregion

        #region Course EntityActions

        [AddNewEntityAction(typeof(Course))]
        public void NewCourseAction()
        {
            SgShell.Show<CoursePages.Edit>();
        }

        [ViewDetailEntityAction(typeof(Course))]
        public void EditCourse(long[] ids)
        {
            foreach (var id in ids)
            {
                SgShell.Show<CoursePages.Edit>($"id={id}");
            }
        }

        [DeleteEntityAction(typeof(Course))]
        public void DeleteCourse(long[] ids)
        {
            ServiceFactory.Create<ICourseBusiness>().Delete(ids);
        }

        #endregion

        #region Semester EntityActions

        [AddNewEntityAction(typeof(Semester))]
        public void NewSemesterAction()
        {
            SgShell.Show<SemesterPages.Edit>();
        }

        [ViewDetailEntityAction(typeof(Semester))]
        public void EditSemester(long[] ids)
        {
            foreach (var id in ids)
            {
                SgShell.Show<SemesterPages.Edit>($"id={id}");
            }
        }

        [DeleteEntityAction(typeof(Semester))]
        public void DeleteSemester(long[] ids)
        {
            ServiceFactory.Create<ISemesterBusiness>().Delete(ids);
        }

        #endregion

        #region Methods

        public override List<ComponentLink> RegisterLinks()
        {
            return new List<ComponentLink>
            {
                new ComponentLink("General", "s:Labels_General", null, null, 0, new[] {
                    new ComponentLink("University", "Links_UniversityManagement", null, null, 0, new[]
                    {
                        new ComponentLink("Lists", "Links_Lists", "~/Framework/UI/Shell/Shells/Next/Assets/MainMenuIcons/General/BaseData/Lists.svg", null ,0 , new[]
                        {

                            new ComponentLink("InstructorList", "Links_InstructorList", null , "~/List.aspx?ComponentName=SystemGroup.General.UniversityManagement&EntityName=Instructor"),
                            new ComponentLink("CourseList", "Links_CourseList", null , "~/List.aspx?ComponentName=SystemGroup.General.UniversityManagement&EntityName=Course"),
                            new ComponentLink("SemesterList", "Links_SemesterList", null , "~/List.aspx?ComponentName=SystemGroup.General.UniversityManagement&EntityName=Semester"),
                        }),

                        new ComponentLink("NewInstructor", "Links_NewInstructor", null, typeof(InstructorPages.Edit), 0),
                        new ComponentLink("NewCourse", "Links_NewCourse", null, typeof(CoursePages.Edit), 1),
                        new ComponentLink("NewSemester", "Links_NewSemester", null, typeof(SemesterPages.Edit), 2),
                    })
                })
            };
        }

        #endregion
    }
}
