<%@ page language="C#" autoeventwireup="true" codebehind="Edit.aspx.cs"
    inherits="SystemGroup.General.UniversityManagement.Web.CoursePages.Edit"
    Title="Course_Course" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <sg:SgScriptManager runat="server" id="scriptManager">
            <Scripts>
                <asp:ScriptReference Path="Edit.js"/>
            </Scripts>
        </sg:SgScriptManager>
        <sg:sgupdatepanel runat="server" id="updMain">
            <contenttemplate>
                <div runat="server" id="dvMain">

                    <sg:sgfieldset runat="server">
                        <sg:sgfieldlayout runat="server">

                            <sg:sgtablerow runat="server">
                                <sg:sgtablecell runat="server">
                                    <sg:sgfieldlabel runat="server" textkey="Labels_Title" required="True" />
                                </sg:sgtablecell>
                                <sg:sgtablecell runat="server">
                                    <sg:SgTextBox runat="server" id="txtTitle" />
                                </sg:sgtablecell>
                                <sg:sgtablecell runat="server">
                                    <sg:sgrequiredfieldvalidator runat="server" controltovalidate="txtTitle" errormessage="Messages_TitleIsRequired" />
                                </sg:sgtablecell>
                            </sg:sgtablerow>


                            <sg:sgtablerow runat="server">
                                <sg:sgtablecell runat="server">
                                    <sg:sgfieldlabel runat="server" textkey="Labels_Credits" required="True" />
                                </sg:sgtablecell>
                                <sg:sgtablecell runat="server">
                                    <sg:sglookup runat="server" id="lkpCredits" lookuptype="CourseCredits" required="true" />
                                </sg:sgtablecell>
                                <sg:sgtablecell runat="server">
                                    <sg:sgrequiredfieldvalidator runat="server" controltovalidate="lkpCredits" errormessage="ErrorMessage" />
                                </sg:sgtablecell>
                            </sg:sgtablerow>

                        </sg:sgfieldlayout>
                    </sg:sgfieldset>

                    <sg:SgGrid runat="server" GridType="ClientSide"
                        AllowScroll="True" AllowInsert="True"
                        AllowEdit="True" AllowDelete="True"
                        DataSourceID=".Prerequisites" Width="800px"
                        ID="grdPrerequisites" ValidationGroup="vgGrid">
                        <Columns>

                            <sg:SgSelectorGridColumn PropertyName="PrerequisiteTitle" headertext="Prerequisite_PrerequisitesTitle"> 
                                <EditItemTemplate>
                                    <sg:SgSelector ID="sltPrerequisite" runat="server" Width="800px"
                                        ComponentName="SystemGroup.General.UniversityManagement"
                                        EntityName="Course" ViewName="AllCourse"
                                        OnClientSelectedIndexChanged="sltPrerequisite_selectedIndexChanged"
                                        OnClientItemsRequesting="sltPrerequisite_itemsRequesting"
                                        OnItemsRequested="sltPrerequisite_itemsRequested"
                                        CbSelectedID="{binding PrerequisiteRef}">
                                        <Properties>
                                            <sg:SgSelectorProperty Name="Title" ClientSide="True" />
                                        </Properties>
                                    </sg:SgSelector>
                                    <sg:SgRequiredFieldValidator runat="server" ControlToValidate="sltPrerequisite" 
                                        ErrorMessageKey="Messages_PrerequisiteIsrequired" ValidationGroup="vgGrid" />

                                </EditItemTemplate>
                            </sg:SgSelectorGridColumn>

                        </Columns>
                    </sg:SgGrid>

                </div>
            </contenttemplate>
        </sg:sgupdatepanel>
    </form>
</body>
</html>
