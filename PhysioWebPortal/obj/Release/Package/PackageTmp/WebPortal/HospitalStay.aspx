<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HospitalStay.aspx.cs" Inherits="PhysioWebPortal.HospitalStay1" %>
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
    <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager3" runat="server">
            <Windows>
                <telerik:RadWindow runat="server" VisibleOnPageLoad="false" ID="RadWindow3"></telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager4" runat="server">
            <Windows>
                <telerik:RadWindow runat="server" VisibleOnPageLoad="false" ID="RadWindow4"></telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>

    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadButton1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Panel1" UpdatePanelCssClass=""></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadButton3">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindow2"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadButton2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindow3"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadButton4">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindow4"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindow1" UpdatePanelCssClass=""></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass=""></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid2" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid2" UpdatePanelCssClass=""></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid3" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid3">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid3" UpdatePanelCssClass=""></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>

    <asp:Panel ID="Panel1" runat="server">
        <br />
        <br />
        <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="-1" DataSourceID="SqlDataSource2" OnItemCommand="RadGrid1_ItemCommand" OnItemDataBound="RadGrid1_ItemDataBound">
            <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                <Selecting AllowRowSelect="true"></Selecting>
            </ClientSettings>
            <MasterTableView DataSourceID="SqlDataSource2" AutoGenerateColumns="False" EditMode="PopUp" DataKeyNames="StayId" CommandItemDisplay="Top">
                <CommandItemTemplate>
                    <div style="padding: 5px 5px;">
                    <telerik:RadButton ID="RadButton1" runat="server" OnClick="RadButton1_Click" Text="Refresh"></telerik:RadButton>
                    <telerik:RadButton ID="RadButton3" runat="server" OnClick="RadButton3_Click" Text="Add New Record"></telerik:RadButton>
                        </div>
                </CommandItemTemplate>
                <Columns>
                    <telerik:GridBoundColumn DataField="StayId" HeaderText="StayId" SortExpression="StayId" UniqueName="StayId" FilterControlAltText="Filter StayId column" DataType="System.Int32" ReadOnly="True" Display="false"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PatientId" HeaderText="PatientId" SortExpression="PatientId" UniqueName="PatientId" FilterControlAltText="Filter PatientId column" Display="false"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PatientCodeName" HeaderText="Patients" SortExpression="PatientCodeName" UniqueName="PatientCodeName" FilterControlAltText="Filter PatientCodeName column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="StartDate" HeaderText="Start Date" SortExpression="StartDate" UniqueName="StartDate" DataType="System.DateTime" FilterControlAltText="Filter StartDate column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EndDate" HeaderText="End Date" SortExpression="EndDate" UniqueName="EndDate" FilterControlAltText="Filter EndDate column" DataType="System.DateTime"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Pose" SortExpression="Pose" UniqueName="Pose" FilterControlAltText="Filter Pose column" DataType="System.Int32" DataField="Pose" Display="false"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Pose" SortExpression="Pose" UniqueName="PoseName" FilterControlAltText="Filter Pose column" DataType="System.String"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" UniqueName="Remarks" FilterControlAltText="Filter Remarks column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PhysiotherapistId" HeaderText="PhysiotherapistId" SortExpression="PhysiotherapistId" UniqueName="PhysiotherapistId" FilterControlAltText="Filter PhysiotherapistId column" Display="false"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LastUpdated" HeaderText="Last Updated" SortExpression="LastUpdated" UniqueName="LastUpdated" FilterControlAltText="Filter LastUpdated column" DataType="System.DateTime"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="UserName" HeaderText="Physiotherapist" SortExpression="UserName" UniqueName="UserName" FilterControlAltText="Filter UserName column"></telerik:GridBoundColumn>

                    <telerik:GridButtonColumn Text="Edit" ButtonType="PushButton" CommandName="EditCommand"></telerik:GridButtonColumn>
                </Columns>
                </MasterTableView>
        </telerik:RadGrid>
        <br />
        <br />
        <br />
        <br />
        <h4>Prescribed Exercises:</h4>
        <telerik:RadGrid ID="RadGrid2" runat="server" CellSpacing="-1" DataSourceID="SqlDataSource1" GridLines="Both">
             <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                <Selecting AllowRowSelect="true"></Selecting>
            </ClientSettings>
            <MasterTableView DataKeyNames="PEId" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" CommandItemDisplay="Top">
                <CommandItemTemplate>
                    <telerik:RadButton ID="RadButton2" runat="server" Text="Add new Exercise" OnClick="RadButton2_Click"></telerik:RadButton>
                </CommandItemTemplate>
                <Columns>
                    <telerik:GridBoundColumn DataField="ExName" HeaderText="Exercise Name" SortExpression="ExName" UniqueName="ExName" FilterControlAltText="Filter ExName column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PEId" ReadOnly="True" HeaderText="PEId" SortExpression="PEId" UniqueName="PEId" DataType="System.Int32" FilterControlAltText="Filter PEId column" Display="false"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="StayId" HeaderText="StayId" SortExpression="StayId" UniqueName="StayId" DataType="System.Int32" FilterControlAltText="Filter StayId column" Display="false"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExId" HeaderText="ExId" SortExpression="ExId" UniqueName="ExId" DataType="System.Int32" FilterControlAltText="Filter ExId column" Display="false"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="AssignedDate" HeaderText="Assigned Date" SortExpression="AssignedDate" UniqueName="AssignedDate" DataType="System.DateTime" FilterControlAltText="Filter AssignedDate column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EndDate" HeaderText="End Date" SortExpression="EndDate" UniqueName="EndDate" DataType="System.DateTime" FilterControlAltText="Filter EndDate column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExSetNo" HeaderText="ExSetNo" SortExpression="ExSetNo" UniqueName="ExSetNo" DataType="System.Int32" FilterControlAltText="Filter ExSetNo column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExRepNo" HeaderText="ExRepNo" SortExpression="ExRepNo" UniqueName="ExRepNo" DataType="System.Int32" FilterControlAltText="Filter ExRepNo column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExTimePerDay" HeaderText="ExTimePerDay" SortExpression="ExTimePerDay" UniqueName="ExTimePerDay" DataType="System.Int32" FilterControlAltText="Filter ExTimePerDay column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LastUpdated" HeaderText="Last Updated" SortExpression="LastUpdated" UniqueName="LastUpdated" DataType="System.DateTime" FilterControlAltText="Filter LastUpdated column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="UserName" HeaderText="Physiotherapist" SortExpression="UserName" UniqueName="UserName" FilterControlAltText="Filter UserName column"></telerik:GridBoundColumn>
                
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
        <br />
        <br />
        <br />
        <br />
        <h4>Performed Exercises:</h4>
        <telerik:RadGrid ID="RadGrid3" runat="server" CellSpacing="-1" DataSourceID="SqlDataSource3" GridLines="Both">
            <MasterTableView DataKeyNames="PerformExId" DataSourceID="SqlDataSource3" AutoGenerateColumns="False" CommandItemDisplay="Top">
                <CommandItemTemplate>
                    <telerik:RadButton ID="RadButton4" runat="server" Text="Upload files" OnClick="RadButton4_Click"></telerik:RadButton>
                </CommandItemTemplate>
                <Columns>
                    <telerik:GridBoundColumn DataField="PerformExId" ReadOnly="True" HeaderText="PerformExId" SortExpression="PerformExId" UniqueName="PerformExId" DataType="System.Int32" FilterControlAltText="Filter PerformExId column" Display="false"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PEId" HeaderText="PEId" SortExpression="PEId" UniqueName="PEId" DataType="System.Int32" FilterControlAltText="Filter PEId column"  Display="false"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="StartTime" HeaderText="Start Time" SortExpression="StartTime" UniqueName="StartTime" DataType="System.DateTime" FilterControlAltText="Filter StartTime column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EndTime" HeaderText="End Time" SortExpression="EndTime" UniqueName="EndTime" DataType="System.DateTime" FilterControlAltText="Filter EndTime column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExSetNo" HeaderText="ExSetNo" SortExpression="ExSetNo" UniqueName="ExSetNo" DataType="System.Int32" FilterControlAltText="Filter ExSetNo column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExRepNo" HeaderText="ExRepNo" SortExpression="ExRepNo" UniqueName="ExRepNo" DataType="System.Int32" FilterControlAltText="Filter ExRepNo column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExType" HeaderText="Exercise Type" SortExpression="ExType" UniqueName="ExType" DataType="System.Int32" FilterControlAltText="Filter ExType column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="AvgAngle" HeaderText="Avg Angle" SortExpression="AvgAngle" UniqueName="AvgAngle" DataType="System.Double" FilterControlAltText="Filter AvgAngle column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="AvgHoldDuration" HeaderText="Avg Hold Duration" SortExpression="AvgHoldDuration" UniqueName="AvgHoldDuration" DataType="System.Double" FilterControlAltText="Filter AvgHoldDuration column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExVisualFile" HeaderText="Video" SortExpression="ExVisualFile" UniqueName="ExVisualFile" FilterControlAltText="Filter ExVisualFile column" Display="false"></telerik:GridBoundColumn>
                    <telerik:GridHyperLinkColumn DataTextField="ExVisualFile" HeaderText="Video" SortExpression="ExVisualFile" UniqueName="ExVisualFile" FilterControlAltText="Filter ExVisualFile column" DataTextFormatString="'{0}'" DataNavigateUrlFields="ExVisualFile" DataNavigateUrlFormatString="https://wearnotch.com/m/{0}"></telerik:GridHyperLinkColumn>
                    <telerik:GridBoundColumn DataField="Score" HeaderText="Score" SortExpression="Score" UniqueName="Score" DataType="System.Int32" FilterControlAltText="Filter Score column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LastUpdated" HeaderText="Last Updated" SortExpression="LastUpdated" UniqueName="LastUpdated" DataType="System.DateTime" FilterControlAltText="Filter LastUpdated column"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="UserName" HeaderText="Physiotherapist" SortExpression="UserName" UniqueName="UserName" FilterControlAltText="Filter UserName column"></telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>

        <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:PHYSIODBConnectionString %>' SelectCommand="SELECT PerformedExercises.PerformExId, PerformedExercises.PEId, PerformedExercises.StartTime, PerformedExercises.EndTime, PerformedExercises.ExSetNo, PerformedExercises.ExRepNo, PerformedExercises.ExType, PerformedExercises.AvgAngle, PerformedExercises.AvgHoldDuration, PerformedExercises.ExVisualFile, PerformedExercises.Score, PerformedExercises.LastUpdated, AspNetUsers.UserName FROM PerformedExercises INNER JOIN PrescribedExercises ON PerformedExercises.PEId = PrescribedExercises.PEId INNER JOIN AspNetUsers ON PerformedExercises.LastUpdatedBy = AspNetUsers.Id WHERE (PrescribedExercises.PEId = @PEId)">
            <SelectParameters>
                <asp:ControlParameter ControlID="RadGrid2" Name="PEId" Type="Int32" PropertyName="SelectedValues['PEId']" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:PHYSIODBConnectionString %>' SelectCommand="SELECT Exercises.ExName, PrescribedExercises.PEId, PrescribedExercises.StayId, PrescribedExercises.ExId, PrescribedExercises.AssignedDate, PrescribedExercises.EndDate, PrescribedExercises.ExSetNo, PrescribedExercises.ExRepNo, PrescribedExercises.ExTimePerDay, PrescribedExercises.LastUpdated, AspNetUsers.UserName FROM PrescribedExercises INNER JOIN AspNetUsers ON PrescribedExercises.LastUpdatedBy = AspNetUsers.Id INNER JOIN HospitalStay ON PrescribedExercises.StayId = HospitalStay.StayId INNER JOIN Exercises ON PrescribedExercises.ExId = Exercises.ExId WHERE (HospitalStay.StayId = @StayId)">
            <SelectParameters>
                <asp:ControlParameter ControlID="RadGrid1" Type="Int32" Name="StayId" DefaultValue="0"/>
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:PHYSIODBConnectionString %>' SelectCommand="SELECT HospitalStay.StayId, HospitalStay.PatientId, Patients.PatientCodeName, HospitalStay.StartDate, HospitalStay.EndDate, HospitalStay.Pose, HospitalStay.Remarks, HospitalStay.PhysiotherapistId, HospitalStay.LastUpdated, AspNetUsers.UserName FROM HospitalStay INNER JOIN Patients ON HospitalStay.PatientId = Patients.Id INNER JOIN AspNetUsers ON Patients.LastUpdatedBy = AspNetUsers.Id WHERE (HospitalStay.PatientId = @PatientId)">
            <SelectParameters>
                <asp:Parameter Name="PatientId" Type="String" DefaultValue="0"/>
            </SelectParameters>
        </asp:SqlDataSource>
    </asp:Panel>
</asp:Content>
