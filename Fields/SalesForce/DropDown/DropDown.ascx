<%@ Control %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sf" %>

<asp:Label ID="titleLabel" runat="server" CssClass="sfTxtLbl" />
<asp:DropDownList ID="fieldDropDown" runat="server" CssClass="sfTxt" />
<sf:SitefinityLabel id="descriptionLabel" runat="server" WrapperTagName="div" HideIfNoText="true" CssClass="sfDescription" />
<sf:SitefinityLabel id="exampleLabel" runat="server" WrapperTagName="div" HideIfNoText="true" CssClass="sfExample" />
<sf:SitefinityLabel ID="salesforcefieldsLabel" Visible="false" ClientMode="AutoID" runat="server" CssClass="sfTxtLbl" />
<sf:SitefinityLabel ID="contactfieldsLabel" Visible="false" ClientMode="AutoID" runat="server" CssClass="sfTxtLbl" />
<sf:SitefinityLabel ID="salesforcefieldtypeLabel" Visible="false" ClientMode="AutoID" runat="server" CssClass="sfTxtLbl" />

