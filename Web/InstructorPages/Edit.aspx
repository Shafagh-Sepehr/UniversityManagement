<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="SystemGroup.General.UniversityManagement.Web.InstructorPages.Edit" %>

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
                    <sg:SgFieldSet runat="server">
                        <sg:SgFieldLayout runat="server">


                            <sg:sgtablerow runat="server">
                                <sg:sgtablecell runat="server">
                                    <sg:SgFieldLabel runat="server" TextKey="Labels_Instructor" Required="True"/>
                                </sg:sgtablecell>
                                <sg:sgtablecell runat="server">
                                    <sg:SgTextBox runat="server" ID="txtName"/>
                                </sg:sgtablecell>
                                <sg:sgtablecell runat="server">
                                    <sg:SgRequiredFieldValidator runat="server" ControlToValidate="txtName" ErrorMessageKey="Messages_NameIsRequired"/>
                                </sg:sgtablecell>
                            </sg:sgtablerow>


                        </sg:SgFieldLayout>
                    </sg:SgFieldSet>
                </div>
            </ContentTemplate> 
        </sg:SgUpdatePanel>
    </form>
</body>
</html>
