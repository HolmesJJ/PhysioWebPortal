<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientCaregivers.aspx.cs" Inherits="PhysioWebPortal.WebPortal.PatientCaregivers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server">
         <Windows>
            <telerik:RadWindow runat="server" VisibleOnPageLoad="false" ID="RadWindow1"></telerik:RadWindow>
         </Windows>
    </telerik:RadWindowManager>
    <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager2" runat="server">
         <Windows>
            <telerik:RadWindow runat="server" VisibleOnPageLoad="false" ID="RadWindow2"></telerik:RadWindow>
         </Windows>
    </telerik:RadWindowManager>

    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server"></telerik:RadCodeBlock>

    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadButton1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Panel1" UpdatePanelCssClass=""></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadButton2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindow1" UpdatePanelCssClass=""></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadButton3">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindow2" UpdatePanelCssClass=""></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindow2" UpdatePanelCssClass=""></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass=""></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid2" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid2" UpdatePanelCssClass=""></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>

    <asp:Panel ID="Panel1" runat="server">
        <br />
        <br />
        <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="-1" DataSourceID="SqlDataSource1" GridLines="Both">
            <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                <Selecting AllowRowSelect="true"></Selecting>
            </ClientSettings>
            <MasterTableView DataSourceID="SqlDataSource1" AutoGenerateColumns="False" EditMode="PopUp" CommandItemDisplay="Top" DataKeyNames="CaregiverId">
                <CommandItemTemplate>
                    <telerik:RadButton ID="RadButton1" runat="server" Text="Refresh" OnClick="RadButton1_Click"></telerik:RadButton>
                    <telerik:RadButton ID="RadButton2" runat="server" Text="Add New Cargiver" OnClick="RadButton2_Click"></telerik:RadButton>
                </CommandItemTemplate>
                <Columns>
                    <telerik:GridBoundColumn DataField="PatientCodeName" HeaderText="PatientCodeName" SortExpression="PatientCodeName" UniqueName="PatientCodeName" FilterControlAltText="Filter PatientCodeName column" Display="false"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CaregiverId" HeaderText="CaregiverId" SortExpression="CaregiverId" UniqueName="CaregiverId" FilterControlAltText="Filter CaregiverId column" Display="false"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CareGiverName" HeaderText="CareGiverName" SortExpression="CareGiverName" UniqueName="CareGiverName" FilterControlAltText="Filter CareGiverName column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LastUpdated" HeaderText="LastUpdated" SortExpression="LastUpdated" UniqueName="LastUpdated" DataType="System.DateTime" FilterControlAltText="Filter LastUpdated column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="UserName" HeaderText="UserName" SortExpression="UserName" UniqueName="UserName" FilterControlAltText="Filter UserName column"></telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:PHYSIODBConnectionString %>' SelectCommand="SELECT CaregiverTable.PatientCodeName, CaregiverTable.CaregiverId, B.UserName AS CareGiverName, CaregiverTable.LastUpdated, CaregiverTable.UserName FROM (SELECT Patients.PatientCodeName, PatientCaregivers.CaregiverId, PatientCaregivers.LastUpdated, AspNetUsers.UserName FROM Patients INNER JOIN PatientCaregivers ON Patients.Id = PatientCaregivers.PatientId INNER JOIN AspNetUsers ON PatientCaregivers.LastUpdatedBy = AspNetUsers.Id) AS CaregiverTable INNER JOIN AspNetUsers AS B ON CaregiverTable.CaregiverId = B.Id"></asp:SqlDataSource>
        <br />
        <br />
        <br />
        <telerik:RadGrid ID="RadGrid2" runat="server" DataSourceID="SqlDataSource2" CellSpacing="-1" GridLines="Both">
            <MasterTableView DataKeyNames="CaregiverId" DataSourceID="SqlDataSource2" AutoGenerateColumns="False" CommandItemDisplay="Top">
                <CommandItemTemplate>
                    <telerik:RadButton ID="RadButton3" runat="server" Text="Add new Associate" OnClick="RadButton3_Click"></telerik:RadButton>
                </CommandItemTemplate>
                <Columns>
                    <telerik:GridBoundColumn DataField="PatientCodeName" HeaderText="PatientCodeName" SortExpression="PatientCodeName" UniqueName="PatientCodeName" FilterControlAltText="Filter PatientCodeName column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="UserName" HeaderText="UserName" SortExpression="UserName" UniqueName="UserName" FilterControlAltText="Filter UserName column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CaregiverId" HeaderText="CaregiverId" SortExpression="CaregiverId" UniqueName="CaregiverId" FilterControlAltText="Filter CaregiverId column" Display="false"></telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
        <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:PHYSIODBConnectionString %>' SelectCommand="SELECT Patients.PatientCodeName, AspNetUsers.UserName, PatientCaregivers.CaregiverId FROM Patients INNER JOIN PatientCaregivers ON Patients.Id = PatientCaregivers.PatientId INNER JOIN AspNetUsers ON AspNetUsers.Id = PatientCaregivers.CaregiverId WHERE (PatientCaregivers.CaregiverId = @CaregiverId)">
            <SelectParameters>
                <asp:ControlParameter ControlID="RadGrid1" Name="CaregiverId" Type="String" DefaultValue="0"/>
            </SelectParameters>
        </asp:SqlDataSource>
    </asp:Panel>
</asp:Content>
