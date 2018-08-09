<%@ Page Language="VB" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
<script>
    $(document).ready(function () {

        var zoom = 1.0;
        var zoomStep = 0.03;
        var margin = 0;
        var marginStep = 20;

        $('#zoom-in').click(function () {
            margin += marginStep;
            $('#page-window').css({ transform: 'scale(' + (zoom += zoomStep) + ')' });
            var w = $('#page-window').css("width");

            $('#page-window').css({ "margin-left": (margin) });
            $('#page-window').css({ "margin-top": (margin) });
        })
        $('#zoom-out').click(function () {

            margin -= marginStep;

            $('#page-window').css({ transform: 'scale(' + (zoom -= zoomStep) + ')' });
            $('#page-window').css({ "margin-left": margin });
            $('#page-window').css({ "margin-top": margin });


        })
    });
</script>

<script type="text/javascript">
    function UploadFile(fileUpload) {
        if (fileUpload.value != '') {
            document.getElementById("<%=btnUpload.ClientID %>").click();
        }
    }
</script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:FileUpload ID="uplPDF" runat="server" ToolTip="Please select a PDF document." /><br />
         <asp:Label ID="lblMessage" runat="server" Text="File uploaded successfully." ForeColor="Green"
    Visible="false" />
         <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="Upload" Style="display: none" />
        <asp:Button ID="btnPrev" runat="server" Text="Prev" OnClick="btnPrev_Click" />&nbsp;
        <asp:TextBox ID="txtPage" runat="server" Width="80px"></asp:TextBox>&nbsp;
        <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" />
        &nbsp;<input type="button" value="+" id="zoom-in" />&nbsp;
        <input type="button" value="-" id="zoom-out" />
        <div id="page-window">
            <asp:Literal ID="htmlLiteral" runat="server" />
        </div>       
        
    </form>
</body>
</html>
