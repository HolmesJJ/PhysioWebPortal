<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PerformedExercises.aspx.cs" Inherits="PhysioWebPortal.WebPortal.PerformedExercises" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadButton1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass=""></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <asp:Panel ID="Panel1" runat="server">
        <telerik:RadButton ID="RadButton1" runat="server" Text="Refresh" OnClick="RadButton1_Click"></telerik:RadButton>
        <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="-1" DataSourceID="SqlDataSource1" GridLines="Both">
            <MasterTableView DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
                <Columns>
                    <telerik:GridBoundColumn DataField="PEId" HeaderText="PEId" SortExpression="PEId" UniqueName="PEId" DataType="System.Int32" FilterControlAltText="Filter PEId column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="StartTime" HeaderText="StartTime" SortExpression="StartTime" UniqueName="StartTime" DataType="System.DateTime" FilterControlAltText="Filter StartTime column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EndTime" HeaderText="EndTime" SortExpression="EndTime" UniqueName="EndTime" DataType="System.DateTime" FilterControlAltText="Filter EndTime column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExSetNo" HeaderText="ExSetNo" SortExpression="ExSetNo" UniqueName="ExSetNo" DataType="System.Int32" FilterControlAltText="Filter ExSetNo column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExRepNo" HeaderText="ExRepNo" SortExpression="ExRepNo" UniqueName="ExRepNo" DataType="System.Int32" FilterControlAltText="Filter ExRepNo column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExType" HeaderText="ExType" SortExpression="ExType" UniqueName="ExType" DataType="System.Int32" FilterControlAltText="Filter ExType column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="AvgAngle" HeaderText="AvgAngle" SortExpression="AvgAngle" UniqueName="AvgAngle" DataType="System.Double" FilterControlAltText="Filter AvgAngle column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="AvgHoldDuration" HeaderText="AvgHoldDuration" SortExpression="AvgHoldDuration" UniqueName="AvgHoldDuration" DataType="System.Double" FilterControlAltText="Filter AvgHoldDuration column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExVisualFile" HeaderText="ExVisualFile" SortExpression="ExVisualFile" UniqueName="ExVisualFile" FilterControlAltText="Filter ExVisualFile column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Score" HeaderText="Score" SortExpression="Score" UniqueName="Score" DataType="System.Int32" FilterControlAltText="Filter Score column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LastUpdated" HeaderText="LastUpdated" SortExpression="LastUpdated" UniqueName="LastUpdated" DataType="System.DateTime" FilterControlAltText="Filter LastUpdated column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LastUpdatedBy" HeaderText="LastUpdatedBy" SortExpression="LastUpdatedBy" UniqueName="LastUpdatedBy" FilterControlAltText="Filter LastUpdatedBy column"></telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:PHYSIODBConnectionString %>' SelectCommand="SELECT [PEId], [StartTime], [EndTime], [ExSetNo], [ExRepNo], [ExType], [AvgAngle], [AvgHoldDuration], [ExVisualFile], [Score], [LastUpdated], [LastUpdatedBy] FROM [PerformedExercises]"></asp:SqlDataSource>
    </asp:Panel>
</asp:Content>
