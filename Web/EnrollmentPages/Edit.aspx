<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs"
    Inherits="SystemGroup.General.UniversityManagement.Web.EnrollmentPages.Edit"
    Title="Enrollment_Enrollment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <sg:SgScriptManager runat="server" ID="scriptManager">
            <Scripts>
                <asp:ScriptReference Path="Edit.js" />
            </Scripts>
        </sg:SgScriptManager>
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
                                                    <sg:SgFieldLabel runat="server" TextKey="Labels_Student" Required="True" />
                                                </sg:SgTableCell>
                                                <sg:SgTableCell runat="server">
                                                    <sg:SgSelector runat="server" ID="sltStudent"
                                                        ComponentName="SystemGroup.General.UniversityManagement"
                                                        OnClientSelectedIndexChanged="sltStudent_selectedIndexChanged"
                                                        EntityName="Student" ViewName="NotEnrolledStudents" DbSelectedID='<%# Bind("StudentRef") %>' />
                                                </sg:SgTableCell>
                                                <sg:SgTableCell runat="server">
                                                    <sg:SgRequiredFieldValidator runat="server"
                                                        ControlToValidate="sltStudent" ErrorMessageKey="Messages_StudentIsRequired" />
                                                </sg:SgTableCell>
                                            </sg:SgTableRow>

                                        </sg:SgFieldLayout>
                                    </sg:SgTableCell>
                                    <sg:SgTableCell runat="server">
                                        <sg:SgFieldLayout runat="server">

                                            <sg:SgTableRow runat="server">
                                                <sg:SgTableCell runat="server">
                                                    <sg:SgFieldLabel runat="server" TextKey="Labels_Semester" />
                                                </sg:SgTableCell>
                                                <sg:SgTableCell runat="server">
                                                    <sg:SgSelector runat="server" ID="sltSemester"
                                                        ComponentName="SystemGroup.General.UniversityManagement"
                                                        Enabled="False"
                                                        EntityName="Semester" ViewName="UnstartedSemesters" DbSelectedID='<%# Bind("SemesterRef") %>' />
                                                </sg:SgTableCell>
                                                <sg:SgTableCell runat="server">
                                                </sg:SgTableCell>
                                            </sg:SgTableRow>

                                        </sg:SgFieldLayout>
                                    </sg:SgTableCell>
                                </sg:SgTableRow>
                            </sg:SgMultiColumnLayout>
                        </sg:SgFieldSet>

                        <sg:SgGrid runat="server" GridType="ClientSide"
                            AllowInsert="True" AllowEdit="True"
                            AllowDelete="True" AllowScroll="True"
                            DataSourceID=".EnrollmentItems" Width="800px"
                            ID="grdEnrollmentItems" ValidationGroup="vgGrid">
                            <Columns>
                                <sg:SgSelectorGridColumn PropertyName="CourseTitleText" headertext="Labels_Presentation">
                                    <EditItemTemplate>
                                        <sg:SgSelector ID="sltPresentation" runat="server"
                                            ComponentName="SystemGroup.General.UniversityManagement"
                                            EntityName="Presentation" ViewName="AllowedPresentationsForStudentInThisSemester"
                                            OnClientSelectedIndexChanged="sltPresentation_selectedIndexChanged"
                                            OnClientItemsRequesting="sltPresentation_itemsRequesting"
                                            OnItemsRequested="sltPresentation_ItemsRequested"
                                            CbSelectedID="{binding PresentationRef}">
                                            <Properties>
                                                <sg:SgSelectorProperty Name="CourseTitle" ClientSide="True" />
                                            </Properties>
                                            <viewparameters>
                                                <sg:sgviewparameter name="studentRef" />
                                            </viewparameters>
                                        </sg:SgSelector>
                                        <sg:SgRequiredFieldValidator runat="server" ControlToValidate="sltPresentation"
                                            ErrorMessageKey="Messages_PresentationIsrequired" ValidationGroup="vgGrid" />

                                    </EditItemTemplate>
                                </sg:SgSelectorGridColumn>
                                <sg:SgNumericGridColumn PropertyName="Grade" HeaderText="Labels_Grade">
                                    <EditItemTemplate>
                                        <sg:SgNumericTextBox runat="server" ID="numGrade" DataType="System.Single"
                                            MinValue="0" MaxValue="20"
                                            CbValue="{binding Grade}" />
                                    </EditItemTemplate>
                                </sg:SgNumericGridColumn>

                                <sg:SgSelectorGridColumn PropertyName="GradeState" HeaderText="Labels_GradeState">
                                    <EditItemTemplate>
                                    <sg:SgStateSelector runat="server" ID="sltGradeState"
                                        ComponentName="SystemGroup.General.UniversityManagement"
                                        EntityName="EnrollmentItem" CbSelectedCode="{binding GradeState}" />
                                    </EditItemTemplate>
                                </sg:SgSelectorGridColumn>

                            </Columns>
                        </sg:SgGrid>

                    </EditItemTemplate>
                </sg:SgFormView>
            </ContentTemplate>
        </sg:SgUpdatePanel>
    </form>
</body>
</html>
