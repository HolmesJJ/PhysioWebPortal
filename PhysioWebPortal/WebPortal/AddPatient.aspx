<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPatient.aspx.cs" Inherits="PhysioWebPortal.WebPortal.AddPatient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Patients</title>
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
    <table>
        <tr>
            <td style="font-weight:bold">Patient's Information</td>
        </tr>
        <tr>
            <td>Patient Code Name:</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PatientCodeName") %>'></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Remarks:</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Remarks") %>'></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Preferred Language:</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="1">English</asp:ListItem>
                    <asp:ListItem Value="2">Chinese</asp:ListItem>
                    <asp:ListItem Value="3">Malay</asp:ListItem>
                    <asp:ListItem Value="4">Tamil</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="Add Patient" CommandName="Add" OnClick="btnAdd_Click"/>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"/>
                
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
