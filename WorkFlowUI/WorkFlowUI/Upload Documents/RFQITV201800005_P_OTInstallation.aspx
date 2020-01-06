<%@ Page Language="C#" MasterPageFile="~/TMS.Master" AutoEventWireup="true" CodeBehind="OTInstallation.aspx.cs"
    Inherits="TimeManagementSystem.OTInstallation" Title="OT Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Utilities" Namespace="Utilities" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">

        var selectedRowIndex = null;

        function onGridViewRowSelected(rowIndex) {
            selectedRowIndex = rowIndex;
        }

        function DeleteValidation() {
            if (selectedRowIndex == null) {
                alert("Please select a row");
                return false;
            }
            else {
                if (confirm("Are you sure to delete this row?") == false) {
                    var gvET = document.getElementById('<%= GridView1.ClientID %>');
                    var rCount = parseInt(selectedRowIndex) + 1;
                    gvET.rows[rCount].cells[0].childNodes[0].childNodes[0].status = false;
                    if (rCount % 2 != 0) {
                        var rowidx = 0;
                        for (rowidx; rowidx < gvET.rows[rCount].cells.length; rowidx++) {
                            gvET.rows[rCount].cells[rowidx].style.backgroundColor = '#F7F7DE';
                            gvET.rows[rCount].cells[rowidx].style.fontWeight = 'normal';
                        }
                    }
                    else {
                        var rowidx = 0;
                        for (rowidx; rowidx < gvET.rows[rCount].cells.length; rowidx++) {
                            gvET.rows[rCount].cells[rowidx].style.backgroundColor = 'white';
                            gvET.rows[rCount].cells[rowidx].style.fontWeight = 'normal';
                        }
                    }

                    return false;
                }
            }
        }


    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table style="width: 100%; height: 700px;">
                <tr>
                    <td>
                        <asp:Label ID="lblTitle" runat="server" CssClass="pageheader" Font-Bold="True" Text="OT Entry"
                            Width="100%"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--   <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                    </asp:ToolkitScriptManager>
--%>
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnAdd" runat="server" CssClass="button" Height="26px" OnClick="btnAdd_Click"
                                        Style="height: 26px" Text="Add" Width="50px" />
                                </td>
                                <td>
                                    <asp:Button ID="btnEdit" runat="server" CssClass="button" Height="26px" OnClick="btnEdit_Click"
                                        Text="Edit" Width="50px" />
                                </td>
                                <td align="left" valign="top">
                                    <asp:Button ID="btnDelete" runat="server" CssClass="button" Height="26px" OnClick="btnDelete_Click"
                                        Text="Delete" Width="50px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        <asp:Panel ID="PL_Main" runat="server" Height="200px" BackColor="#ABB1A9" Width="100%"
                            GroupingText="Employee Details" Visible="False" BorderColor="#666633" BorderStyle="Solid"
                            BorderWidth="1px" DefaultButton="btnDummy">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Emp No" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEMP" runat="server" BackColor="#AAAAAA" ReadOnly="True" Width="44px"></asp:TextBox>
                                        <asp:DropDownList ID="ddl_EmpNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_EmpNo_SelectedIndexChanged"
                                            CssClass="dropdownlist">
                                            <asp:ListItem Value="-1">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="Emp Name" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEmpName" runat="server" TabIndex="2" Width="191px" CssClass="textbox"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" Text="Department" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDept" runat="server" Width="88px" TabIndex="3" CssClass="textbox"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label12" runat="server" Text="Division" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDiv" runat="server" Width="88px" TabIndex="4" CssClass="textbox"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" Text="Grade" CssClass="label" Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtGrade" runat="server" Width="88px" ReadOnly="True" TabIndex="5"
                                            Visible="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label14" runat="server" Text="Attach Dept." CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="toAttDept" runat="server" Width="88px" CssClass="textbox" ReadOnly="True"
                                            TabIndex="6"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label15" runat="server" Text="Attach Divn." CssClass="label"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="toAttDiv" runat="server" Width="88px" CssClass="textbox" ReadOnly="True"
                                            TabIndex="7"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label77" runat="server" CssClass="label" Text="Auto Entry"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Auto" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="ddl_Auto_SelectedIndexChanged">
                                            <asp:ListItem Value="-1">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnDummy" runat="server" Height="2px" Width="0px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label19" runat="server" Text="Work Date" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtWorkDate" runat="server" Width="88px" TabIndex="8"></asp:TextBox>
                                        <asp:ImageButton ID="imgCalendar" runat="server" Height="16px" ImageUrl="~/Images/calendarIcon1.gif"
                                            Width="21px" />
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtWorkDate"
                                            PopupButtonID="imgCalendar" Format="dd/MM/yyyy">
                                        </asp:CalendarExtender>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:MaskedEditExtender ID="meeBreakTime" runat="server" AcceptAMPM="false" AcceptNegative="Left"
                                            ErrorTooltipEnabled="true" InputDirection="LeftToRight" Mask="99:99" MaskType="Time"
                                            MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                            TargetControlID="txtBreakTime" UserTimeFormat="None">
                                        </asp:MaskedEditExtender>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:MaskedEditValidator ID="mevBreakTime" runat="server" ControlExtender="meeBreakTime"
                                            ControlToValidate="txtBreakTime" Display="Dynamic" EmptyValueBlurredText="Time is required "
                                            EmptyValueMessage="Time is required " InvalidValueBlurredMessage="Invalid Time"
                                            InvalidValueMessage="Time is invalid" IsValidEmpty="true" ValidationGroup="MKE" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="From Time" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFromTime" runat="server" Width="60px" TabIndex="9">00:00</asp:TextBox>
                                        <asp:MaskedEditValidator ID="mevFromTime" runat="server" ControlExtender="meeFromTime"
                                            ControlToValidate="txtFromTime" Display="Dynamic" EmptyValueBlurredText="Time is required "
                                            EmptyValueMessage="Time is required " InvalidValueBlurredMessage="Invalid Time"
                                            InvalidValueMessage="Time is Invalid" IsValidEmpty="true" ValidationGroup="MKE" />
                                        <asp:MaskedEditExtender ID="meeFromTime" runat="server" AcceptAMPM="false" AcceptNegative="Left"
                                            ErrorTooltipEnabled="true" InputDirection="LeftToRight" Mask="99:99" MaskType="Time"
                                            MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                            TargetControlID="txtFromTime" UserTimeFormat="None">
                                        </asp:MaskedEditExtender>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label23" runat="server" Text="To Time" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtToTime" runat="server" Text='00:00' Width="60px" TabIndex="10"></asp:TextBox>
                                        <asp:MaskedEditValidator ID="mevToTime" runat="server" ControlExtender="meeToTime"
                                            ControlToValidate="txtToTime" Display="Dynamic" EmptyValueBlurredText="Time is required "
                                            EmptyValueMessage="Time is required " InvalidValueBlurredMessage="Invalid Time"
                                            InvalidValueMessage="Time is invalid" IsValidEmpty="true" ValidationGroup="MKE" />
                                        <asp:MaskedEditExtender ID="meeToTime" runat="server" AcceptAMPM="false" AcceptNegative="Left"
                                            ErrorTooltipEnabled="true" InputDirection="LeftToRight" Mask="99:99" MaskType="Time"
                                            MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                            TargetControlID="txtToTime" UserTimeFormat="None">
                                        </asp:MaskedEditExtender>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label24" runat="server" Text="Break Time" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBreakTime" runat="server" Width="88px" TabIndex="11"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chk_Exp" runat="server" CssClass="checkbox" Text="Exception" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="PL_Instantiation" runat="server" Height="210px" BackColor="#ABB1A9"
                            Width="100%" GroupingText="Installation" Visible="False" BorderColor="#666633"
                            BorderStyle="Solid" BorderWidth="1px" DefaultButton="btnSubmit">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label20" runat="server" Text="Work Type" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_WorkType" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddl_WorkType_SelectedIndexChanged" CssClass="dropdownlist">
                                            <asp:ListItem Value="-1">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtWorkType" runat="server" Width="191px" CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <td colspan="3">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label21" runat="server" Text="Duty Code" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_DutyCode" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddl_DutyCode_SelectedIndexChanged" CssClass="dropdownlist">
                                            <asp:ListItem Value="-1">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDutyCode" runat="server" Width="191px" CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="ET Number" CssClass="label"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtETNumber" runat="server" Width="191px" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label22" runat="server" Text="Contract No" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_ContractNo" runat="server" AppendDataBoundItems="True"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddl_ContractNo_SelectedIndexChanged"
                                            CssClass="dropdownlist">
                                            <asp:ListItem Value="-1">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtContractNo" runat="server" Width="191px" CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Remarks" CssClass="label"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtRemarks" runat="server" Width="191px" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label25" runat="server" Text="Shift / Site" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_ShiftSite" runat="server" CssClass="dropdownlist">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>0.5</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                    <td colspan="3">
                                        <asp:MaskedEditExtender ID="meeOTHours" runat="server" AcceptAMPM="false" AcceptNegative="Left"
                                            ErrorTooltipEnabled="true" InputDirection="LeftToRight" Mask="99:99" MaskType="Time"
                                            MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                            TargetControlID="txtOTHours" UserTimeFormat="None">
                                        </asp:MaskedEditExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label29" runat="server" Text="O.T (Y/N) ?" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_OT" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_OT_SelectedIndexChanged"
                                            CssClass="dropdownlist">
                                            <asp:ListItem>Y</asp:ListItem>
                                            <asp:ListItem Selected="True">N</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label30" runat="server" Text="Total Hours &amp; Mins" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtHours" runat="server" Width="48px" ReadOnly="True" CssClass="textbox"></asp:TextBox>
                                        <asp:Button ID="btnGetOT" runat="server" CssClass="button" OnClick="btnGetOT_Click"
                                            Text="Get OT" Width="60px" />
                                        <asp:MaskedEditExtender ID="meeTotalHrs" runat="server" AcceptAMPM="false" AcceptNegative="Left"
                                            ErrorTooltipEnabled="true" InputDirection="LeftToRight" Mask="99:99" MaskType="Time"
                                            MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                            TargetControlID="txtHours" UserTimeFormat="None">
                                        </asp:MaskedEditExtender>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label31" runat="server" Text="O.T. Hours &amp; Mins" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOTHours" runat="server" Width="48px" ReadOnly="True" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label26" runat="server" Text="Transport" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTransport" runat="server" Style="text-align: right" Width="88px"
                                            CssClass="textbox">0</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label27" runat="server" Text="Telephone" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTelephone" runat="server" Style="text-align: right" Width="88px"
                                            CssClass="textbox">0</asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Ok" Width="60px"
                                            CssClass="button" ValidationGroup="MKE" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnCancel" runat="server" CssClass="button" OnClick="btnCancel_Click"
                                            Text="Cancel" Width="60px" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="PL_Maintenance" runat="server" Height="265px" Visible="False" BackColor="#ABB1A9"
                            GroupingText="Maintenance" BorderColor="#666633" BorderStyle="Solid" BorderWidth="1px"
                            DefaultButton="btnMSubmit">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label32" runat="server" Text="Claim (Y/N) ?" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_MClaim" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_MClaim_SelectedIndexChanged"
                                            CssClass="dropdownlist">
                                            <asp:ListItem>Y</asp:ListItem>
                                            <asp:ListItem Selected="True">N</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label35" runat="server" Text="OT Type" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_MOTType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_MOTType_SelectedIndexChanged"
                                            CssClass="dropdownlist">
                                            <asp:ListItem Value="N">NORMAL</asp:ListItem>
                                            <asp:ListItem Value="P">PIECE JOB</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label39" runat="server" Text="Second Shift" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_MSShift" runat="server" CssClass="dropdownlist">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>0.5</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label33" runat="server" Text="Telephone" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMTelephone" runat="server" Style="text-align: right" Width="88px"
                                            CssClass="textbox">0</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPCJ" runat="server" Text="PCJ Hrs" CssClass="label" Visible="False"></asp:Label>
                                        <asp:Label ID="lblShift" runat="server" CssClass="label" Text="Shift / Site"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_MShiftSite" runat="server" CssClass="dropdownlist">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>0.5</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddl_MPCJ" runat="server" CssClass="dropdownlist" Visible="False">
                                            <asp:ListItem Value="04:00">4.0</asp:ListItem>
                                            <asp:ListItem Value="08:00">8.0</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label40" runat="server" Text="Job Type" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_MJobType" runat="server" CssClass="dropdownlist">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label34" runat="server" Text="Transport" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMTransport" runat="server" Style="text-align: right" Width="88px"
                                            CssClass="textbox">0</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label37" runat="server" Text="Repair" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_MRepair" runat="server" CssClass="dropdownlist">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>0.5</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label41" runat="server" Text="Job Category" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_MJobCat" runat="server" CssClass="dropdownlist">
                                            <asp:ListItem>H</asp:ListItem>
                                            <asp:ListItem>P</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label38" runat="server" Text="Stand By" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_MStandBy" runat="server" CssClass="dropdownlist">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style3">
                                        Chargeable
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_MFreeMaint" runat="server" CssClass="dropdownlist">
                                            <asp:ListItem>Y</asp:ListItem>
                                            <asp:ListItem Selected="True">N</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label43" runat="server" Text="Reason" CssClass="label"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddl_MReason" runat="server" CssClass="dropdownlist">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label44" runat="server" Text="Total Overtime" CssClass="label"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtMTotHrs" runat="server" Width="48px" ReadOnly="True" CssClass="textbox"></asp:TextBox>
                                        <asp:Button ID="btnGetOT0" runat="server" CssClass="button" OnClick="btnGetOT_Click"
                                            Text="Get OT" Width="60px" />
                                        <asp:MaskedEditExtender ID="meeMTotalHrs" runat="server" AcceptAMPM="false" AcceptNegative="Left"
                                            ErrorTooltipEnabled="true" InputDirection="LeftToRight" Mask="99:99" MaskType="Time"
                                            MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                            TargetControlID="txtHours" UserTimeFormat="None">
                                        </asp:MaskedEditExtender>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label45" runat="server" Text="O.T. Hrs Split" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMOT10" runat="server" Width="48px" ReadOnly="True" CssClass="textbox"></asp:TextBox>
                                        <asp:Label ID="Label74" runat="server" Text="1.0" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="3">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMOT15" runat="server" ReadOnly="True" Width="48px" CssClass="textbox"></asp:TextBox>
                                        <asp:Label ID="Label75" runat="server" Text="1.5" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="3">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMOT20" runat="server" ReadOnly="True" Width="48px" CssClass="textbox"></asp:TextBox>
                                        <asp:Label ID="Label76" runat="server" Text="2.0" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnMSubmit" runat="server" OnClick="btnSubmit_Click" Text="Ok" Width="60px"
                                            CssClass="label" ValidationGroup="MKE" />
                                    </td>
                                    <td colspan="3">
                                        <asp:Button ID="btnMCancel" runat="server" Text="Cancel" Width="60px" OnClick="btnCancel_Click"
                                            CssClass="button" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="PL_Department" runat="server" Height="192px" Visible="False" BackColor="#ABB1A9"
                            GroupingText="Claim" BorderColor="#666633" BorderStyle="Solid" BorderWidth="1px"
                            DefaultButton="btnDSubmit">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label46" runat="server" Text="Claim (Y/N) ?" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_DClaim" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_DClaim_SelectedIndexChanged"
                                            CssClass="dropdownlist">
                                            <asp:ListItem>Y</asp:ListItem>
                                            <asp:ListItem Selected="True">N</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label50" runat="server" Text="Shift / Site" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_DShiftSite" runat="server" CssClass="dropdownlist">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>0.5</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label49" runat="server" Text="Telephone" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDTelephone" runat="server" Style="text-align: right" Width="88px"
                                            CssClass="textbox">0</asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label52" runat="server" Text="Transport" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDTransport" Style="text-align: right" runat="server" Width="88px"
                                            CssClass="textbox">0</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label58" runat="server" Text="Total Overtime" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDTothrs" runat="server" ReadOnly="True" Width="48px" CssClass="textbox"></asp:TextBox>
                                        <asp:Button ID="btnGetOT1" runat="server" CssClass="button" OnClick="btnGetOT_Click"
                                            Text="Get OT" Width="60px" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label59" runat="server" Text="O.T. Hrs Split" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDOT10" runat="server" Width="48px" ReadOnly="True" CssClass="textbox"></asp:TextBox>
                                        <asp:Label ID="Label66" runat="server" Text="1.0" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDOT15" runat="server" Width="48px" ReadOnly="True" CssClass="textbox"></asp:TextBox>
                                        <asp:Label ID="Label67" runat="server" Text="1.5" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td colspan="3">
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDOT20" runat="server" Width="48px" ReadOnly="True" CssClass="textbox"></asp:TextBox>
                                        <asp:Label ID="Label68" runat="server" Text="2.0" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnDSubmit" runat="server" OnClick="btnSubmit_Click" Text="Ok" Width="60px"
                                            CssClass="button" ValidationGroup="MKE" />
                                    </td>
                                    <td colspan="3">
                                        <asp:Button ID="btnDCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                                            Width="60px" CssClass="button" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="PL_Guard" runat="server" Height="168px" Visible="False" BackColor="#ABB1A9"
                            BorderColor="#666633" BorderStyle="Solid" BorderWidth="1px" GroupingText="Guard"
                            DefaultButton="btnGSubmit">
                            <table style="width: 100%;">
                                <tr>
                                    <td class="style2">
                                        <asp:Label ID="Label70" runat="server" Text="Total Overtime" CssClass="label"></asp:Label>
                                    </td>
                                    <td class="style1">
                                        <asp:TextBox ID="txtGTotHrs" runat="server" Width="48px" ReadOnly="True" CssClass="textbox">00:00</asp:TextBox>
                                        <asp:Button ID="btnGetOT2" runat="server" CssClass="button" OnClick="btnGetOT_Click"
                                            Text="Get OT" Width="60px" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        <asp:Label ID="Label69" runat="server" Text="O.T. Hrs Split" CssClass="label"></asp:Label>
                                    </td>
                                    <td class="style1">
                                        <asp:TextBox ID="txtGOT10" runat="server" Width="48px" CssClass="textbox">00:00</asp:TextBox>
                                        <asp:Label ID="Label71" runat="server" Text="1.0" CssClass="label"></asp:Label>
                                        <asp:MaskedEditValidator ID="mevTime10" runat="server" ControlExtender="meeGOT10"
                                            ControlToValidate="txtGOT10" Display="Dynamic" EmptyValueBlurredText="Time is required "
                                            EmptyValueMessage="Time is required " InvalidValueBlurredMessage="Invalid Time"
                                            InvalidValueMessage="Time is invalid" IsValidEmpty="true" ValidationGroup="GKE" />
                                    </td>
                                    <td>
                                        <asp:MaskedEditExtender ID="meeGOT10" runat="server" AcceptAMPM="false" AcceptNegative="Left"
                                            ErrorTooltipEnabled="true" InputDirection="LeftToRight" Mask="99:99" MaskType="Time"
                                            MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                            TargetControlID="txtGOT10" UserTimeFormat="None">
                                        </asp:MaskedEditExtender>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                    </td>
                                    <td class="style1">
                                        <asp:TextBox ID="txtGOT15" runat="server" Width="48px" CssClass="textbox">00:00</asp:TextBox>
                                        <asp:Label ID="Label72" runat="server" Text="1.5" CssClass="label"></asp:Label>
                                        <asp:MaskedEditValidator ID="mevTime15" runat="server" ControlExtender="meeGOT15"
                                            ControlToValidate="txtGOT15" Display="Dynamic" EmptyValueBlurredText="Time is required "
                                            EmptyValueMessage="Time is required " InvalidValueBlurredMessage="Invalid Time"
                                            InvalidValueMessage="Time is invalid" IsValidEmpty="true" ValidationGroup="GKE" />
                                    </td>
                                    <td>
                                        <asp:MaskedEditExtender ID="meeGOT15" runat="server" AcceptAMPM="false" AcceptNegative="Left"
                                            ErrorTooltipEnabled="true" InputDirection="LeftToRight" Mask="99:99" MaskType="Time"
                                            MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                            TargetControlID="txtGOT15" UserTimeFormat="None">
                                        </asp:MaskedEditExtender>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                    </td>
                                    <td class="style1">
                                        <asp:TextBox ID="txtGOT20" runat="server" Width="48px" CssClass="textbox">00:00</asp:TextBox>
                                        <asp:Label ID="Label73" runat="server" Text="2.0" CssClass="label"></asp:Label>
                                        <asp:MaskedEditValidator ID="mevTime20" runat="server" ControlExtender="meeGOT20"
                                            ControlToValidate="txtGOT20" Display="Dynamic" EmptyValueBlurredText="Time is required "
                                            EmptyValueMessage="Time is required " InvalidValueBlurredMessage="Invalid Time"
                                            InvalidValueMessage="Time is invalid" IsValidEmpty="true" ValidationGroup="GKE" />
                                    </td>
                                    <td>
                                        <asp:MaskedEditExtender ID="meeGOT20" runat="server" AcceptAMPM="false" AcceptNegative="Left"
                                            ErrorTooltipEnabled="true" InputDirection="LeftToRight" Mask="99:99" MaskType="Time"
                                            MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                            TargetControlID="txtGOT20" UserTimeFormat="None">
                                        </asp:MaskedEditExtender>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                    </td>
                                    <td colspan="3">
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        <asp:Button ID="btnGSubmit" runat="server" OnClick="btnSubmit_Click" Text="Ok" Width="60px"
                                            ValidationGroup="GKE" CssClass="button" />
                                    </td>
                                    <td colspan="3">
                                        <asp:Button ID="btnGCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                                            Width="60px" CssClass="button" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>                            
                            <tr>
                                <td colspan="3">
                                    <div id="searchDiv" runat="server">
                                        <b>Search OT Entry</b><br />
                                        <br />
                                        EF No :
                                        <asp:TextBox ID="txtSearchEFNo" runat="server"></asp:TextBox><br />
                                        <br />
                                        <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="Search" Height="26px" />
                                    </div>
                                    <br />
                                    <asp:Panel ID="PL_Grid" runat="server" ScrollBars="Auto" Width="814px" Height="463px">
                                        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE"
                                            BorderWidth="1px" CellPadding="4" BorderStyle="None" Font-Size="9pt" OnRowDataBound="GridView1_RowDataBound"
                                            ForeColor="Black" GridLines="Vertical" AllowPaging="True" AllowSorting="True"
                                            PageSize="35" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting">
                                            <RowStyle BackColor="#F7F7DE" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sel">
                                                    <ItemTemplate>
                                                        <cc1:GridViewRowSelector ID="RowSel1" runat="server" />
                                                    </ItemTemplate>
                                                    <ControlStyle Font-Size="8pt" />
                                                    <HeaderStyle Font-Size="9pt" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#CCCC99" />
                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Left" />
                                            <SelectedRowStyle BackColor="DarkGoldenrod" ForeColor="Black" Font-Bold="True" />
                                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style1
        {
            width: 171px;
        }
        .style2
        {
            width: 102px;
        }
        .style3
        {
            font-family: Arial;
            font-size: small;
        }
    </style>
</asp:Content>
