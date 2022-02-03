<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PrescribedExercises.aspx.cs" Inherits="PhysioWebPortal.WebPortal.PrescribedExercises" %>
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
            <MasterTableView DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
                <Columns>
                    <telerik:GridBoundColumn DataField="StayId" HeaderText="StayId" SortExpression="StayId" UniqueName="StayId" DataType="System.Int32" FilterControlAltText="Filter StayId column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExId" HeaderText="ExId" SortExpression="ExId" UniqueName="ExId" DataType="System.Int32" FilterControlAltText="Filter ExId column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="AssignedDate" HeaderText="AssignedDate" SortExpression="AssignedDate" UniqueName="AssignedDate" DataType="System.DateTime" FilterControlAltText="Filter AssignedDate column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EndDate" HeaderText="EndDate" SortExpression="EndDate" UniqueName="EndDate" DataType="System.DateTime" FilterControlAltText="Filter EndDate column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExSetNo" HeaderText="ExSetNo" SortExpression="ExSetNo" UniqueName="ExSetNo" DataType="System.Int32" FilterControlAltText="Filter ExSetNo column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExRepNo" HeaderText="ExRepNo" SortExpression="ExRepNo" UniqueName="ExRepNo" DataType="System.Int32" FilterControlAltText="Filter ExRepNo column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExTimePerDay" HeaderText="ExTimePerDay" SortExpression="ExTimePerDay" UniqueName="ExTimePerDay" DataType="System.Int32" FilterControlAltText="Filter ExTimePerDay column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LastUpdated" HeaderText="LastUpdated" SortExpression="LastUpdated" UniqueName="LastUpdated" DataType="System.DateTime" FilterControlAltText="Filter LastUpdated column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LastUpdatedBy" HeaderText="LastUpdatedBy" SortExpression="LastUpdatedBy" UniqueName="LastUpdatedBy" FilterControlAltText="Filter LastUpdatedBy column"></telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:PHYSIODBConnectionString %>' SelectCommand="SELECT [StayId], [ExId], [AssignedDate], [EndDate], [ExSetNo], [ExRepNo], [ExTimePerDay], [LastUpdated], [LastUpdatedBy] FROM [PrescribedExercises]"></asp:SqlDataSource>
    </asp:Panel>
</asp:Content>
