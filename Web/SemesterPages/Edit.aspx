<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs"
    Inherits="SystemGroup.General.UniversityManagement.Web.SemesterPages.Edit" %>

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

                            <sg:SgTableRow runat="server">
                                <sg:SgTableCell runat="server">
                                    <sg:SgFieldLabel runat="server" TextKey="Semester_Season" Required="true" />
                                </sg:SgTableCell>
                                <sg:SgTableCell runat="server">
                                    <sg:SgLookup runat="server" ID="lkpSeason" LookupType="SemesterSeason" DbSelectedCode="<%# Bind("Season") %>" />
                                </sg:SgTableCell>
                                <sg:SgTableCell runat="server">
                                    <sg:SgRequiredFieldValidator runat="server" ControlToValidate="lkpSeason" ErrorMessageKey="Messages_SemesterSeasonIsRequired" />
                                </sg:SgTableCell>
                            </sg:SgTableRow>

                        </sg:SgFieldLayout>
                    </sg:SgFieldSet>

                </div>
            </ContentTemplate>
        </sg:SgUpdatePanel>
    </form>
</body>
</html>
