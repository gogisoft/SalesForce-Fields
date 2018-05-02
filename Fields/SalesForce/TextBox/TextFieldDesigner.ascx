<%@ Control %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sfFields" Namespace="Telerik.Sitefinity.Web.UI.Fields" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Modules.Forms.Web.UI.Fields" TagPrefix="sfForms" %>

<sitefinity:ResourceLinks ID="resourcesLinks" runat="server">
    <sitefinity:ResourceFile Name="Styles/Ajax.css" />
</sitefinity:ResourceLinks>
<div id="designerLayoutRoot" class="sfContentViews sfSingleContentView" style="max-height: 400px; overflow: auto; ">
<ol>        
    <li class="sfFormCtrl">
    <asp:Label runat="server" AssociatedControlID="Title" CssClass="sfTxtLbl">Title</asp:Label>
    <asp:TextBox ID="Title" runat="server" CssClass="sfTxt" />
    <div class="sfExample"></div>
    </li>
    
    <li class="sfFormCtrl">
    <asp:Label runat="server" AssociatedControlID="Description" CssClass="sfTxtLbl">Description</asp:Label>
    <asp:TextBox ID="Description" runat="server" CssClass="sfTxt" />
    <div class="sfExample"></div>
    </li>
    
    <li class="sfFormCtrl">
    <asp:Label runat="server" AssociatedControlID="Example" CssClass="sfTxtLbl">Example</asp:Label>
    <asp:TextBox ID="Example" runat="server" CssClass="sfTxt" />
    <div class="sfExample"></div>
    </li>

    <li class="sfFormCtrl">
    <asp:Label runat="server" AssociatedControlID="SalesForceFieldType" CssClass="sfTxtLbl">SalesForce Field Type</asp:Label>
    <asp:DropDownList ID="SalesForceFieldType" runat="server" CssClass="sfTxt" />
    <div class="sfExample"></div>
    </li>
    
    <li class="sfFormCtrl">
    <asp:Label runat="server" AssociatedControlID="SalesForceField" CssClass="sfTxtLbl">SalesForce Fields</asp:Label>
    <asp:DropDownList ID="SalesForceField" runat="server" CssClass="sfTxt" />
    <div class="sfExample"></div>
    </li>
    
    <li class="sfFormCtrl">
    <asp:Label runat="server" AssociatedControlID="Note" CssClass="sfTxtLbl">Note</asp:Label>
    <asp:TextBox ID="Note" runat="server" CssClass="sfTxt" TextMode="MultiLine" />
    <div class="sfExample"></div>
    </li>
    
</ol>
<sfForms:MetaFieldNameTextBox runat="server" id="metaFieldNameTextBox"></sfForms:MetaFieldNameTextBox>
</div>
