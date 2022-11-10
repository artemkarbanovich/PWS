<%@ Page Title="Home Page" Language="C#" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> - My ASP.NET Application</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

</head>
<body>
    <form runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>

        <script>
            function getNotes() {
                $.ajax({
                    url: `http://localhost:8733/Design_Time_Addresses/lab_7_feed/Feed1/`,
                    type: "GET",
                    dataType: "xml",
                    contentType: "application/json; charset=utf-8",
                    //data: data,
                    success: xmlParser,
                    error: error => console.log(error)
                });
            }

            function xmlParser(xml) {
                $(".main").empty();
                let content = '';
                content += `
                <div class="item">
                    <table border="1" cellpadding="5">
                        <tr>
                            <th>subj</th>
                            <th>description</th>
                        </tr>
            `;
                $(xml).find("item").each(function () {
                    content += `
                    <tr>
                        <td width="100px">
                            ${$(this).find("title").text()}
                        </td>
                        <td>
                            ${$(this).find("description").text()}
                        </td>
                    </tr>
                `;
                });
                content += `
                    </table>
                </div>
            `;
                $(".main").append(content);
            }
            function getNotes1() {

                $.ajax({
                    url: `http://localhost:8733/Design_Time_Addresses/lab_7_feed/Feed1/?format=atom`,
                    type: "GET",
                    crossDomain: true,
                    dataType: "xml",
                    contentType: "application/json;charset=utf-8",
                    //data: data,
                    success: xmlParserAtom,
                    error: error => console.log(error)
                });
            }
            function xmlParserAtom(xml) {
                $(".main1").empty();
                let content = '';
                content += `
                <div class="entry">
                    <table border="1" cellpadding="5">
                        <tr>
                            <th>title</th>
                            <th>content</th>
                        </tr>
            `;
                $(xml).find("entry").each(function () {
                    content += `
                    <tr>
                        <td width="100px">
                            ${$(this).find("title").text()}
                        </td>
                        <td>
                            ${$(this).find("content").text()}
                        </td>
                    </tr>
                `;
                });
                content += `
                    </table>
                </div>
            `;
                $(".main1").append(content);
            }
    </script>
        <div style="margin-left: 50px; margin-top: -30px">
            <div id="getNotes" runat="server">
                <div style="margin: 10px;">
                    <div>
                        <input type="button" onclick="getNotes()" value="Get Notes" />
                        <div class="main" />
                    </div>
                </div>
            </div>
            <div id="getNotes1" runat="server" style="margin: 10px;">
                <div>
                    <div>
                        <input type="button" onclick="getNotes1()" value="Get Notes Atom" />
                        <div class="main1" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

