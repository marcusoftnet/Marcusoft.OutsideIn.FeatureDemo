<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Feature>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Homepage of the feature lister
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Features not done</h2>
        <ul>
       <% foreach (var feature in Model){ %>
            <li>
            <%: feature.Name %> Status: <%: feature.Status %>
            </li>
        <% }  %>
       </ul>
</asp:Content>
