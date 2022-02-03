<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddHospitalStay.aspx.cs" Inherits="PhysioWebPortal.WebPortal.AddHospitalStay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Hospital Stay</title>
    <script type="text/javascript">
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow;
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
            return oWindow;
        }

        function returnSelection(arg) {
                    GetRadWindow().Close(arg);
             }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td style="font-weight:bold">Patient's Hospital Information</td>
        </tr>
         <tr>
            <td>Patient Code Name:</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true" Text='<%# DataBinder.Eval(Container, "DataItem.PatientId") %>'></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Start Date:</asp:LinkButton>
            </td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br />
                <asp:Calendar ID="Calendar1" runat="server" Visible="False" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">End Date:</asp:LinkButton>
            </td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox><br />
                <asp:Calendar ID="Calendar2" runat="server" Visible="False" OnSelectionChanged="Calendar2_SelectionChanged"></asp:Calendar>
            </td>
        </tr>
         <tr>
            <td>Pose:</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="1">Standing</asp:ListItem>
                    <asp:ListItem Value="2">Lying</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
         <tr>
            <td>Remarks:</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click"/>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"/>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
