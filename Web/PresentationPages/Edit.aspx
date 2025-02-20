﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs"
    Inherits="SystemGroup.General.UniversityManagement.Web.PresentationPages.Edit"
    Title="Presentation_Presentation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <sg:SgScriptManager runat="server" ID="scriptManager"></sg:SgScriptManager>
        <sg:SgUpdatePanel runat="server" ID="updMain">
            <ContentTemplate>

                <sg:SgFormView runat="server" ID="formView">
                    <EditItemTemplate>
                        <sg:SgFieldSet runat="server">
                            <sg:SgMultiColumnLayout runat="server">
                                <sg:SgTableRow runat="server">
                                    <sg:SgTableCell runat="server">
                                        <sg:SgFieldLayout runat="server">

                                            <sg:SgTableRow runat="server">
                                                <sg:SgTableCell runat="server">
                                                    <sg:SgFieldLabel runat="server" TextKey="Labels_Course" Required="true" />
                                                </sg:SgTableCell>
                                                <sg:SgTableCell runat="server">
                                                    <sg:SgSelector runat="server" ID="sltCourse" ComponentName="SystemGroup.General.UniversityManagement"
                                                        EntityName="Course" ViewName="AllCourses" DbSelectedID='<%# Bind("CourseRef") %>' />
                                                </sg:SgTableCell>
                                                <sg:SgTableCell runat="server">
                                                    <sg:SgRequiredFieldValidator runat="server" ControlToValidate="sltCourse"
                                                        ErrorMessageKey="Messages_CourseIsRequired" />
                                                </sg:SgTableCell>
                                            </sg:SgTableRow>

                                            <sg:SgTableRow runat="server">
                                                <sg:SgTableCell runat="server">
                                                    <sg:SgFieldLabel runat="server" TextKey="Labels_Instructor" Required="true" />
                                                </sg:SgTableCell>
                                                <sg:SgTableCell runat="server">
                                                    <sg:SgSelector runat="server" ID="sltInstructor" ComponentName="SystemGroup.General.UniversityManagement"
                                                        EntityName="Instructor" ViewName="AllInstructors" DbSelectedID='<%# Bind("InstructorRef") %>' />
                                                </sg:SgTableCell>
                                                <sg:SgTableCell runat="server">
                                                    <sg:SgRequiredFieldValidator runat="server" ControlToValidate="sltInstructor"
                                                        ErrorMessageKey="Messages_InstructorIsRequired" />
                                                </sg:SgTableCell>
                                            </sg:SgTableRow>

                                        </sg:SgFieldLayout>
                                    </sg:SgTableCell>
                                    <sg:SgTableCell runat="server">
                                        <sg:SgFieldLayout runat="server">

                                            <sg:SgTableRow runat="server">
                                                <sg:SgTableCell runat="server">
                                                    <sg:SgFieldLabel runat="server" TextKey="Labels_Semester" Required="true" />
                                                </sg:SgTableCell>
                                                <sg:SgTableCell runat="server">
                                                    <sg:SgSelector runat="server" ID="sltSemester" ComponentName="SystemGroup.General.UniversityManagement"
                                                        EntityName="Semester" ViewName="UnstartedSemesters" DbSelectedID='<%# Bind("SemesterRef") %>' />
                                                </sg:SgTableCell>
                                                <sg:SgTableCell runat="server">
                                                    <sg:SgRequiredFieldValidator runat="server" ControlToValidate="sltSemester"
                                                        ErrorMessageKey="Messages_SemesterIsRequired" />
                                                </sg:SgTableCell>
                                            </sg:SgTableRow>

                                            <sg:SgTableRow runat="server">
                                                <sg:SgTableCell runat="server">
                                                    <sg:SgFieldLabel runat="server" TextKey="Labels_Capacity" Required="true" />
                                                </sg:SgTableCell>
                                                <sg:SgTableCell runat="server">
                                                    <sg:SgNumericTextBox runat="server" ID="numCapacity" DataType="System.Int32"
                                                        DbValue='<%# Bind("Capacity") %>' />
                                                </sg:SgTableCell>
                                                <sg:SgTableCell runat="server">
                                                    <sg:SgRequiredFieldValidator runat="server" ControlToValidate="numCapacity"
                                                        ErrorMessageKey="Messages_CapacityIsRequired" />
                                                </sg:SgTableCell>
                                            </sg:SgTableRow>

                                        </sg:SgFieldLayout>
                                    </sg:SgTableCell>
                                </sg:SgTableRow>
                            </sg:SgMultiColumnLayout>
                        </sg:SgFieldSet>
                    </EditItemTemplate>
                </sg:SgFormView>
            </ContentTemplate>
        </sg:SgUpdatePanel>
    </form>
</body>
</html>
