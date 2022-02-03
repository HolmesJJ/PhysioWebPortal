<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gifts.aspx.cs" Inherits="PhysioWebPortal.Gifts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadButton1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Panel1" UpdatePanelCssClass=""></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>

    <asp:Panel ID="Panel1" runat="server">
        <telerik:RadButton ID="RadButton1" runat="server" Text="Refresh" OnClick="RadButton1_Click"></telerik:RadButton>

        <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="-1" DataSourceID="SqlDataSource1" GridLines="Both">
            <MasterTableView DataKeyNames="GiftTypeId" DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
                <Columns>
                    <telerik:GridBoundColumn DataField="GiftTypeId" ReadOnly="True" HeaderText="GiftTypeId" SortExpression="GiftTypeId" UniqueName="GiftTypeId" DataType="System.Int32" FilterControlAltText="Filter GiftTypeId column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Description" HeaderText="Description" SortExpression="Description" UniqueName="Description" FilterControlAltText="Filter Description column"></telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:PHYSIODBConnectionString %>' SelectCommand="SELECT [GiftTypeId], [Description] FROM [Gifts]"></asp:SqlDataSource>
    </asp:Panel>
</asp:Content>
