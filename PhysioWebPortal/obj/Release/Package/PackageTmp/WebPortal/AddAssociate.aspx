<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAssociate.aspx.cs" Inherits="PhysioWebPortal.WebPortal.AddAssociate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>New Associate</title>
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
            <td style="font-weight:bold">Associate's Information</td>
        </tr>
        <tr>
            <td>Caregiver:</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true" Text='<%# DataBinder.Eval(Container, "DataItem.UserName") %>'></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Patient:</td>
            <td>
                <asp:DropDownList runat="server" ID="dropdownlist1" DataSourceID="SqlDataSource1" DataTextField="PatientCodeName" DataValueField="Id"></asp:DropDownList>
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:PHYSIODBConnectionString %>' SelectCommand="SELECT [PatientCodeName], [Id] FROM [Patients]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                
                <asp:Button ID="btnAdd" runat="server" Text="Add Patient" CommandName="Add" OnClick="btnAdd_Click"/>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"/>
                
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
