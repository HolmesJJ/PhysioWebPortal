<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="PhysioWebPortal.test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" Runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>

    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadButton1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Panel1" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>

    <asp:Panel ID="Panel1" runat="server">

        <telerik:RadButton ID="RadButton1" runat="server" Text="RadButton" OnClick="RadButton1_Click"></telerik:RadButton>

    <telerik:RadGrid ID="RadGrid1" runat="server" DataSourceID="SqlDataSource1" CellSpacing="-1" GridLines="Both" AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True">
        <GroupingSettings CollapseAllTooltip="Collapse all groups">
        </GroupingSettings>
        <ClientSettings>
            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
        </ClientSettings>
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
            <Columns>
                <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter Id column" HeaderText="Id" ReadOnly="True" SortExpression="Id" UniqueName="Id">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PatientCodeName" FilterControlAltText="Filter PatientCodeName column" HeaderText="PatientCodeName" SortExpression="PatientCodeName" UniqueName="PatientCodeName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Remarks" FilterControlAltText="Filter Remarks column" HeaderText="Remarks" SortExpression="Remarks" UniqueName="Remarks">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PreferredLanguage" DataType="System.Int32" FilterControlAltText="Filter PreferredLanguage column" HeaderText="PreferredLanguage" SortExpression="PreferredLanguage" UniqueName="PreferredLanguage">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="LastUpdated" DataType="System.DateTime" FilterControlAltText="Filter LastUpdated column" HeaderText="LastUpdated" SortExpression="LastUpdated" UniqueName="LastUpdated">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="LastUpdatedBy" FilterControlAltText="Filter LastUpdatedBy column" HeaderText="LastUpdatedBy" SortExpression="LastUpdatedBy" UniqueName="LastUpdatedBy">
                </telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>

    </asp:Panel>

    
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbConnection %>" SelectCommand="SELECT * FROM [Patients]"></asp:SqlDataSource>
</asp:Content>
