<%@ Page Language="VB" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="font-size: 12pt">
    <form id="form1" runat="server">
    <div style="text-align: center"><table border="0" cellpadding="0" cellspacing="0" width="700px" >
        <tbody>
            <tr>
                <td colspan="2" style="height: 18px">
                    <span class="style1"><em><span style="font-family: Verdana"><strong>PDF Focus .Net</strong></span></em></span></td>
            </tr>
            <tr style="font-style: italic; font-family: Verdana">
                <td style="width: 75px; height: 160px;">
                    <a href="http://www.sautinsoft.com/products/pdf-focus/order.php">
                    <img alt="100% C# assembly to export PDF to Word, RTF, Text, Images" height="160" src="box.jpg" width="113" border="0"/></a></td>
                <td style="height: 160px">
                    <p class="style1" style="text-align: justify">
                        <span><span class="blue12"><span style="font-size: 10pt"><span class="blue12b">PDF Focus
                            .Net</span> is a standalone
                            C# library to convert:</span></span></span></p>
                    <ul>
                        <li style="text-align: left"><span><span class="blue12"><span style="font-size: 10pt">
                            PDF to Word (DOC, RTF, Text)</span></span></span></li>
                        <li style="text-align: left"><span><span class="blue12"><span style="font-size: 10pt">
                            PDF to Images(Jpeg, Png, Bmp, Tiff, Multipage Tiff)</span></span></span></li>
                    </ul>
                    <p style="text-align: justify">
                        <span><span class="blue12"><span style="font-size: 10pt">This sample shows how to export
                            PDF document into Jpeg(s) in memory.</span></span></span></p>
                </td>
            </tr>
            <tr>
                <td style="width: 75px">
                    &nbsp;</td>
                <td style="text-align: right">
                    <a href="http://www.sautinsoft.com/products/pdf-focus/order.php" target="_blank">
                        <span style="font-size: 10pt; font-family: Verdana">Purchase PDF Focus .Net online!</span></a></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 91px; text-align: justify;">
                    <span style="font-size: 9pt; font-family: Verdana">Please select any PDF file (*.pdf):<br />
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="805px" /></span></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 51px; text-align: right">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Export to Jpeg" />
                    <br />
                    <br />
                        <asp:Label ID="Result" runat="server" Font-Bold="True" Font-Names="Verdana"></asp:Label></td>
            </tr>
        </tbody>
    </table>
        <asp:Image ID="Image1" runat="server" /><br />
        <br />
        &nbsp;
        <br />
        <br />
        </div>
    </form>
</body>
</html>
