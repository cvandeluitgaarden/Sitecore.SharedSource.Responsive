<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Column.ascx.cs" Inherits="Sitecore.SharedSource.Responsive.Demo.Sublayouts.Column" %>
<%@ Register TagPrefix="r" Namespace="Sitecore.SharedSource.Responsive.WebControls" Assembly="Sitecore.SharedSource.Responsive" %> 


<div class="columns <%= Sitecore.SharedSource.Responsive.RenderingHelper.ResponsiveClasses(this) %>">
    <r:EditorLabel runat="server" ID="label"/>
</div>