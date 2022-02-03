<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Patients.aspx.cs" Inherits="PhysioWebPortal.Patients"%>
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

    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    </telerik:RadCodeBlock>
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadButton2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Panel1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadButton3">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindow2" UpdatePanelCssClass=""></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindow1" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>
    <asp:Panel ID="Panel1" runat="server">
    <br />    
    <br />
    <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="-1" DataSourceID="SqlDataSource1" OnItemCommand="RadGrid1_ItemCommand" OnItemDataBound="RadGrid1_ItemDataBound">
        <MasterTableView DataSourceID="SqlDataSource1" AutoGenerateColumns="False" EditMode="PopUp" DataKeyNames="Id" CommandItemDisplay="Top">
            <CommandItemTemplate>
                <telerik:RadButton ID="RadButton2" runat="server" Text="Refresh" OnClick="RadButton2_Click"></telerik:RadButton>
                <telerik:RadButton ID="RadButton3" runat="server" Text="Add New Patient" OnClick="RadButton3_Click"></telerik:RadButton>
            </CommandItemTemplate>
            <Columns>
                <telerik:GridBoundColumn DataField="Id" HeaderText="Id" SortExpression="Id" UniqueName="Id" FilterControlAltText="Filter Id column" ReadOnly="True" Display="false"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PatientCodeName" HeaderText="Patients" SortExpression="PatientCodeName" UniqueName="PatientCodeName" FilterControlAltText="Filter PatientCodeName column"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" UniqueName="Remarks" FilterControlAltText="Filter Remarks column"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PreferredLanguage" HeaderText="Preferred Language" SortExpression="PreferredLanguage" UniqueName="PreferredLanguage" DataType="System.Int32" FilterControlAltText="Filter PreferredLanguage column" Display="false"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Preferred Language" SortExpression="PreferredLanguage" UniqueName="Language" DataType="System.String" FilterControlAltText="Filter PreferredLanguage column" ></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="LastUpdated" HeaderText="Last Updated" SortExpression="LastUpdated" UniqueName="LastUpdated" DataType="System.DateTime" FilterControlAltText="Filter LastUpdated column"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="UserName" HeaderText="Physiotherapists" SortExpression="UserName" UniqueName="UserName" FilterControlAltText="Filter UserName column"></telerik:GridBoundColumn>
                <telerik:GridButtonColumn Text="Edit" ButtonType="PushButton" CommandName="EditCommand"></telerik:GridButtonColumn>
                <telerik:GridButtonColumn Text="More" UniqueName="PatientId" ButtonType="PushButton" CommandName="MoreCommand"></telerik:GridButtonColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
    </asp:Panel>
    

    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:PHYSIODBConnectionString %>' SelectCommand="SELECT Patients.Id, Patients.PatientCodeName, Patients.Remarks, Patients.PreferredLanguage, Patients.LastUpdated, AspNetUsers.UserName FROM Patients INNER JOIN AspNetUsers ON Patients.LastUpdatedBy = AspNetUsers.Id"></asp:SqlDataSource>
</asp:Content>


