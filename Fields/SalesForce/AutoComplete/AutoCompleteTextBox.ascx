<%@ Control %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sf" %>

<sf:ResourceLinks id="resourcesLinks" runat="server">
   <sf:ResourceFile JavaScriptLibrary="JQueryUI"/>
   <sf:ResourceFile Name="SalesForce.Fields.Fields.SalesForce.AutoComplete.Style.css" AssemblyInfo="SalesForce.Fields.Fields.SalesForce.AutoComplete.AutoCompleteTextBox, SalesForce.Fields" Static="true"></sf:ResourceFile>
</sf:ResourceLinks>


<sf:SitefinityLabel ID="titleLabel" ClientMode="AutoID" runat="server" CssClass="sfTxtLbl" Visible="true"/>
<asp:Textbox id="fieldBox" runat="server" ClientMode="AutoID" WrapperTagName="div" HideIfNoText="false" CssClass="sfTxt"></asp:Textbox>
<sf:SitefinityLabel id="descriptionLabel" ClientMode="AutoID" runat="server" WrapperTagName="div" HideIfNoText="true" CssClass="sfDescription" />
<sf:SitefinityLabel ID="exampleLabel" ClientMode="AutoID" runat="server" HideIfNoText="true" CssClass="sfTxtLbl" />
<sf:SitefinityLabel ID="salesforcefieldsLabel" Visible="false" ClientMode="AutoID" runat="server" CssClass="sfTxtLbl" />
<sf:SitefinityLabel ID="contactfieldsLabel" Visible="false" ClientMode="AutoID" runat="server" CssClass="sfTxtLbl" />
<sf:SitefinityLabel ID="salesforcefieldtypeLabel" Visible="false" ClientMode="AutoID" runat="server" CssClass="sfTxtLbl" />
<sf:SitefinityLabel ID="autoCompleteLabel" ClientMode="AutoID"  Visible="false" runat="server" CssClass="sfTxtLbl" />

