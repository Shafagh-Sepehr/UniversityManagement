<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs"
    Inherits="SystemGroup.General.UniversityManagement.Web.StudentPages.Edit"
    Title="Student_Student" %>

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
                <div runat="server" id="dvMain">

                    <sg:SgFormView runat="server" id="fvwMain">
                        <EditItemTemplate>

                            <sg:SgFieldSet runat="server">
                                <sg:SgFieldLayout runat="server">

                                    <sg:sgtablerow runat="server">
                                        <sg:sgtablecell runat="server">
                                            <sg:SgFieldLabel runat="server" TextKey="Labels_Name" Required="True" />
                                        </sg:sgtablecell>
                                        <sg:sgtablecell runat="server">
                                            <sg:SgTextBox runat="server" ID="txtName" Text='<%# Bind("Name") %>' />
                                        </sg:sgtablecell>
                                        <sg:sgtablecell runat="server">
                                            <sg:SgRequiredFieldValidator runat="server" ControlToValidate="txtName" ErrorMessageKey="Messages_NameIsRequired" />
                                        </sg:sgtablecell>
                                    </sg:sgtablerow>

                                    <sg:SgTableRow runat="server">
                                        <sg:SgTableCell runat="server">
                                            <sg:SgFieldLabel runat="server" TextKey="Labels_Advisor" Required="true" />
                                        </sg:SgTableCell>
                                        <sg:SgTableCell runat="server">
                                            <sg:SgSelector runat="server" ID="sltAdvisor" ComponentName="SystemGroup.General.UniversityManagement"
                                                EntityName="Instructor" ViewName="AllInstructors" dbselectedid='<%# Bind("AdvisorRef") %>' />
                                        </sg:SgTableCell>
                                        <sg:SgTableCell runat="server">
                                            <sg:SgRequiredFieldValidator runat="server" ControlToValidate="sltAdvisor" ErrorMessageKey="Messages_AdvisorIsRequired" />
                                        </sg:SgTableCell>
                                    </sg:SgTableRow>

                                    <sg:SgTableRow runat="server">
                                        <sg:SgTableCell runat="server">
                                            <sg:SgFieldLabel runat="server" TextKey="Labels_TotalCredits" />
                                        </sg:SgTableCell>
                                        <sg:SgTableCell runat="server">
                                            <sg:SgNumericTextBox runat="server" ID="numTotalCredits" Enabled="False" DataType="System.Int32"
                                                        DbValue='<%# Bind("TotalCredits") %>' />
                                        </sg:SgTableCell>
                                        <sg:SgTableCell runat="server">
                                        </sg:SgTableCell>
                                    </sg:SgTableRow>

                                </sg:SgFieldLayout>
                            </sg:SgFieldSet>

                        </EditItemTemplate>
                    </sg:SgFormView>

                </div>
            </ContentTemplate>
        </sg:SgUpdatePanel>
    </form>
</body>
</html>
