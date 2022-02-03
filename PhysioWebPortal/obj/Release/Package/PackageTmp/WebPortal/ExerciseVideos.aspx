<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExerciseVideos.aspx.cs" Inherits="PhysioWebPortal.WebPortal.ExerciseVideos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadButton1"></telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <asp:Panel ID="Panel1" runat="server">
        <telerik:RadButton ID="RadButton1" runat="server" Text="Refresh" OnClick="RadButton1_Click"></telerik:RadButton>
        <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="-1" DataSourceID="SqlDataSource1" GridLines="Both">
            <MasterTableView DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
                <Columns>
                    <telerik:GridBoundColumn DataField="VFileEnglish" HeaderText="VFileEnglish" SortExpression="VFileEnglish" UniqueName="VFileEnglish" FilterControlAltText="Filter VFileEnglish column" Display="false"></telerik:GridBoundColumn>
                    <telerik:GridHyperLinkColumn DataTextField="VFileEnglish" HeaderText="Video" SortExpression="VFileEnglish" UniqueName="VFileEnglish" FilterControlAltText="Filter VFileEnglish column" DataTextFormatString="'{0}'" DataNavigateUrlFields="VFileEnglish" DataNavigateUrlFormatString="~/Videos/{0}"></telerik:GridHyperLinkColumn>
                    <telerik:GridBoundColumn DataField="VFileMandarin" HeaderText="VFileMandarin" SortExpression="VFileMandarin" UniqueName="VFileMandarin" FilterControlAltText="Filter VFileMandarin column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="VFileMalay" HeaderText="VFileMalay" SortExpression="VFileMalay" UniqueName="VFileMalay" FilterControlAltText="Filter VFileMalay column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="VFileTamil" HeaderText="VFileTamil" SortExpression="VFileTamil" UniqueName="VFileTamil" FilterControlAltText="Filter VFileTamil column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="VThumbnail" HeaderText="VThumbnail" SortExpression="VThumbnail" UniqueName="VThumbnail" FilterControlAltText="Filter VThumbnail column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LastUpdated" HeaderText="LastUpdated" SortExpression="LastUpdated" UniqueName="LastUpdated" DataType="System.DateTime" FilterControlAltText="Filter LastUpdated column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LastUpdatedBy" HeaderText="LastUpdatedBy" SortExpression="LastUpdatedBy" UniqueName="LastUpdatedBy" FilterControlAltText="Filter LastUpdatedBy column"></telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:PHYSIODBConnectionString %>' SelectCommand="SELECT [VFileEnglish], [VFileMandarin], [VFileMalay], [VFileTamil], [VThumbnail], [LastUpdated], [LastUpdatedBy] FROM [ExerciseVideos]"></asp:SqlDataSource>
    </asp:Panel>
</asp:Content>
