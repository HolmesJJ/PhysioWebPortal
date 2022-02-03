<%@ Page Title="Patient List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientsList.aspx.cs" Inherits="PhysioWebPortal.Administration.PatientsList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h2><%: Title %></h2>

    <div class="row">

        <div class="col-md-12">

            <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="-1" DataSourceID="SqlDSPatients" GridLines="Both" AllowFilteringByColumn="True" AllowPaging="True" PageSize="10" Width="100%">
                <GroupingSettings CollapseAllTooltip="Collapse all groups" CaseSensitive="false"></GroupingSettings>
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDSPatients">
                    <Columns>
                        <telerik:GridBoundColumn Display="false" DataField="Id" FilterControlAltText="Filter Id column" HeaderText="Id" ReadOnly="True" SortExpression="Id" UniqueName="Id">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PatientCodeName" FilterControlAltText="Filter Patient Code Name column" HeaderText="Patient Code Name" SortExpression="PatientCodeName" UniqueName="PatientCodeName" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Remarks" FilterControlAltText="Filter Remarks column" HeaderText="Remarks" SortExpression="Remarks" UniqueName="Remarks" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn AllowFiltering="false" DataField="LastUpdated" DataType="System.DateTime" FilterControlAltText="Filter LastUpdated column" HeaderText="LastUpdated" SortExpression="LastUpdated" UniqueName="LastUpdated">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn Display="false" DataField="LastUpdatedBy" FilterControlAltText="Filter LastUpdatedBy column" HeaderText="LastUpdatedBy" SortExpression="LastUpdatedBy" UniqueName="LastUpdatedBy">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="UserName" FilterControlAltText="Filter UserName column" HeaderText="Last Updated By" SortExpression="UserName" UniqueName="UserName" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                        </telerik:GridBoundColumn>
                    </Columns>

                    <PagerStyle AlwaysVisible="True" />

                </MasterTableView>

                <PagerStyle AlwaysVisible="True" />

            </telerik:RadGrid>

            <asp:SqlDataSource ID="SqlDSPatients" runat="server" ConnectionString="<%$ ConnectionStrings:PHYSIODBConnectionString %>" SelectCommand="SELECT Patients.Id, Patients.PatientCodeName, Patients.Remarks, Patients.LastUpdated, Patients.LastUpdatedBy, AspNetUsers.UserName FROM Patients INNER JOIN AspNetUsers ON Patients.LastUpdatedBy = AspNetUsers.Id"></asp:SqlDataSource>

        </div>

    </div>




</asp:Content>
