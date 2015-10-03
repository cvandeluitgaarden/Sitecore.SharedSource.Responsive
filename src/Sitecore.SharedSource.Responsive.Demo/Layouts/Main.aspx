<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Sitecore.SharedSource.Responsive.Demo.Layouts.Main" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %> 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="row">
        <sc:Placeholder runat="server" Key="phMain" />
    </div>
    </form>
        <script src="~/Scripts/foundation/foundation.js"></script>
    <script>
    $(document).foundation();
    </script>
</body>
</html>
