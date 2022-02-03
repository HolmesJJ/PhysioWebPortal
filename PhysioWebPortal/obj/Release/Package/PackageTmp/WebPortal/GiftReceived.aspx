<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GiftReceived.aspx.cs" Inherits="PhysioWebPortal.GiftReceived1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadButton1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass=""></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>
    <asp:Panel ID="Panel1" runat="server">
        <telerik:RadButton ID="RadButton1" runat="server" Text="Refresh" OnClick="RadButton1_Click"></telerik:RadButton>
        <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="-1" DataSourceID="SqlDataSource1" GridLines="Both">
            <MasterTableView DataKeyNames="GiftReceivedId" DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
                <Columns>
                    <telerik:GridBoundColumn DataField="GiftReceivedId" ReadOnly="True" HeaderText="GiftReceivedId" SortExpression="GiftReceivedId" UniqueName="GiftReceivedId" DataType="System.Int32" FilterControlAltText="Filter GiftReceivedId column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="StayId" HeaderText="StayId" SortExpression="StayId" UniqueName="StayId" DataType="System.Int32" FilterControlAltText="Filter StayId column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="GiftTypeId" HeaderText="GiftTypeId" SortExpression="GiftTypeId" UniqueName="GiftTypeId" DataType="System.Int32" FilterControlAltText="Filter GiftTypeId column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ReceivedDateTime" HeaderText="ReceivedDateTime" SortExpression="ReceivedDateTime" UniqueName="ReceivedDateTime" DataType="System.DateTime" FilterControlAltText="Filter ReceivedDateTime column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="GivenById" HeaderText="GivenById" SortExpression="GivenById" UniqueName="GivenById" FilterControlAltText="Filter GivenById column"></telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>

        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:PHYSIODBConnectionString %>' SelectCommand="SELECT * FROM [GiftReceived]"></asp:SqlDataSource>
    </asp:Panel>
    
</asp:Content>
