<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Feature>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Homepage of the feature lister
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Features not done</h2>
        <%:Html.ActionLink("Show done items", "Index", new {showDoneItems = true})%>
        <br />
        <% using (Html.BeginForm() ){%>
        Namefilter:<%:Html.TextBox("Filter")%>  <input type="submit" id="Search" value="Search" />
        <%}%>
        <br />
        <h2>Features</h2>
        <ul>
       <% foreach (var feature in Model){ %>
            <li>
            Name: <%: feature.Name %>, Status: <%: feature.Status %>
            </li>
        <% }  %>
       </ul>
</asp:Content>
