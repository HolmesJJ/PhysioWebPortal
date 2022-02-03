<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exercises.aspx.cs" Inherits="PhysioWebPortal.Exercises" %>
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
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1"></telerik:AjaxUpdatedControl>
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
                <telerik:GridBoundColumn DataField="ExName" HeaderText="ExName" SortExpression="ExName" UniqueName="ExName" FilterControlAltText="Filter ExName column"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ExNameMandarin" HeaderText="ExNameMandarin" SortExpression="ExNameMandarin" UniqueName="ExNameMandarin" FilterControlAltText="Filter ExNameMandarin column"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ExNameMalay" HeaderText="ExNameMalay" SortExpression="ExNameMalay" UniqueName="ExNameMalay" FilterControlAltText="Filter ExNameMalay column"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ExNameTamil" HeaderText="ExNameTamil" SortExpression="ExNameTamil" UniqueName="ExNameTamil" FilterControlAltText="Filter ExNameTamil column"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ExDescription" HeaderText="ExDescription" SortExpression="ExDescription" UniqueName="ExDescription" FilterControlAltText="Filter ExDescription column"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ExRepNo" HeaderText="ExRepNo" SortExpression="ExRepNo" UniqueName="ExRepNo" DataType="System.Int32" FilterControlAltText="Filter ExRepNo column"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ExTimePerDay" HeaderText="ExTimePerDay" SortExpression="ExTimePerDay" UniqueName="ExTimePerDay" DataType="System.Int32" FilterControlAltText="Filter ExTimePerDay column"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ExSetNo" HeaderText="ExSetNo" SortExpression="ExSetNo" UniqueName="ExSetNo" DataType="System.Int32" FilterControlAltText="Filter ExSetNo column"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ExHoldDuration" HeaderText="ExHoldDuration" SortExpression="ExHoldDuration" UniqueName="ExHoldDuration" DataType="System.Double" FilterControlAltText="Filter ExHoldDuration column"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ExAngleLyingPose" HeaderText="ExAngleLyingPose" SortExpression="ExAngleLyingPose" UniqueName="ExAngleLyingPose" DataType="System.Double" FilterControlAltText="Filter ExAngleLyingPose column"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ExAngleStandingPose" HeaderText="ExAngleStandingPose" SortExpression="ExAngleStandingPose" UniqueName="ExAngleStandingPose" DataType="System.Double" FilterControlAltText="Filter ExAngleStandingPose column"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ExAngleMeasureType" HeaderText="ExAngleMeasureType" SortExpression="ExAngleMeasureType" UniqueName="ExAngleMeasureType" FilterControlAltText="Filter ExAngleMeasureType column"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="LastUpdated" HeaderText="LastUpdated" SortExpression="LastUpdated" UniqueName="LastUpdated" DataType="System.DateTime" FilterControlAltText="Filter LastUpdated column"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="LastUpdatedBy" HeaderText="LastUpdatedBy" SortExpression="LastUpdatedBy" UniqueName="LastUpdatedBy" FilterControlAltText="Filter LastUpdatedBy column"></telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>

    </asp:Panel>
    
    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:PHYSIODBConnectionString %>' SelectCommand="SELECT [ExName], [ExNameMandarin], [ExNameMalay], [ExNameTamil], [ExDescription], [ExRepNo], [ExTimePerDay], [ExSetNo], [ExHoldDuration], [ExAngleLyingPose], [ExAngleStandingPose], [ExAngleMeasureType], [LastUpdated], [LastUpdatedBy] FROM [Exercises]"></asp:SqlDataSource>
</asp:Content>
