Imports PCES.BusinessLogicLayer
Imports C1.Win.C1FlexGrid
Public Class frmServiceDecisionTable
    Inherits System.Windows.Forms.Form
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabProduct As System.Windows.Forms.TabPage
    Friend WithEvents TabDecisionTable As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TabParameter As System.Windows.Forms.TabPage
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lstCountry As System.Windows.Forms.CheckedListBox
    Friend WithEvents lstModel As System.Windows.Forms.CheckedListBox
    Friend WithEvents txtProdCost As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents chkDefault As System.Windows.Forms.CheckBox
    Friend WithEvents txtProductName As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveAssign As System.Windows.Forms.Button
    Friend WithEvents cbTableName As System.Windows.Forms.ComboBox
    Friend WithEvents btnDeleteDT As System.Windows.Forms.Button
    Friend WithEvents btnSaveDT As System.Windows.Forms.Button
    Friend WithEvents grProduct As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cbEquipment As System.Windows.Forms.ComboBox
    Friend WithEvents cbProductType As System.Windows.Forms.ComboBox
    Friend WithEvents grTable1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents grKeys As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cbServiceGroup As System.Windows.Forms.ComboBox
    Friend WithEvents EE As Expression_EvaluatorControl
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents cbForTableID As System.Windows.Forms.ComboBox
    Friend WithEvents cbForParmCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnMinus As System.Windows.Forms.Button
    Friend WithEvents btnPlus As System.Windows.Forms.Button
    Friend WithEvents grParm As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents grTableDT As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents grpFormula As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnDeleteFormula As System.Windows.Forms.Button
    Friend WithEvents btnSaveFormula As System.Windows.Forms.Button
    Friend WithEvents EEDD As Expression_EvaluatorControl
    Friend WithEvents grComboList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnMinusDT As System.Windows.Forms.Button
    Friend WithEvents btnPlusDT As System.Windows.Forms.Button
    Friend WithEvents grDT As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnCostFormula As System.Windows.Forms.Button
    Friend WithEvents btnQtyFormula As System.Windows.Forms.Button
    Friend WithEvents btnNewRow As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbSubCode As System.Windows.Forms.ComboBox
    Friend WithEvents chkSelectionRequired As System.Windows.Forms.CheckBox
    Friend WithEvents cbUOM As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnDeleteRow As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServiceDecisionTable))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabProduct = New System.Windows.Forms.TabPage
        Me.chkSelectionRequired = New System.Windows.Forms.CheckBox
        Me.cbSubCode = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnNewRow = New System.Windows.Forms.Button
        Me.btnDeleteRow = New System.Windows.Forms.Button
        Me.grKeys = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.chkActive = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lstCountry = New System.Windows.Forms.CheckedListBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lstModel = New System.Windows.Forms.CheckedListBox
        Me.grTable1 = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.txtProdCost = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.chkDefault = New System.Windows.Forms.CheckBox
        Me.txtProductName = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TabParameter = New System.Windows.Forms.TabPage
        Me.cbForTableID = New System.Windows.Forms.ComboBox
        Me.cbForParmCode = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnMinus = New System.Windows.Forms.Button
        Me.btnPlus = New System.Windows.Forms.Button
        Me.grParm = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.btnSaveAssign = New System.Windows.Forms.Button
        Me.cbTableName = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TabDecisionTable = New System.Windows.Forms.TabPage
        Me.grComboList = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.btnQtyFormula = New System.Windows.Forms.Button
        Me.btnCostFormula = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.btnMinusDT = New System.Windows.Forms.Button
        Me.btnPlusDT = New System.Windows.Forms.Button
        Me.grDT = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.grpFormula = New System.Windows.Forms.GroupBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnDeleteFormula = New System.Windows.Forms.Button
        Me.btnSaveFormula = New System.Windows.Forms.Button
        Me.btnDeleteDT = New System.Windows.Forms.Button
        Me.btnSaveDT = New System.Windows.Forms.Button
        Me.grTableDT = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.grProduct = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.Label10 = New System.Windows.Forms.Label
        Me.cbEquipment = New System.Windows.Forms.ComboBox
        Me.cbServiceGroup = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cbProductType = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnExit = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbUOM = New System.Windows.Forms.ComboBox
        Me.EE = New Expression_EvaluatorControl
        Me.EEDD = New Expression_EvaluatorControl
        Me.TabControl1.SuspendLayout()
        Me.TabProduct.SuspendLayout()
        CType(Me.grKeys, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.TabParameter.SuspendLayout()
        CType(Me.grParm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabDecisionTable.SuspendLayout()
        CType(Me.grComboList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grDT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFormula.SuspendLayout()
        CType(Me.grTableDT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabProduct)
        Me.TabControl1.Controls.Add(Me.TabParameter)
        Me.TabControl1.Controls.Add(Me.TabDecisionTable)
        Me.TabControl1.Location = New System.Drawing.Point(16, 230)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1015, 448)
        Me.TabControl1.TabIndex = 176
        '
        'TabProduct
        '
        Me.TabProduct.Controls.Add(Me.cbUOM)
        Me.TabProduct.Controls.Add(Me.Label5)
        Me.TabProduct.Controls.Add(Me.chkSelectionRequired)
        Me.TabProduct.Controls.Add(Me.cbSubCode)
        Me.TabProduct.Controls.Add(Me.Label2)
        Me.TabProduct.Controls.Add(Me.btnNewRow)
        Me.TabProduct.Controls.Add(Me.btnDeleteRow)
        Me.TabProduct.Controls.Add(Me.grKeys)
        Me.TabProduct.Controls.Add(Me.chkActive)
        Me.TabProduct.Controls.Add(Me.Label3)
        Me.TabProduct.Controls.Add(Me.lstCountry)
        Me.TabProduct.Controls.Add(Me.Label4)
        Me.TabProduct.Controls.Add(Me.lstModel)
        Me.TabProduct.Controls.Add(Me.grTable1)
        Me.TabProduct.Controls.Add(Me.txtProdCost)
        Me.TabProduct.Controls.Add(Me.Label1)
        Me.TabProduct.Controls.Add(Me.GroupBox4)
        Me.TabProduct.Controls.Add(Me.chkDefault)
        Me.TabProduct.Controls.Add(Me.txtProductName)
        Me.TabProduct.Controls.Add(Me.Label6)
        Me.TabProduct.Controls.Add(Me.EE)
        Me.TabProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabProduct.Location = New System.Drawing.Point(4, 22)
        Me.TabProduct.Name = "TabProduct"
        Me.TabProduct.Size = New System.Drawing.Size(1007, 422)
        Me.TabProduct.TabIndex = 0
        Me.TabProduct.Text = "Product Details"
        '
        'chkSelectionRequired
        '
        Me.chkSelectionRequired.Location = New System.Drawing.Point(354, 78)
        Me.chkSelectionRequired.Name = "chkSelectionRequired"
        Me.chkSelectionRequired.Size = New System.Drawing.Size(120, 15)
        Me.chkSelectionRequired.TabIndex = 228
        Me.chkSelectionRequired.Text = "Selection Required"
        '
        'cbSubCode
        '
        Me.cbSubCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSubCode.FormattingEnabled = True
        Me.cbSubCode.Location = New System.Drawing.Point(152, 45)
        Me.cbSubCode.Name = "cbSubCode"
        Me.cbSubCode.Size = New System.Drawing.Size(189, 21)
        Me.cbSubCode.TabIndex = 227
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 16)
        Me.Label2.TabIndex = 226
        Me.Label2.Text = "Sub Code"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnNewRow
        '
        Me.btnNewRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNewRow.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNewRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewRow.ForeColor = System.Drawing.Color.ForestGreen
        Me.btnNewRow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNewRow.Location = New System.Drawing.Point(455, 104)
        Me.btnNewRow.Name = "btnNewRow"
        Me.btnNewRow.Size = New System.Drawing.Size(32, 16)
        Me.btnNewRow.TabIndex = 225
        Me.btnNewRow.Text = "+"
        '
        'btnDeleteRow
        '
        Me.btnDeleteRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteRow.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDeleteRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteRow.ForeColor = System.Drawing.Color.Red
        Me.btnDeleteRow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeleteRow.Location = New System.Drawing.Point(487, 104)
        Me.btnDeleteRow.Name = "btnDeleteRow"
        Me.btnDeleteRow.Size = New System.Drawing.Size(32, 16)
        Me.btnDeleteRow.TabIndex = 224
        Me.btnDeleteRow.Text = "-"
        '
        'grKeys
        '
        Me.grKeys.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.grKeys.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.grKeys.ColumnInfo = resources.GetString("grKeys.ColumnInfo")
        Me.grKeys.Location = New System.Drawing.Point(360, 152)
        Me.grKeys.Name = "grKeys"
        Me.grKeys.Rows.Count = 2
        Me.grKeys.Rows.DefaultSize = 17
        Me.grKeys.Size = New System.Drawing.Size(485, 72)
        Me.grKeys.StyleInfo = resources.GetString("grKeys.StyleInfo")
        Me.grKeys.TabIndex = 221
        Me.grKeys.Visible = False
        '
        'chkActive
        '
        Me.chkActive.Location = New System.Drawing.Point(528, 23)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(64, 16)
        Me.chkActive.TabIndex = 223
        Me.chkActive.Text = "Active"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(200, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 215
        Me.Label3.Text = "Excluded Countries"
        '
        'lstCountry
        '
        Me.lstCountry.CheckOnClick = True
        Me.lstCountry.Location = New System.Drawing.Point(200, 120)
        Me.lstCountry.Name = "lstCountry"
        Me.lstCountry.Size = New System.Drawing.Size(176, 109)
        Me.lstCountry.TabIndex = 214
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 16)
        Me.Label4.TabIndex = 213
        Me.Label4.Text = "Assigned Model Type"
        '
        'lstModel
        '
        Me.lstModel.CheckOnClick = True
        Me.lstModel.Location = New System.Drawing.Point(16, 120)
        Me.lstModel.Name = "lstModel"
        Me.lstModel.Size = New System.Drawing.Size(160, 109)
        Me.lstModel.TabIndex = 212
        '
        'grTable1
        '
        Me.grTable1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.grTable1.ColumnInfo = resources.GetString("grTable1.ColumnInfo")
        Me.grTable1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grTable1.ForeColor = System.Drawing.Color.Navy
        Me.grTable1.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Me.grTable1.Location = New System.Drawing.Point(392, 120)
        Me.grTable1.Name = "grTable1"
        Me.grTable1.Rows.Count = 5
        Me.grTable1.Rows.DefaultSize = 17
        Me.grTable1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.grTable1.Size = New System.Drawing.Size(453, 112)
        Me.grTable1.StyleInfo = resources.GetString("grTable1.StyleInfo")
        Me.grTable1.TabIndex = 206
        '
        'txtProdCost
        '
        Me.txtProdCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProdCost.Location = New System.Drawing.Point(216, 72)
        Me.txtProdCost.Name = "txtProdCost"
        Me.txtProdCost.Size = New System.Drawing.Size(125, 20)
        Me.txtProdCost.TabIndex = 185
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 24)
        Me.Label1.TabIndex = 184
        Me.Label1.Text = "Product Cost"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnSave)
        Me.GroupBox4.Controls.Add(Me.btnDelete)
        Me.GroupBox4.Controls.Add(Me.btnAdd)
        Me.GroupBox4.Location = New System.Drawing.Point(851, 23)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(128, 184)
        Me.GroupBox4.TabIndex = 183
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Action"
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(16, 80)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 32)
        Me.btnSave.TabIndex = 180
        Me.btnSave.Text = "Save"
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(16, 128)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(88, 32)
        Me.btnDelete.TabIndex = 181
        Me.btnDelete.Text = "Delete"
        '
        'btnAdd
        '
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(16, 32)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(88, 32)
        Me.btnAdd.TabIndex = 10
        Me.btnAdd.Text = "Add New"
        '
        'chkDefault
        '
        Me.chkDefault.Location = New System.Drawing.Point(152, 76)
        Me.chkDefault.Name = "chkDefault"
        Me.chkDefault.Size = New System.Drawing.Size(64, 16)
        Me.chkDefault.TabIndex = 8
        Me.chkDefault.Text = "Default"
        '
        'txtProductName
        '
        Me.txtProductName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductName.Location = New System.Drawing.Point(152, 15)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.Size = New System.Drawing.Size(360, 20)
        Me.txtProductName.TabIndex = 4
        Me.txtProductName.Text = "CONTROL PANEL"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 16)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Product Name"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabParameter
        '
        Me.TabParameter.Controls.Add(Me.cbForTableID)
        Me.TabParameter.Controls.Add(Me.cbForParmCode)
        Me.TabParameter.Controls.Add(Me.Label7)
        Me.TabParameter.Controls.Add(Me.btnMinus)
        Me.TabParameter.Controls.Add(Me.btnPlus)
        Me.TabParameter.Controls.Add(Me.grParm)
        Me.TabParameter.Controls.Add(Me.btnSaveAssign)
        Me.TabParameter.Controls.Add(Me.cbTableName)
        Me.TabParameter.Controls.Add(Me.Label12)
        Me.TabParameter.Location = New System.Drawing.Point(4, 22)
        Me.TabParameter.Name = "TabParameter"
        Me.TabParameter.Size = New System.Drawing.Size(1007, 422)
        Me.TabParameter.TabIndex = 2
        Me.TabParameter.Text = "Assign Parameters"
        '
        'cbForTableID
        '
        Me.cbForTableID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbForTableID.Location = New System.Drawing.Point(400, 104)
        Me.cbForTableID.Name = "cbForTableID"
        Me.cbForTableID.Size = New System.Drawing.Size(24, 21)
        Me.cbForTableID.TabIndex = 208
        Me.cbForTableID.Visible = False
        '
        'cbForParmCode
        '
        Me.cbForParmCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbForParmCode.Location = New System.Drawing.Point(368, 104)
        Me.cbForParmCode.Name = "cbForParmCode"
        Me.cbForParmCode.Size = New System.Drawing.Size(24, 21)
        Me.cbForParmCode.TabIndex = 207
        Me.cbForParmCode.Visible = False
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(48, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 16)
        Me.Label7.TabIndex = 206
        Me.Label7.Text = "Assigned Parameters"
        '
        'btnMinus
        '
        Me.btnMinus.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMinus.ForeColor = System.Drawing.Color.Red
        Me.btnMinus.Location = New System.Drawing.Point(264, 112)
        Me.btnMinus.Name = "btnMinus"
        Me.btnMinus.Size = New System.Drawing.Size(24, 16)
        Me.btnMinus.TabIndex = 205
        Me.btnMinus.Text = "-"
        '
        'btnPlus
        '
        Me.btnPlus.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlus.ForeColor = System.Drawing.Color.Green
        Me.btnPlus.Location = New System.Drawing.Point(216, 112)
        Me.btnPlus.Name = "btnPlus"
        Me.btnPlus.Size = New System.Drawing.Size(24, 16)
        Me.btnPlus.TabIndex = 204
        Me.btnPlus.Text = "+"
        '
        'grParm
        '
        Me.grParm.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll
        Me.grParm.ColumnInfo = resources.GetString("grParm.ColumnInfo")
        Me.grParm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grParm.ForeColor = System.Drawing.Color.Navy
        Me.grParm.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Me.grParm.Location = New System.Drawing.Point(48, 128)
        Me.grParm.Name = "grParm"
        Me.grParm.Rows.Count = 1
        Me.grParm.Rows.DefaultSize = 17
        Me.grParm.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.grParm.Size = New System.Drawing.Size(768, 160)
        Me.grParm.StyleInfo = resources.GetString("grParm.StyleInfo")
        Me.grParm.TabIndex = 203
        '
        'btnSaveAssign
        '
        Me.btnSaveAssign.Image = CType(resources.GetObject("btnSaveAssign.Image"), System.Drawing.Image)
        Me.btnSaveAssign.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAssign.Location = New System.Drawing.Point(536, 56)
        Me.btnSaveAssign.Name = "btnSaveAssign"
        Me.btnSaveAssign.Size = New System.Drawing.Size(104, 32)
        Me.btnSaveAssign.TabIndex = 182
        Me.btnSaveAssign.Text = "Save"
        '
        'cbTableName
        '
        Me.cbTableName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTableName.ItemHeight = 13
        Me.cbTableName.Location = New System.Drawing.Point(200, 64)
        Me.cbTableName.Name = "cbTableName"
        Me.cbTableName.Size = New System.Drawing.Size(288, 21)
        Me.cbTableName.TabIndex = 179
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(48, 64)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(144, 24)
        Me.Label12.TabIndex = 178
        Me.Label12.Text = "Table Name"
        '
        'TabDecisionTable
        '
        Me.TabDecisionTable.Controls.Add(Me.grComboList)
        Me.TabDecisionTable.Controls.Add(Me.btnQtyFormula)
        Me.TabDecisionTable.Controls.Add(Me.btnCostFormula)
        Me.TabDecisionTable.Controls.Add(Me.Label9)
        Me.TabDecisionTable.Controls.Add(Me.btnMinusDT)
        Me.TabDecisionTable.Controls.Add(Me.btnPlusDT)
        Me.TabDecisionTable.Controls.Add(Me.grDT)
        Me.TabDecisionTable.Controls.Add(Me.grpFormula)
        Me.TabDecisionTable.Controls.Add(Me.btnDeleteDT)
        Me.TabDecisionTable.Controls.Add(Me.btnSaveDT)
        Me.TabDecisionTable.Controls.Add(Me.grTableDT)
        Me.TabDecisionTable.Location = New System.Drawing.Point(4, 22)
        Me.TabDecisionTable.Name = "TabDecisionTable"
        Me.TabDecisionTable.Size = New System.Drawing.Size(1007, 422)
        Me.TabDecisionTable.TabIndex = 1
        Me.TabDecisionTable.Text = "Decision Table"
        '
        'grComboList
        '
        Me.grComboList.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.grComboList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.grComboList.ColumnInfo = resources.GetString("grComboList.ColumnInfo")
        Me.grComboList.Location = New System.Drawing.Point(400, 112)
        Me.grComboList.Name = "grComboList"
        Me.grComboList.Rows.Count = 2
        Me.grComboList.Rows.DefaultSize = 17
        Me.grComboList.Size = New System.Drawing.Size(312, 72)
        Me.grComboList.StyleInfo = resources.GetString("grComboList.StyleInfo")
        Me.grComboList.TabIndex = 224
        Me.grComboList.Visible = False
        '
        'btnQtyFormula
        '
        Me.btnQtyFormula.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnQtyFormula.Location = New System.Drawing.Point(440, 168)
        Me.btnQtyFormula.Name = "btnQtyFormula"
        Me.btnQtyFormula.Size = New System.Drawing.Size(104, 32)
        Me.btnQtyFormula.TabIndex = 226
        Me.btnQtyFormula.Text = "Qty Formula"
        '
        'btnCostFormula
        '
        Me.btnCostFormula.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCostFormula.Location = New System.Drawing.Point(328, 168)
        Me.btnCostFormula.Name = "btnCostFormula"
        Me.btnCostFormula.Size = New System.Drawing.Size(104, 32)
        Me.btnCostFormula.TabIndex = 225
        Me.btnCostFormula.Text = "Cost Formula"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(328, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 16)
        Me.Label9.TabIndex = 223
        Me.Label9.Text = "Decision Table"
        '
        'btnMinusDT
        '
        Me.btnMinusDT.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMinusDT.ForeColor = System.Drawing.Color.Red
        Me.btnMinusDT.Location = New System.Drawing.Point(440, 16)
        Me.btnMinusDT.Name = "btnMinusDT"
        Me.btnMinusDT.Size = New System.Drawing.Size(24, 16)
        Me.btnMinusDT.TabIndex = 222
        Me.btnMinusDT.Text = "-"
        '
        'btnPlusDT
        '
        Me.btnPlusDT.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlusDT.ForeColor = System.Drawing.Color.Green
        Me.btnPlusDT.Location = New System.Drawing.Point(408, 16)
        Me.btnPlusDT.Name = "btnPlusDT"
        Me.btnPlusDT.Size = New System.Drawing.Size(24, 16)
        Me.btnPlusDT.TabIndex = 221
        Me.btnPlusDT.Text = "+"
        '
        'grDT
        '
        Me.grDT.ColumnInfo = "3,0,0,0,0,85,Columns:0{Width:105;Caption:""EMC"";AllowMerging:True;Style:""DataType:" & _
            "System.String;TextAlign:LeftCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Width:111;Caption:""Cost"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:355;" & _
            "Caption:""Cost Formula"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.grDT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grDT.ForeColor = System.Drawing.Color.Navy
        Me.grDT.Location = New System.Drawing.Point(328, 32)
        Me.grDT.Name = "grDT"
        Me.grDT.Rows.Count = 1
        Me.grDT.Rows.DefaultSize = 17
        Me.grDT.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.grDT.Size = New System.Drawing.Size(600, 128)
        Me.grDT.StyleInfo = resources.GetString("grDT.StyleInfo")
        Me.grDT.TabIndex = 220
        '
        'grpFormula
        '
        Me.grpFormula.Controls.Add(Me.btnCancel)
        Me.grpFormula.Controls.Add(Me.btnDeleteFormula)
        Me.grpFormula.Controls.Add(Me.btnSaveFormula)
        Me.grpFormula.Controls.Add(Me.EEDD)
        Me.grpFormula.Location = New System.Drawing.Point(16, 200)
        Me.grpFormula.Name = "grpFormula"
        Me.grpFormula.Size = New System.Drawing.Size(912, 216)
        Me.grpFormula.TabIndex = 193
        Me.grpFormula.TabStop = False
        Me.grpFormula.Text = "Cost Formula"
        Me.grpFormula.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(256, 192)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(128, 24)
        Me.btnCancel.TabIndex = 47
        Me.btnCancel.Text = "Cancel"
        '
        'btnDeleteFormula
        '
        Me.btnDeleteFormula.Image = CType(resources.GetObject("btnDeleteFormula.Image"), System.Drawing.Image)
        Me.btnDeleteFormula.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeleteFormula.Location = New System.Drawing.Point(392, 192)
        Me.btnDeleteFormula.Name = "btnDeleteFormula"
        Me.btnDeleteFormula.Size = New System.Drawing.Size(128, 24)
        Me.btnDeleteFormula.TabIndex = 46
        Me.btnDeleteFormula.Text = "Delete Formula"
        '
        'btnSaveFormula
        '
        Me.btnSaveFormula.Image = CType(resources.GetObject("btnSaveFormula.Image"), System.Drawing.Image)
        Me.btnSaveFormula.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveFormula.Location = New System.Drawing.Point(528, 192)
        Me.btnSaveFormula.Name = "btnSaveFormula"
        Me.btnSaveFormula.Size = New System.Drawing.Size(128, 24)
        Me.btnSaveFormula.TabIndex = 45
        Me.btnSaveFormula.Text = "Save Formula"
        '
        'btnDeleteDT
        '
        Me.btnDeleteDT.Image = CType(resources.GetObject("btnDeleteDT.Image"), System.Drawing.Image)
        Me.btnDeleteDT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeleteDT.Location = New System.Drawing.Point(776, 168)
        Me.btnDeleteDT.Name = "btnDeleteDT"
        Me.btnDeleteDT.Size = New System.Drawing.Size(72, 32)
        Me.btnDeleteDT.TabIndex = 191
        Me.btnDeleteDT.Text = "Delete"
        '
        'btnSaveDT
        '
        Me.btnSaveDT.Image = CType(resources.GetObject("btnSaveDT.Image"), System.Drawing.Image)
        Me.btnSaveDT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveDT.Location = New System.Drawing.Point(856, 168)
        Me.btnSaveDT.Name = "btnSaveDT"
        Me.btnSaveDT.Size = New System.Drawing.Size(72, 32)
        Me.btnSaveDT.TabIndex = 190
        Me.btnSaveDT.Text = "Save"
        '
        'grTableDT
        '
        Me.grTableDT.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll
        Me.grTableDT.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:56;Caption:""Table No"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Width:183;Caption:""Table N" & _
            "ame"";AllowMerging:True;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.grTableDT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grTableDT.ForeColor = System.Drawing.Color.Navy
        Me.grTableDT.Location = New System.Drawing.Point(16, 32)
        Me.grTableDT.Name = "grTableDT"
        Me.grTableDT.Rows.Count = 1
        Me.grTableDT.Rows.DefaultSize = 17
        Me.grTableDT.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.grTableDT.Size = New System.Drawing.Size(304, 128)
        Me.grTableDT.StyleInfo = resources.GetString("grTableDT.StyleInfo")
        Me.grTableDT.TabIndex = 166
        '
        'grProduct
        '
        Me.grProduct.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll
        Me.grProduct.ColumnInfo = resources.GetString("grProduct.ColumnInfo")
        Me.grProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grProduct.ForeColor = System.Drawing.Color.Navy
        Me.grProduct.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Me.grProduct.Location = New System.Drawing.Point(24, 48)
        Me.grProduct.Name = "grProduct"
        Me.grProduct.Rows.Count = 2
        Me.grProduct.Rows.DefaultSize = 17
        Me.grProduct.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.grProduct.Size = New System.Drawing.Size(1007, 176)
        Me.grProduct.StyleInfo = resources.GetString("grProduct.StyleInfo")
        Me.grProduct.TabIndex = 177
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(24, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 21)
        Me.Label10.TabIndex = 215
        Me.Label10.Text = "Equipment"
        '
        'cbEquipment
        '
        Me.cbEquipment.BackColor = System.Drawing.SystemColors.Info
        Me.cbEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEquipment.Location = New System.Drawing.Point(112, 16)
        Me.cbEquipment.Name = "cbEquipment"
        Me.cbEquipment.Size = New System.Drawing.Size(88, 21)
        Me.cbEquipment.TabIndex = 214
        '
        'cbServiceGroup
        '
        Me.cbServiceGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbServiceGroup.Items.AddRange(New Object() {"Installation", "Maintenance"})
        Me.cbServiceGroup.Location = New System.Drawing.Point(304, 16)
        Me.cbServiceGroup.Name = "cbServiceGroup"
        Me.cbServiceGroup.Size = New System.Drawing.Size(278, 21)
        Me.cbServiceGroup.TabIndex = 217
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(216, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 21)
        Me.Label14.TabIndex = 216
        Me.Label14.Text = "Service Group"
        '
        'cbProductType
        '
        Me.cbProductType.BackColor = System.Drawing.SystemColors.Info
        Me.cbProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbProductType.Location = New System.Drawing.Point(697, 16)
        Me.cbProductType.Name = "cbProductType"
        Me.cbProductType.Size = New System.Drawing.Size(104, 21)
        Me.cbProductType.TabIndex = 219
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(601, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 21)
        Me.Label11.TabIndex = 218
        Me.Label11.Text = "Product Type"
        '
        'btnExit
        '
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(880, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(88, 25)
        Me.btnExit.TabIndex = 222
        Me.btnExit.Text = "&Exit"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(351, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 16)
        Me.Label5.TabIndex = 229
        Me.Label5.Text = "UOM"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbUOM
        '
        Me.cbUOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUOM.FormattingEnabled = True
        Me.cbUOM.Items.AddRange(New Object() {"", "Per Equipment", "Common"})
        Me.cbUOM.Location = New System.Drawing.Point(392, 45)
        Me.cbUOM.Name = "cbUOM"
        Me.cbUOM.Size = New System.Drawing.Size(120, 21)
        Me.cbUOM.TabIndex = 230
        '
        'EE
        '
        Me.EE.DecisionTableType = Nothing
        Me.EE.DecisionTableTypeID = 0
        Me.EE.EquipmentCode = 0
        Me.EE.GroupCode = ""
        Me.EE.Location = New System.Drawing.Point(8, 240)
        Me.EE.Name = "EE"
        Me.EE.ProductType = 0
        Me.EE.RoundingBoundry = New Decimal(New Integer() {0, 0, 0, 0})
        Me.EE.ServiceType = 0
        Me.EE.Size = New System.Drawing.Size(837, 168)
        Me.EE.TabIndex = 222
        '
        'EEDD
        '
        Me.EEDD.DecisionTableType = Nothing
        Me.EEDD.DecisionTableTypeID = 0
        Me.EEDD.EquipmentCode = 0
        Me.EEDD.GroupCode = ""
        Me.EEDD.Location = New System.Drawing.Point(8, 16)
        Me.EEDD.Name = "EEDD"
        Me.EEDD.ProductType = 0
        Me.EEDD.RoundingBoundry = New Decimal(New Integer() {0, 0, 0, 0})
        Me.EEDD.ServiceType = 0
        Me.EEDD.Size = New System.Drawing.Size(760, 168)
        Me.EEDD.TabIndex = 44
        '
        'frmServiceDecisionTable
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1043, 694)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.cbProductType)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cbServiceGroup)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cbEquipment)
        Me.Controls.Add(Me.grProduct)
        Me.Controls.Add(Me.TabControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServiceDecisionTable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Service Cost Table Configuration"
        Me.TabControl1.ResumeLayout(False)
        Me.TabProduct.ResumeLayout(False)
        Me.TabProduct.PerformLayout()
        CType(Me.grKeys, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.TabParameter.ResumeLayout(False)
        CType(Me.grParm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabDecisionTable.ResumeLayout(False)
        CType(Me.grComboList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grDT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFormula.ResumeLayout(False)
        CType(Me.grTableDT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim Mode As String
    Dim dsTable As DataSet
    Dim dsTableTemp As DataSet
    Dim parmCount As Integer
    Dim CostColumn As Integer
    Dim QtyColumn As Integer
    Dim Parm(10, 4) As String
    Dim dsSubCode As DataSet
    Public selProductId As Integer
    Private Sub FillEquipment()
        'FILL EQUIPMENT COMBO BOX
        Dim objEq As New PCESEquipment
        Dim colEq As New PCESEquipmentCollection
        cbEquipment.Items.Clear()
        Try
            colEq = objEq.GetEquipments()
            For Each objEq In colEq
                cbEquipment.Items.Add(objEq)
            Next
            cbEquipment.DisplayMember = "Description"
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Fill Equipment", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FillProductType()
        'FILL PRODUCT TYPE COMBO BOX
        With cbProductType
            .Items.Clear()
            .Items.Add("Main")
            .Items.Add("Additional")
            .SelectedIndex = 0
        End With
    End Sub
    Private Sub FillServiceGroup()
        'FILL SERVICE GROUP COMBO BOX
        Dim objSG As New PCESServiceGroup
        Dim ds As New DataSet
        cbServiceGroup.Items.Clear()
        Try
            ds = objSG.GetServiceGroup()
            cbServiceGroup.DataSource = ds.Tables(0)
            cbServiceGroup.DisplayMember = "ServiceName"
            cbServiceGroup.ValueMember = "Id"
            cbServiceGroup.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fill Service Group", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'With cbServiceGroup
        '    .Items.Clear()
        '    .Items.Add("Import")
        '    .Items.Add("Installation")
        '    .Items.Add("Testing & Commissioning")
        '    .Items.Add("Maintenance")
        '    .Items.Add("External Wiring")
        '    .Items.Add("Spary Painting")
        '    .SelectedIndex = 0
        'End With
    End Sub
    Private Sub FillKeys()
        Dim objProduct As PCESProduct
        Dim dsKeys As DataSet
        Try
            dsKeys = objProduct.GetFieldSelectionKeyAsDataset()
            grKeys.DataSource = dsKeys.Tables(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fill Keys", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FillModel()
        Dim clsModel As New PCESModel
        Dim colModel As PCESModelCollection
        If cbEquipment.SelectedIndex = -1 Then
            Exit Sub
        End If
        lstModel.Items.Clear()
        'TO FILL DEFAULT VALUES
        Try
            colModel = clsModel.GetModel(cbEquipment.Items(cbEquipment.SelectedIndex).EquipmentCode.ToString)
            For Each clsModel In colModel
                lstModel.Items.Add(clsModel)
            Next
            lstModel.DisplayMember = "ModelType"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fill Model", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FillCountry()
        Dim clsCountry As New PCESCountry
        Dim colCountry As PCESCountryCollection
        'TO FILL DEFAULT VALUES
        lstCountry.Items.Clear()
        Try
            colCountry = clsCountry.GetCountry()
            For Each clsCountry In colCountry
                lstCountry.Items.Add(clsCountry)
            Next
            lstCountry.DisplayMember = "CountryName"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fill Country", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FillProduct()
        Dim objProduct As New PCESProduct
        Dim clsProduct As New PCESProductCollection
        Dim i As Integer
        grKeys.Visible = False
        ClearProductDetailsWindow()
        ClearAssignParametersWindow()
        ClearDecisionTableWindow()
        grProduct_Settings()
        grDT_Settings()
        'grParameterValues_Settings()
        'grLink_Settings()
        If cbEquipment.SelectedIndex = -1 Or cbServiceGroup.SelectedIndex = -1 Or cbProductType.SelectedIndex = -1 Then
            Exit Sub
        End If
        Try
            clsProduct = objProduct.GetServiceDefinition(cbEquipment.Items(cbEquipment.SelectedIndex).EquipmentCode, cbProductType.SelectedIndex + 1, cbServiceGroup.SelectedValue)
            i = 1
            With grProduct
                For Each objProduct In clsProduct
                    .Rows.Add()
                    .Item(i, 0) = objProduct.ProductID
                    .Item(i, 1) = objProduct.FormulaID
                    .Item(i, 2) = objProduct.EquipmentCode
                    .Item(i, 3) = objProduct.ProductType
                    .Item(i, 4) = objProduct.ServiceType
                    .Item(i, 5) = objProduct.ProductName
                    .Item(i, 6) = Convert.ToString(objProduct.SubCode)
                    .Item(i, 7) = objProduct.FormulaDesc
                    .Item(i, 8) = objProduct.UOM
                    .Item(i, 9) = objProduct.IsActive
                    .Item(i, 10) = objProduct.IsDefault
                    .Item(i, 11) = If(objProduct.SelectionRequired = Nothing Or IsDBNull(objProduct.SelectionRequired), False, objProduct.SelectionRequired)
                    .Item(i, 12) = objProduct.ProductCost
                    i = i + 1
                Next
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fill Product", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ''FILLING HIDDEN PRODUCT COMBO
        'Try
        '    clsProduct = objProduct.GetProduct(cbEquipment.Items(cbEquipment.SelectedIndex).EquipmentCode, cbMtlGroup.Text.Trim, cbModel.Text.Trim, 1)
        '    cbHiddenProducts.Items.Clear()
        '    pn = ""
        '    For Each objProduct In clsProduct
        '        cbHiddenProducts.Items.Add(objProduct)
        '        pn = pn & "|" & objProduct.ProductName
        '    Next
        '    cbHiddenProducts.DisplayMember = "ProductName"
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Populate Main Products", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub
    Private Sub PopulateProduct()
        Dim objModel As New PCESModel
        Dim clsModel As New PCESModelCollection
        Dim objCountry As New PCESCountry
        Dim clsCountry As New PCESCountryCollection
        Dim objTable As New PCESTable
        Dim clsTable As PCESTableCollection
        Dim i As Integer
        Select Case TabControl1.SelectedIndex
            Case 0
                selProductId = Convert.ToInt32(Convert.ToString(grProduct.Item(grProduct.RowSel, 0)))
                txtProductName.Text = grProduct.Item(grProduct.RowSel, 5)
                'txtSubCode.Text = grProduct.Item(grProduct.RowSel, 6)
                cbSubCode.SelectedIndex = cbSubCode.FindStringExact(Convert.ToString(grProduct.Item(grProduct.RowSel, 6)))
                EE.txtFormula.Text = grProduct.Item(grProduct.RowSel, 7)
                cbUOM.SelectedIndex = cbUOM.FindStringExact(Convert.ToString(grProduct.Item(grProduct.RowSel, 8)))
                chkActive.Checked = grProduct.Item(grProduct.RowSel, 9)
                chkDefault.Checked = grProduct.Item(grProduct.RowSel, 10)
                chkSelectionRequired.Checked = grProduct.Item(grProduct.RowSel, 11)
                txtProdCost.Text = grProduct.Item(grProduct.RowSel, 12)

                'ASSIGNED MODELS
                Try
                    clsModel = objModel.GetProductAssignedModel(CInt(grProduct.Item(grProduct.RowSel, 0)), "4")
                    'POPULATING ASSIGNED MODELS
                    For Each objModel In clsModel
                        With lstModel
                            For i = 0 To .Items.Count - 1
                                If .Items(i).ModelType.ToString.ToUpper.Trim = objModel.ModelType.ToUpper.Trim Then
                                    .SetItemChecked(i, True)
                                End If
                            Next i
                        End With
                    Next
                Catch Ex As Exception
                    MessageBox.Show(Ex.Message, "Populate Product Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
                'EXCLUDED COUNTRIES
                Try
                    clsCountry = objCountry.GetProductExcludedCountry(CInt(grProduct.Item(grProduct.RowSel, 0)), "4")
                    'POPULATING EXCLUDED COUNTRIES
                    For Each objCountry In clsCountry
                        With lstCountry
                            For i = 0 To .Items.Count - 1
                                If .Items(i).CountryCode.ToString.ToUpper.Trim = objCountry.CountryCode.ToUpper.Trim Then
                                    .SetItemChecked(i, True)
                                End If
                            Next i
                        End With
                    Next
                Catch Ex As Exception
                    MessageBox.Show(Ex.Message, "Populate Product Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
                'POPULATING TABLES
                Try
                    grTable1_Settings()
                    dsTable = objTable.GetTableAsDataset(grProduct.Item(grProduct.RowSel, 0), 4)
                    dsTableTemp = objTable.GetTableAsDataset(grProduct.Item(grProduct.RowSel, 0), 4)
                    grTable1.DataSource = dsTable.Tables(0)
                    If chkDefault.Checked = True Then
                        If grTable1.Rows.Count > 1 Then
                            btnNewRow.Enabled = False
                        End If
                    End If
                    dsTable.Tables(0).Columns(0).Caption = "Table Name"
                    For i = 0 To grTable1.Cols.Count - 1
                        grTable1.Cols(i).Visible = False
                    Next i
                    grTable1.Cols(4).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                    With grTable1
                        '-----
                        .Cols(3).Caption = "Table No"
                        .Cols(3).Width = 50
                        .Cols(3).DataType = GetType(String)
                        .Cols(3).Visible = True
                        '-----
                        .Cols(4).Caption = "Table Name"
                        .Cols(4).Width = 250
                        .Cols(4).DataType = GetType(String)
                        .Cols(4).Visible = True
                        '-----
                        .Cols(5).Caption = "Key"
                        .Cols(5).Width = 50
                        .Cols(5).DataType = GetType(String)
                        .Cols(5).Visible = True
                        .Cols(5).ComboList = "..."
                    End With
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Populate Product Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                EE.DecisionTableType = "SERVICECOST"
                EE.EquipmentCode = cbEquipment.Items(cbEquipment.SelectedIndex).EquipmentCode
                EE.ProductType = cbProductType.SelectedIndex + 1
                EE.ServiceType = cbServiceGroup.SelectedValue
                EE.DecisionTableTypeID = grProduct.Item(grProduct.RowSel, 1)
                EE.FillGrid()
                EE.DecisionTableTypeID = grProduct.Item(grProduct.RowSel, 0)
            Case 1
                'FillParameter()
                cbTableName.Items.Clear()
                If grProduct.Item(grProduct.RowSel, 10) = True Then Exit Sub 'IF DEFAULT, THEN THERE IS NO DECISION TABLE
                clsTable = objTable.GetTable(grProduct.Item(grProduct.RowSel, 0), "4")
                dsTableTemp = objTable.GetTableAsDataset(grProduct.Item(grProduct.RowSel, 0), "4")
                For Each objTable In clsTable
                    cbTableName.Items.Add(objTable)
                Next
                cbTableName.DisplayMember = "TableName"
            Case 2
                If grProduct.Item(grProduct.RowSel, 10) = True Then Exit Sub 'IF DEFAULT, THEN THERE IS NO DECISION TABLE
                clsTable = objTable.GetTable(grProduct.Item(grProduct.RowSel, 0), "4")
                dsTableTemp = objTable.GetTableAsDataset(grProduct.Item(grProduct.RowSel, 0), "4")
                For Each objTable In clsTable
                    grTableDT.Rows.Add()
                    grTableDT.Item(grTableDT.Rows.Count - 1, 0) = objTable.TableID
                    grTableDT.Item(grTableDT.Rows.Count - 1, 1) = objTable.TableRef
                    grTableDT.Item(grTableDT.Rows.Count - 1, 2) = objTable.TableName
                    grTableDT.Item(grTableDT.Rows.Count - 1, 3) = objTable.FieldSelectionKey
                Next
        End Select
    End Sub
    Private Sub PopulateDecisionTable()
        If grTableDT.Rows.Count <= 1 Then Exit Sub
        Dim objTable As PCESTable
        Dim colTable As PCESTableCollection
        Dim curParmCode, i, j, k, colCount, rowFound As Integer
        Dim parmCol, s As String
        Dim vRef As String
        Dim vQty, vCost, vFactor, vFixHr, vVarHr As Double
        Dim HasAssignedTables As Boolean
        Dim noOfPipe() As String
        parmCount = 0
        grDT_Settings()
        EEDD.grFormParm_Settings()
        EEDD.txtFormula.Text = ""
        EEDD.txtResult.Text = ""
        grpFormula.Visible = False
        Try
            colTable = objTable.GetDecisionTableItem(grProduct.Item(grProduct.RowSel, 0), "4", grTableDT.Item(grTableDT.RowSel, 0))
            grDT.Cols.Add()
            colCount = 1
            grDT.Cols(colCount - 1).Caption = "ParmCollection"
            grDT.Cols(colCount - 1).Visible = False
            'grDT.Cols.Add()
            HasAssignedTables = False
            btnPlusDT.Enabled = True
            btnMinusDT.Enabled = True
            For Each objTable In colTable
                'If objTable.ParmCode <> curParmCode Then
                colCount = colCount + 1
                curParmCode = objTable.ParmCode
                If colCount > grDT.Cols.Count Then grDT.Cols.Add()
                If objTable.DataSource = 2 Then
                    Parm(parmCount, 1) = objTable.RefTableID
                    Parm(parmCount, 2) = objTable.ParmDescription.ToUpper.Trim
                    Parm(parmCount, 3) = objTable.DataSource
                    Parm(parmCount, 4) = objTable.ParmFormat.ToUpper.Trim
                    grDT.Cols(colCount - 1).Caption = objTable.RefTableRef.Trim & "." & objTable.ParmDescription.Trim
                Else
                    Parm(parmCount, 1) = objTable.ParmCode
                    Parm(parmCount, 2) = objTable.ParmDescription.ToUpper.Trim
                    Parm(parmCount, 3) = objTable.DataSource
                    Parm(parmCount, 4) = objTable.ParmFormat.ToUpper.Trim
                    grDT.Cols(colCount - 1).Caption = objTable.ParmDescription.Trim
                End If
                parmCount = parmCount + 1
                If objTable.ParmFormat.ToUpper.Trim = "CHARACTER" Then grDT.Cols(colCount - 1).ComboList = "..."
                'grDT.Cols(colCount - 1).ComboList = "..."
                grDT.Cols(colCount - 1).TextAlignFixed = TextAlignEnum.GeneralCenter
                grDT.Cols(colCount - 1).DataType = GetType(String)
                HasAssignedTables = True
                'End If
            Next
            'If HasAssignedTables = False Then
            '    btnPlusDT.Enabled = False
            '    btnMinusDT.Enabled = False
            'End If
            'TO CREATE ADDITIONAL COLUMNS BASED ON FIELD SELECTION KEY
            CostColumn = 0
            QtyColumn = 0
            btnQtyFormula.Enabled = False
            btnCostFormula.Enabled = False
            rowFound = grKeys.FindRow(grTableDT.Item(grTableDT.RowSel, 3), 1, 0, False)
            If rowFound <> -1 Then
                For i = 1 To grKeys.Cols.Count - 1
                    If grKeys.Item(rowFound, i) = True Then
                        If InStr(grKeys.Item(0, i), "Sum") = 0 Then
                            grDT.Cols.Add()
                            grDT.Cols(grDT.Cols.Count - 1).TextAlignFixed = TextAlignEnum.GeneralCenter
                            grDT.Cols(grDT.Cols.Count - 1).Caption = Replace(grKeys.Item(0, i), "Flag", "")
                            If grDT.Cols(grDT.Cols.Count - 1).Caption.ToUpper.Trim = "REF" Then
                                grDT.Cols(grDT.Cols.Count - 1).DataType = GetType(String)
                            ElseIf grDT.Cols(grDT.Cols.Count - 1).Caption.ToUpper.Trim = "QTY" Then
                                grDT.Cols(grDT.Cols.Count - 1).DataType = GetType(Double)
                                btnQtyFormula.Enabled = True
                                'COLUMN FOR 'COST FORMULA' DESCRIPTION
                                QtyColumn = grDT.Cols.Count - 1
                                grDT.Cols.Add()
                                grDT.Cols(grDT.Cols.Count - 1).TextAlignFixed = TextAlignEnum.GeneralCenter
                                grDT.Cols(grDT.Cols.Count - 1).DataType = GetType(String)
                                grDT.Cols(grDT.Cols.Count - 1).Caption = "Qty Formula"
                                grDT.Cols(grDT.Cols.Count - 1).Width = 150
                                grDT.Cols(grDT.Cols.Count - 1).Visible = True
                                grDT.Cols(grDT.Cols.Count - 1).AllowEditing = False
                                'COLUMN FOR COST FORMULA ID
                                grDT.Cols.Add()
                                grDT.Cols(grDT.Cols.Count - 1).TextAlignFixed = TextAlignEnum.GeneralCenter
                                grDT.Cols(grDT.Cols.Count - 1).DataType = GetType(Integer)
                                grDT.Cols(grDT.Cols.Count - 1).Caption = "Qty FormulaID"
                                grDT.Cols(grDT.Cols.Count - 1).Visible = False
                            ElseIf grDT.Cols(grDT.Cols.Count - 1).Caption.ToUpper.Trim = "COST" Then
                                grDT.Cols(grDT.Cols.Count - 1).DataType = GetType(Double)
                                btnCostFormula.Enabled = True
                                'COLUMN FOR 'COST FORMULA' DESCRIPTION
                                CostColumn = grDT.Cols.Count - 1
                                grDT.Cols.Add()
                                grDT.Cols(grDT.Cols.Count - 1).TextAlignFixed = TextAlignEnum.GeneralCenter
                                grDT.Cols(grDT.Cols.Count - 1).DataType = GetType(String)
                                grDT.Cols(grDT.Cols.Count - 1).Caption = "Cost Formula"
                                grDT.Cols(grDT.Cols.Count - 1).Width = 150
                                grDT.Cols(grDT.Cols.Count - 1).Visible = True
                                grDT.Cols(grDT.Cols.Count - 1).AllowEditing = False
                                'COLUMN FOR COST FORMULA ID
                                grDT.Cols.Add()
                                grDT.Cols(grDT.Cols.Count - 1).TextAlignFixed = TextAlignEnum.GeneralCenter
                                grDT.Cols(grDT.Cols.Count - 1).DataType = GetType(Integer)
                                grDT.Cols(grDT.Cols.Count - 1).Caption = "Cost FormulaID"
                                grDT.Cols(grDT.Cols.Count - 1).Visible = False
                            Else
                                grDT.Cols(grDT.Cols.Count - 1).DataType = GetType(Double)
                            End If
                        End If
                    End If
                Next i
            End If
            ''COLUMN FOR 'COST FORMULA' DESCRIPTION
            'grDT.Cols.Add()
            'grDT.Cols(grDT.Cols.Count - 1).TextAlignFixed = TextAlignEnum.GeneralCenter
            'grDT.Cols(grDT.Cols.Count - 1).DataType = GetType(String)
            'grDT.Cols(grDT.Cols.Count - 1).Caption = "Formula"
            'grDT.Cols(grDT.Cols.Count - 1).Width = 150
            'grDT.Cols(grDT.Cols.Count - 1).Visible = True
            'grDT.Cols(grDT.Cols.Count - 1).AllowEditing = False
            ''COLUMN FOR COST FORMULA ID
            'grDT.Cols.Add()
            'grDT.Cols(grDT.Cols.Count - 1).TextAlignFixed = TextAlignEnum.GeneralCenter
            'grDT.Cols(grDT.Cols.Count - 1).DataType = GetType(Integer)
            'grDT.Cols(grDT.Cols.Count - 1).Caption = "Cost Formula"
            'grDT.Cols(grDT.Cols.Count - 1).Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Populate Decision Table", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'POPULATING PARAMETER COLLECTIONS
        Try
            colTable = objTable.GetDecisionTableDetail(grTableDT.Item(grTableDT.RowSel, 0), "")
            For Each objTable In colTable
                grDT.Rows.Add()
                grDT.Item(grDT.Rows.Count - 1, 0) = objTable.ParmCollection
                'TO FILL MISSING PIPE SYMBOLS BASED ON NO.OF PARAMETERS
                parmCol = objTable.ParmCollection
                noOfPipe = parmCol.Split("|")
                If parmCount > noOfPipe.Length - 1 Then
                    For k = noOfPipe.Length - 1 To parmCount - 1
                        parmCol = parmCol & "|"
                    Next k
                    grDT.Item(grDT.Rows.Count - 1, 0) = parmCol
                End If
                'grDT.Item(grDT.Rows.Count - 1, grDT.Cols.Count - 2) = objTable.Cost_FormulaDesc
                'grDT.Item(grDT.Rows.Count - 1, grDT.Cols.Count - 1) = IIf(objTable.Cost_Formula = "", 0, objTable.Cost_Formula)
                vRef = objTable.ReferenceCode
                vQty = objTable.Quantity
                vCost = objTable.Cost
                vFactor = objTable.Factor
                vFixHr = objTable.FixHr
                vVarHr = objTable.VarHr
                For j = 1 To grDT.Cols.Count - 1
                    If grDT.Cols(j).Caption.ToUpper.Trim = "REF" Then
                        grDT.Item(grDT.Rows.Count - 1, j) = vRef
                    ElseIf grDT.Cols(j).Caption.ToUpper.Trim = "QTY" Then
                        grDT.Item(grDT.Rows.Count - 1, j) = vQty
                        grDT.Item(grDT.Rows.Count - 1, QtyColumn + 1) = objTable.Qty_FormulaDesc 'Qty_Formula
                        grDT.Item(grDT.Rows.Count - 1, QtyColumn + 2) = objTable.Qty_FormulaID
                    ElseIf grDT.Cols(j).Caption.ToUpper.Trim = "COST" Then
                        grDT.Item(grDT.Rows.Count - 1, j) = vCost
                        grDT.Item(grDT.Rows.Count - 1, CostColumn + 1) = objTable.Cost_FormulaDesc
                        grDT.Item(grDT.Rows.Count - 1, CostColumn + 2) = objTable.Cost_FormulaID
                    ElseIf grDT.Cols(j).Caption.ToUpper.Trim = "FACTOR" Then
                        grDT.Item(grDT.Rows.Count - 1, j) = vFactor
                    ElseIf grDT.Cols(j).Caption.ToUpper.Trim = "FIXHR" Then
                        grDT.Item(grDT.Rows.Count - 1, j) = vFixHr
                    ElseIf grDT.Cols(j).Caption.ToUpper.Trim = "VARHR" Then
                        grDT.Item(grDT.Rows.Count - 1, j) = vVarHr
                    End If
                Next
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Populate Parameter Collections", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'POPULATING PARAMETER VALUES
        Dim objValue As PCESValue
        Dim colValue As PCESValueCollection
        Dim vc As String
        Dim ValueCodeArray() As String
        Dim kk As Integer
        Try
            For i = 1 To grDT.Rows.Count - 1
                parmCol = grDT.Item(i, 0).Trim
                j = 1
                Do While InStr(parmCol, "|", CompareMethod.Text) > 0
                    s = Trim(Mid(parmCol, 1, InStr(parmCol, "|", CompareMethod.Text) - 1))
                    parmCol = Trim(Mid(parmCol, InStr(parmCol, "|", CompareMethod.Text) + 1))
                    If Parm(j - 1, 3) = "1" Then
                        'If IsNumeric(s) = True Then
                        If Parm(j - 1, 4) = "CHARACTER" Then
                            ValueCodeArray = s.Split(Convert.ToChar(","))
                            For kk = 0 To ValueCodeArray.Length - 1
                                'colValue = objValue.GetValue(Parm(j - 1, 1), IIf(s = "", 0, s))
                                colValue = objValue.GetValue(Parm(j - 1, 1), IIf(ValueCodeArray(kk) = "", 0, ValueCodeArray(kk)))
                                For Each objValue In colValue
                                    If grDT.Item(i, j) <> "" Then grDT.Item(i, j) = grDT.Item(i, j) & ","
                                    grDT.Item(i, j) = grDT.Item(i, j) & objValue.ValueDescription
                                Next
                                colValue = Nothing
                            Next kk
                        Else
                            grDT.Item(i, j) = s
                        End If
                    Else
                        grDT.Item(i, j) = s
                    End If
                    j = j + 1
                Loop
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Populate Parameter Values", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub PopulateSubCode()
        Dim objSG As New PCESSubCode
        Dim ds As New DataSet
        If cbSubCode.Items.Count > 0 Then
            dsSubCode.Tables(0).Rows.Clear()
        Else
            cbSubCode.Items.Clear()
        End If
        Try
            dsSubCode = New DataSet
            dsSubCode = objSG.GetSubCodeList(cbServiceGroup.SelectedValue)
            cbSubCode.DataSource = dsSubCode.Tables(0)
            cbSubCode.DisplayMember = "SubCode"
            cbSubCode.ValueMember = "Id"
            Dim dr As DataRow
            dr = dsSubCode.Tables(0).NewRow()
            dr("Id") = "0"
            dr("SubCode") = ""
            dr("Description") = ""
            dsSubCode.Tables(0).Rows.InsertAt(dr, 0)
            cbSubCode.Update()
            cbSubCode.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fill Sub Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function FillParameter(ByVal DataSource As Integer) As String
        Dim pn As String
        Dim objChar As PCESChar
        Dim colChar As PCESCharCollection
        Dim i As Integer
        pn = ""
        Try
            If DataSource = 1 Then
                cbForParmCode.Items.Clear()
                For i = 1 To 3
                    colChar = objChar.GetCharacteristics(cbEquipment.Items(cbEquipment.SelectedIndex).EquipmentCode, i)
                    For Each objChar In colChar
                        pn = pn & "|" & objChar.ParmDescription
                        cbForParmCode.Items.Add(objChar)
                    Next
                    cbForParmCode.DisplayMember = "ParmDescription"
                Next
            ElseIf DataSource = 2 Then
                colChar = objChar.GetCharacteristics(cbEquipment.Items(cbEquipment.SelectedIndex).EquipmentCode, 4)
                For Each objChar In colChar
                    pn = pn & "|" & objChar.ParmDescription
                    cbForParmCode.Items.Add(objChar)
                Next
                cbForParmCode.DisplayMember = "ParmDescription"
            Else
                pn = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Expression Evaluator", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return pn
    End Function
    Private Function FillTable() As String
        Dim tn As String
        Dim objTable As PCESTable
        Dim colTable As PCESTableCollection
        colTable = objTable.GetTable(grProduct.Item(grProduct.RowSel, 0), "4")
        For Each objTable In colTable
            If objTable.TableID <> cbTableName.Items(cbTableName.SelectedIndex).TableID Then
                tn = tn & "|" & objTable.TableName
                cbForTableID.Items.Add(objTable)
            End If
        Next
        cbForTableID.DisplayMember = "TableName"
        Return tn
    End Function
    Private Sub ClearProductDetailsWindow()
        Dim i As Integer
        'cbProdHier.SelectedIndex = -1
        'lblProdHier.Text = ""
        cbUOM.SelectedIndex = 0
        txtProductName.Text = ""
        If (cbSubCode.Items.Count > 0) Then
            cbSubCode.SelectedIndex = 0
        End If
        chkDefault.Checked = False
        txtProdCost.Enabled = False
        txtProdCost.Text = ""
        'txtFJCNNumber.Text = ""
        'txtVersion.Text = ""
        grTable1_Settings()
        EE.grFormParm_Settings()
        EE.txtFormula.Text = ""
        EE.txtResult.Text = ""
        For i = 0 To lstModel.Items.Count - 1
            lstModel.SetItemChecked(i, False)
        Next i
        For i = 0 To lstCountry.Items.Count - 1
            lstCountry.SetItemChecked(i, False)
        Next i
    End Sub
    Private Sub ClearAssignParametersWindow()
        cbTableName.Items.Clear()
        grParm_Settings()
        'grLink_Settings()
    End Sub
    Private Sub ClearDecisionTableWindow()
        grTableDT_Settings()
        grDT_Settings()
        EEDD.grFormParm_Settings()
        EE.txtFormula.Text = ""
        EE.txtResult.Text = ""
        EEDD.txtFormula.Text = ""
        EEDD.txtResult.Text = ""
        grpFormula.Visible = False
    End Sub
    Private Sub grProduct_Settings()
        Dim i As Integer
        With grProduct
            .Rows.Count = 1
            .Cols.Count = 13
            .Rows.Fixed = 1
            For i = 0 To .Cols.Count - 1
                .Cols(i).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
            Next i
            .AllowAddNew = False
            .AllowDelete = False
            .AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
            .AllowDrop = False
            .AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
            .AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
            .AllowEditing = False
            .HighLight = HighLightEnum.Always
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            '----
            .Cols(0).Caption = "ProductID"
            .Cols(0).Width = 50
            .Cols(0).DataType = GetType(Integer)
            .Cols(0).Visible = False
            '----
            .Cols(1).Caption = "FormulaID"
            .Cols(1).Width = 50
            .Cols(1).DataType = GetType(Integer)
            .Cols(1).Visible = False
            '----
            .Cols(2).Caption = "EquipmentCode"
            .Cols(2).Width = 50
            .Cols(2).DataType = GetType(Integer)
            .Cols(2).Visible = False
            '----
            .Cols(3).Caption = "ProductType"
            .Cols(3).Width = 50
            .Cols(3).DataType = GetType(String)
            .Cols(3).Visible = False
            '----
            .Cols(4).Caption = "ServiceType"
            .Cols(4).Width = 50
            .Cols(4).DataType = GetType(String)
            .Cols(4).Visible = False
            '----
            .Cols(5).Caption = "Product Name"
            .Cols(5).Width = 280
            .Cols(5).DataType = GetType(String)
            .Cols(5).Visible = True
            '----
            .Cols(6).Caption = "Sub Code"
            .Cols(6).Width = 100
            .Cols(6).DataType = GetType(String)
            .Cols(6).Visible = True
            '----
            .Cols(7).Caption = "Formula Description"
            .Cols(7).Width = 280
            .Cols(7).DataType = GetType(String)
            .Cols(7).Visible = True
            '----
            .Cols(8).Caption = "UOM"
            .Cols(8).Width = 80
            .Cols(8).DataType = GetType(String)
            .Cols(8).Visible = True
            '----
            .Cols(9).Caption = "Active"
            .Cols(9).Width = 50
            .Cols(9).DataType = GetType(Boolean)
            .Cols(9).Visible = True
            '----
            .Cols(10).Caption = "Default"
            .Cols(10).Width = 50
            .Cols(10).DataType = GetType(Boolean)
            .Cols(10).Visible = True
            '----
            .Cols(11).Caption = "Selection"
            .Cols(11).Width = 50
            .Cols(11).DataType = GetType(Boolean)
            .Cols(11).Visible = True
            '----
            .Cols(12).Caption = "Cost"
            .Cols(12).Width = 100
            .Cols(12).DataType = GetType(Double)
            .Cols(12).Visible = True
        End With
    End Sub
    Private Sub grTable1_Settings()
        Dim objTable As New PCESTable
        Dim i As Integer
        Try
            dsTable = objTable.GetTableAsDataset(0, 3)
            dsTableTemp = objTable.GetTableAsDataset(0, 3)
            grTable1.DataSource = dsTable.Tables(0)
            ''navTable1.DataSource = dsTable.Tables(0)
            dsTable.Tables(0).Columns(0).Caption = "Table Name"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Populate Table Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        With grTable1
            '.Rows.Count = 1
            '.Cols.Count = 1
            For i = 0 To .Cols.Count - 1
                .Cols(i).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                .Cols(i).Visible = False
            Next i
            .Rows.Fixed = 1
            .AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
            .AllowDrop = True
            .AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None
            .AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
            .AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None
            .AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
            '-----
            .Cols(3).Caption = "Table No"
            .Cols(3).Width = 50
            .Cols(3).DataType = GetType(String)
            .Cols(3).AllowEditing = False
            .Cols(3).Visible = True
            '-----
            .Cols(4).Caption = "Table Name"
            .Cols(4).Width = 250
            .Cols(4).DataType = GetType(String)
            .Cols(4).Visible = True
            '-----
            .Cols(5).Caption = "Key"
            .Cols(5).Width = 50
            .Cols(5).DataType = GetType(String)
            '.Cols(5).AllowEditing = False
            .Cols(5).Visible = True
            .Cols(5).ComboList = "..."
        End With
    End Sub
    Private Sub grKeys_Settings()
        Dim i As Integer
        With grKeys
            '.Rows.Count = 1
            '.Cols.Count = 8
            '.Rows.Fixed = 1
            .Height = 72
            .Width = 448
            For i = 0 To .Cols.Count - 1
                .Cols(i).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                .Cols(i).DataType = GetType(Boolean)
            Next i
            .AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
            .AllowDrop = False
            .AllowEditing = False
            .AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None
            .AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
            .AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None
            .AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
            '----
            .Cols(0).Caption = "Key"
            .Cols(0).Width = 30
            .Cols(0).DataType = GetType(String)
            '----
            .Cols(1).Caption = "Ref Flag"
            .Cols(1).Width = 50
            '----
            .Cols(2).Caption = "Qty Flag"
            .Cols(2).Width = 50
            '----
            .Cols(3).Caption = "Cost Flag"
            .Cols(3).Width = 50
            '----
            .Cols(4).Caption = "Factor Flag"
            .Cols(4).Width = 60
            '----
            .Cols(5).Caption = "FixHR Flag"
            .Cols(5).Width = 60
            '----
            .Cols(6).Caption = "VarHR Flag"
            .Cols(6).Width = 60
            '----
            .Cols(7).Caption = "Sum Flag"
            .Cols(7).Width = 50
        End With
    End Sub
    Private Sub grParm_Settings()
        Dim i As Integer
        With grParm
            .Rows.Count = 1
            .Cols.Count = 7
            .Rows.Fixed = 1
            For i = 0 To .Cols.Count - 1
                .Cols(i).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                .Cols(i).DataType = GetType(Boolean)
            Next i
            .AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
            .AllowDrop = False
            .AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None
            .AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
            .AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None
            .AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
            '----
            .Cols(0).Caption = "DataSource"
            .Cols(0).Width = 50
            .Cols(0).DataType = GetType(String)
            .Cols(0).Visible = False
            '----
            .Cols(1).Caption = "Data Source"
            .Cols(1).Width = 150
            .Cols(1).DataType = GetType(String)
            .Cols(1).ComboList = "PARAMETER|DECISION TABLE"
            '----
            .Cols(2).Caption = "TableID"
            .Cols(2).Width = 50
            .Cols(2).DataType = GetType(Integer)
            .Cols(2).Visible = False
            '----
            .Cols(3).Caption = "Table No"
            .Cols(3).Width = 80
            .Cols(3).DataType = GetType(String)
            .Cols(3).AllowEditing = False
            '----
            .Cols(4).Caption = "Table Name"
            .Cols(4).Width = 200
            .Cols(4).DataType = GetType(String)
            '----
            .Cols(5).Caption = "ParmCode"
            .Cols(5).Width = 80
            .Cols(5).DataType = GetType(Integer)
            .Cols(5).Visible = False
            '----
            .Cols(6).Caption = "Parameter"
            .Cols(6).Width = 300
            .Cols(6).DataType = GetType(String)
            .ComboList = FillParameter(0)
        End With
    End Sub
    Private Sub grTableDT_Settings()
        With grTableDT
            .Rows.Count = 1
            .Cols.Count = 4
            .Rows.Fixed = 1
            .AllowAddNew = False
            .AllowDelete = False
            .AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
            .AllowDrop = False
            .AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
            .AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
            .AllowEditing = False
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None
            '----
            .Cols(0).Caption = "Table ID"
            .Cols(0).Width = 50
            .Cols(0).DataType = GetType(Integer)
            .Cols(0).Visible = False
            .Cols(0).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
            '----
            .Cols(1).Caption = "Table No"
            .Cols(1).Width = 50
            .Cols(1).DataType = GetType(String)
            .Cols(1).Visible = True
            .Cols(1).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
            '----
            .Cols(2).Caption = "Table Name"
            .Cols(2).Width = 200
            .Cols(2).DataType = GetType(String)
            .Cols(2).Visible = True
            .Cols(2).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
            '----
            .Cols(3).Caption = "Field Selection Key"
            .Cols(3).Width = 50
            .Cols(3).DataType = GetType(String)
            .Cols(3).Visible = False
            .Cols(3).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
        End With
    End Sub
    Private Sub grDT_Settings()
        With grDT
            .Rows.Count = 1
            .Cols.Count = 0
            .Rows.Fixed = 1
            .AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
            .AllowDrop = False
            .AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns
            .AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None
        End With
    End Sub
    Private Sub chkDefault_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDefault.CheckedChanged
        If chkDefault.Checked = True Then
            If grTable1.Rows.Count > 2 Then
                MessageBox.Show("For a default product, the no. of tables can not be more than one. Please remove excess tables", "Default", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                chkDefault.Checked = False
                Exit Sub
            ElseIf grTable1.Rows.Count = 2 Then
                ''navTable1.EnabledButtons = C1.Win.C1Input.NavigatorButtonFlags.Delete
            End If
            txtProdCost.Enabled = True
            txtProdCost.Focus()
        Else
            ''navTable1.EnabledButtons = C1.Win.C1Input.NavigatorButtonFlags.All
            txtProdCost.Text = ""
            txtProdCost.Enabled = False
        End If
    End Sub
    Private Sub frmServiceDecisionTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EE.DecisionTableType = "SERVICECOST"
        grKeys.Visible = False
        grProduct.RowSel = -1
        Mode = "ADD"
        'EE.navFormParm.Text = "Formula Parameter"
        FillEquipment()
        FillProductType()
        FillServiceGroup()
        PopulateSubCode()
        FillKeys()
        FillCountry()
        ClearProductDetailsWindow()
        grProduct_Settings()
        grKeys_Settings()
        If cbEquipment.Items.Count > 0 Then cbEquipment.SelectedIndex = 0
        Mode = "ADD"
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub cbEquipment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEquipment.SelectedIndexChanged
        Mode = "ADD"
        FillModel()
        FillProduct()
        'FillParameter()
        EE.EquipmentCode = cbEquipment.Items(cbEquipment.SelectedIndex).EquipmentCode
        EEDD.EquipmentCode = cbEquipment.Items(cbEquipment.SelectedIndex).EquipmentCode
    End Sub
    Private Sub grProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grProduct.Click
        grKeys.Visible = False
        'grComboList.Visible = False
        If grProduct.Rows.Count <= 1 Then Exit Sub
        If grProduct.RowSel < 1 Then Exit Sub
        EE.DecisionTableType = "SERVICECOST"
        EE.EquipmentCode = cbEquipment.Items(cbEquipment.SelectedIndex).EquipmentCode
        EE.ProductType = cbProductType.SelectedIndex + 1
        EE.ServiceType = cbServiceGroup.SelectedValue
        EE.DecisionTableTypeID = grProduct.Item(grProduct.RowSel, 0)
        EEDD.DecisionTableType = "SERVICECOST"
        EEDD.EquipmentCode = cbEquipment.Items(cbEquipment.SelectedIndex).EquipmentCode
        EEDD.ProductType = cbProductType.SelectedIndex + 1
        EEDD.ServiceType = cbServiceGroup.SelectedValue
        EEDD.DecisionTableTypeID = grProduct.Item(grProduct.RowSel, 0)
        Select Case TabControl1.SelectedIndex
            Case 0 'PRODUCT DETAILS
                ClearProductDetailsWindow()
                Mode = "EDIT"
                PopulateProduct()
                txtProductName.Focus()
            Case 1 'ASSIGN PARAMETERS
                ClearAssignParametersWindow()
                PopulateProduct()
            Case 2 'DECISION TABLE
                ClearDecisionTableWindow()
                PopulateProduct()
        End Select
    End Sub
    Private Sub cbProductType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbProductType.SelectedIndexChanged
        FillProduct()
        EE.ProductType = cbProductType.SelectedIndex + 1
        EEDD.ProductType = cbProductType.SelectedIndex + 1
        'If cbProductType.SelectedIndex = 1 Then
        '    grLink.Visible = True
        '    navLink.Visible = True
        'Else
        '    grLink.Visible = False
        '    navLink.Visible = False
        'End If
    End Sub
    Private Sub cbServiceGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbServiceGroup.SelectedIndexChanged
        'PopulateSubCode()
    End Sub
    Private Sub grTable1_CellButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles grTable1.CellButtonClick
        If grKeys.Visible = True Then
            grKeys.Visible = False
        Else
            If grTable1.Rows.Count <= 1 Then Exit Sub
            grKeys.Top = grTable1.Rows(grTable1.RowSel).Top() + 20 + grTable1.Top + grTable1.ScrollPosition.Y
            grKeys.Visible = True
        End If
    End Sub
    Private Sub grKeys_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grKeys.Click
        grKeys.Visible = False
        grTable1.Item(grTable1.RowSel, 5) = grKeys.Item(grKeys.RowSel, 0)
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        grKeys.Visible = False
        'grComboList.Visible = False
        If grProduct.Rows.Count = 50 Then Exit Sub
        If grProduct.Rows.Count <= 1 Then Exit Sub
        If grProduct.RowSel < 1 Then Exit Sub
        EE.DecisionTableType = "SERVICECOST"
        EE.EquipmentCode = cbEquipment.Items(cbEquipment.SelectedIndex).EquipmentCode
        EE.ProductType = cbProductType.SelectedIndex + 1
        EE.ServiceType = cbServiceGroup.SelectedValue
        EE.DecisionTableTypeID = grProduct.Item(grProduct.RowSel, 0)
        EEDD.DecisionTableType = "SERVICECOST"
        EEDD.EquipmentCode = cbEquipment.Items(cbEquipment.SelectedIndex).EquipmentCode
        EEDD.ProductType = cbProductType.SelectedIndex + 1
        EEDD.ServiceType = cbServiceGroup.SelectedValue
        EEDD.DecisionTableTypeID = grProduct.Item(grProduct.RowSel, 0)
        Select Case TabControl1.SelectedIndex
            Case 0 'PRODUCT DETAILS
                ClearProductDetailsWindow()
                Mode = "EDIT"
                PopulateProduct()
                txtProductName.Focus()
            Case 1 'ASSIGN PARAMETERS
                ClearAssignParametersWindow()
                PopulateProduct()
            Case 2 'DECISION TABLE
                ClearDecisionTableWindow()
                PopulateProduct()
        End Select
    End Sub
    Private Sub TabProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabProduct.Click
        grKeys.Visible = False
    End Sub
    ''Private Sub navTable1_ButtonClick(ByVal sender As System.Object, ByVal e As C1.Win.C1Input.NavigatorButtonClickEventArgs)
    ''    If e.Button = C1.Win.C1Input.NavigatorButtonEnum.Add Then
    ''        If grTable1.Rows.Count > 2 Then
    ''            grTable1.Item(grTable1.Rows.Count - 1, 3) = "T" & Trim(Mid(grTable1.Item(grTable1.Rows.Count - 2, 3), 2) + 1)
    ''        Else
    ''            grTable1.Item(grTable1.Rows.Count - 1, 3) = "T1"
    ''        End If
    ''        If chkDefault.Checked = True Then
    ''            If grTable1.Rows.Count >= 2 Then
    ''                ''navTable1.EnabledButtons = C1.Win.C1Input.NavigatorButtonFlags.Delete
    ''            End If
    ''        End If
    ''    ElseIf e.Button = C1.Win.C1Input.NavigatorButtonEnum.Delete Then
    ''        If chkDefault.Checked = True Then
    ''            If grTable1.Rows.Count <= 1 Then
    ''                ''navTable1.EnabledButtons = C1.Win.C1Input.NavigatorButtonFlags.Add
    ''            End If
    ''        End If
    ''    End If

    ''End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        grKeys.Visible = False
        If grProduct.RowSel < 1 Then
            MessageBox.Show("Please select a Product", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtProductName.Text = "" Then
            MessageBox.Show("Please select a Product", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If Mode <> "EDIT" Then
            MessageBox.Show("Please select a Product", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If MessageBox.Show("Are you sure to delete this Product : " + grProduct.Item(grProduct.RowSel, 5) + " ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        'DELETING FORMULA TABLES
        Dim objTable As PCESTable
        Dim i As Integer
        Try
            With dsTableTemp.Tables(0)
                For i = 0 To .Rows.Count - 1
                    objTable.UpdateTable(.Rows(i).Item(0), 0, "4", "", "", "", objUser.UserName, "D")
                Next
            End With
        Catch ex As Exception
            If ex.Source = ".Net SqlClient Data Provider" Then
                MessageBox.Show("This Product may have Decision Tables. Please remove them before delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show(ex.Message, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Exit Sub
        End Try
        'DELETING FORMULA DATASOURCE
        Dim objFormula1 As PCESFormula
        Try
            objFormula1.UpdateFormulaDataSource(grProduct.Item(grProduct.RowSel, 1), 0, 0, "", 0, "", 0, objUser.UserName, "D")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
        'DELETING SERVICE DEFINITION
        Dim objProduct As PCESProduct
        Try
            objProduct.UpdateServiceDefinition(grProduct.Item(grProduct.RowSel, 0), 0, "", "", "", False, False, 0, 0, objUser.UserName, "D", "", False, "")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
        MessageBox.Show("Product deleted successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillProduct()
        grProduct.RowSel = -1
        Mode = "ADD"
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim i As Integer
        EE.DecisionTableType = "SERVICECOST"
        EE.EquipmentCode = 0
        EE.DecisionTableTypeID = 0
        grKeys.Visible = False
        cbUOM.SelectedIndex = 0
        txtProductName.Text = ""
        If (cbSubCode.Items.Count > 0) Then
            cbSubCode.SelectedIndex = 0
        End If
        chkActive.Checked = True
        chkDefault.Checked = False
        chkSelectionRequired.Checked = False
        txtProdCost.Text = ""
        grTable1_Settings()
        EE.grFormParm_Settings()
        EE.txtFormula.Text = ""
        EE.txtResult.Text = ""
        txtProductName.Focus()
        grProduct.RowSel = -1
        For i = 0 To lstModel.Items.Count - 1
            lstModel.SetItemChecked(i, False)
        Next i
        For i = 0 To lstCountry.Items.Count - 1
            lstCountry.SetItemChecked(i, False)
        Next i
        Mode = "ADD"
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        grKeys.Visible = False
        If cbEquipment.SelectedIndex = -1 Then
            MessageBox.Show("Please select a Equipment", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If cbProductType.SelectedIndex = -1 Then
            MessageBox.Show("Please select a Product Type", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtProductName.Text = "" Then
            MessageBox.Show("Please enter a Formula Name", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If cbUOM.SelectedIndex = 0 Then
            MessageBox.Show("Please select a UOM", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If cbSubCode.SelectedIndex = 0 Then
            MessageBox.Show("Please select a Sub Code", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim SubCode As String
        Dim UOM As String
        Dim drv As DataRowView
        drv = cbSubCode.Items(cbSubCode.SelectedIndex)
        SubCode = drv.Row("SubCode")

        UOM = cbUOM.Items(cbUOM.SelectedIndex)
        'UOM = drv.Row("SubCode")
        'If chkDefault.Checked = True Then
        '    If txtProdCost.Text = "" Then
        '        MessageBox.Show("Please enter Product cost", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Exit Sub
        '    End If
        '    If Val(txtProdCost.Text) = 0 Then
        '        MessageBox.Show("Please enter Product cost", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Exit Sub
        '    End If
        'End If
        If Mode = "EDIT" Then
            If grProduct.RowSel < 1 Then
                MessageBox.Show("Please select a Product", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If
        Dim objProduct As PCESProduct
        Dim objFormula As PCESFormula
        Dim objFormula1 As PCESFormula
        Dim objTable As PCESTable
        Dim objModel As New PCESModel
        Dim objCountry As New PCESCountry
        Dim i, newProductID, newFormulaID As Integer
        For i = 1 To grTable1.Rows.Count - 1
            If IsDBNull(grTable1.Item(i, 5)) Then
                MessageBox.Show("Please select a Field Selection Key for all Tables", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If grTable1.Item(i, 5) = "" Then
                MessageBox.Show("Please select a Field Selection Key for all Tables", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Next i
        If EE.txtFormula.Text.Trim = "" And EE.grFormParm.Rows.Count > 1 Then
            MessageBox.Show("Please form a formula based on the datasources", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            EE.txtFormula.Focus()
            Exit Sub
        End If
        If Mode = "ADD" Then
            If grProduct.FindRow(txtProductName.Text, 1, 6, False, True, False) <> -1 Then
                MessageBox.Show("This Product is already exists. Please enter a new Product Name.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            
            'SAVING SERVICE COST DEFINITION
            Try
                newProductID = objProduct.UpdateServiceDefinition(0, cbEquipment.Items(cbEquipment.SelectedIndex).EquipmentCode, CStr(cbProductType.SelectedIndex + 1), CStr(cbServiceGroup.SelectedValue), txtProductName.Text.Trim, chkActive.Checked, chkDefault.Checked, IIf(txtProdCost.Text.Trim = "", 0, txtProdCost.Text.Trim), newFormulaID, objUser.UserName, "A", SubCode, chkSelectionRequired.Checked, UOM)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Save Service Cost Definition", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try

            'SAVING FORMULA DEFINITION
            newFormulaID = 0
            Try
                newFormulaID = objFormula.UpdateFormulaDefinition(0, txtProductName.Text.Trim, True, "4", EE.txtFormula.Text.Trim, CDec(0), objUser.UserName, "A", newProductID)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Save Service Cost - Formula Definition", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try

            'SAVING SERVICE COST DEFINITION - FORMAULA ID
            Try
                newProductID = objProduct.UpdateServiceDefinitionFormulaId(newProductID, newFormulaID)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Save Service Cost Definition", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try

            'SAVING ASSIGINED MODELS
            Try
                For i = 0 To lstModel.Items.Count - 1
                    If lstModel.GetItemChecked(i) = True Then
                        objModel.UpdateProductAssignedModel(newProductID, cbEquipment.Items(cbEquipment.SelectedIndex).EquipmentCode, "4", lstModel.Items(i).ModelType, "A")
                    End If
                Next i
            Catch ex As Exception
                MessageBox.Show("Product saved. Error in saving Assigned Models : " & ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            'SAVING EXCLUDED COUNTRIES
            Try
                For i = 0 To lstCountry.Items.Count - 1
                    If lstCountry.GetItemChecked(i) = True Then
                        objCountry.UpdateProductExcludedCountry(newProductID, "4", lstCountry.Items(i).CountryCode, "A")
                    End If
                Next i
            Catch ex As Exception
                MessageBox.Show("Product & Assigned models saved. Error in saving Excluded Countries : " & ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            'SAVING SERVICE COST TABLES
            Try
                If dsTable.HasChanges = True Then
                    With dsTable.Tables(0)
                        For i = 0 To .Rows.Count - 1
                            If .Rows(i).RowState = DataRowState.Added Then
                                objTable.UpdateTable(0, newProductID, "4", .Rows(i).Item(3), .Rows(i).Item(4), IIf(IsDBNull(.Rows(i).Item(5)), "", .Rows(i).Item(5)), objUser.UserName, "A")
                            ElseIf .Rows(i).RowState = DataRowState.Deleted Then
                                objTable.UpdateTable(dsTableTemp.Tables(0).Rows(i).Item(0), 0, "4", "", "", "", objUser.UserName, "D")
                            ElseIf .Rows(i).RowState = DataRowState.Modified Then
                                objTable.UpdateTable(.Rows(i).Item(0), .Rows(i).Item(1), "4", .Rows(i).Item(3), .Rows(i).Item(4), IIf(IsDBNull(.Rows(i).Item(5)), "", .Rows(i).Item(5)), objUser.UserName, "C")
                            End If
                        Next
                    End With
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Save Service Cost Tables", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try
            'SAVING FORMULA DATASOURCES
            Try
                For i = 1 To EE.grFormParm.Rows.Count - 1
                    objFormula1.UpdateFormulaDataSource(newFormulaID, IIf(IsDBNull(EE.grFormParm.Item(i, 1)), 0, EE.grFormParm.Item(i, 1)), IIf(IsDBNull(EE.grFormParm.Item(i, 3)), 0, EE.grFormParm.Item(i, 3)), EE.grFormParm.Item(i, 4), EE.grFormParm.Item(i, 6), EE.grFormParm.Item(i, 8), IIf(IsDBNull(EE.grFormParm.Item(i, 9)), 0, EE.grFormParm.Item(i, 9)), objUser.UserName, "A")
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Save Service Cost Datasources", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try
        ElseIf Mode = "EDIT" Then

            'SAVING FORMULA DEFINITION
            newFormulaID = 0
            Try
                newFormulaID = objFormula.UpdateFormulaDefinition(grProduct.Item(grProduct.RowSel, 1), txtProductName.Text.Trim, True, "4", EE.txtFormula.Text.Trim, CDec(0), objUser.UserName, "C", newProductID)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Save Service Cost - Formula Definition", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try

            'SAVING SERVICE DEFINITION
            Try
                newProductID = objProduct.UpdateServiceDefinition(grProduct.Item(grProduct.RowSel, 0), cbEquipment.Items(cbEquipment.SelectedIndex).EquipmentCode, CStr(cbProductType.SelectedIndex + 1), CStr(cbServiceGroup.SelectedValue), txtProductName.Text.Trim, chkActive.Checked, chkDefault.Checked, IIf(txtProdCost.Text.Trim = "", 0, txtProdCost.Text.Trim), newFormulaID, objUser.UserName, "C", SubCode, chkSelectionRequired.Checked, UOM)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Save Service Cost Definition", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try

            

            'SAVING ASSIGINED MODELS
            Try
                objModel.UpdateProductAssignedModel(grProduct.Item(grProduct.RowSel, 0), 0, "4", "", "D")
                For i = 0 To lstModel.Items.Count - 1
                    If lstModel.GetItemChecked(i) = True Then
                        objModel.UpdateProductAssignedModel(grProduct.Item(grProduct.RowSel, 0), cbEquipment.Items(cbEquipment.SelectedIndex).EquipmentCode, "4", lstModel.Items(i).ModelType, "A")
                    End If
                Next i
            Catch ex As Exception
                MessageBox.Show("Product saved. Error in saving Assigned Models : " & ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            'SAVING EXCLUDED COUNTRIES
            Try
                objCountry.UpdateProductExcludedCountry(grProduct.Item(grProduct.RowSel, 0), "4", "", "D")
                For i = 0 To lstCountry.Items.Count - 1
                    If lstCountry.GetItemChecked(i) = True Then
                        objCountry.UpdateProductExcludedCountry(grProduct.Item(grProduct.RowSel, 0), "4", lstCountry.Items(i).CountryCode, "A")
                    End If
                Next i
            Catch ex As Exception
                MessageBox.Show("Product & Assigned models saved. Error in saving Excluded Countries : " & ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            'SAVING SERVICE COST TABLES
            Try
                If dsTable.HasChanges = True Then
                    With dsTable.Tables(0)
                        For i = 0 To .Rows.Count - 1
                            If .Rows(i).RowState = DataRowState.Added Then
                                objTable.UpdateTable(0, grProduct.Item(grProduct.RowSel, 0), "4", .Rows(i).Item(3), .Rows(i).Item(4), IIf(IsDBNull(.Rows(i).Item(5)), "", .Rows(i).Item(5)), objUser.UserName, "A")
                            ElseIf .Rows(i).RowState = DataRowState.Deleted Then
                                objTable.UpdateTable(dsTableTemp.Tables(0).Rows(i).Item(0), 0, "4", "", "", "", objUser.UserName, "D")
                            ElseIf .Rows(i).RowState = DataRowState.Modified Then
                                objTable.UpdateTable(.Rows(i).Item(0), .Rows(i).Item(1), "4", .Rows(i).Item(3), .Rows(i).Item(4), IIf(IsDBNull(.Rows(i).Item(5)), "", .Rows(i).Item(5)), objUser.UserName, "C")
                            End If
                        Next
                    End With
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Save Service Cost Tables", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try
            'SAVING FORMULA DATASOURCES
            Try
                objFormula1.UpdateFormulaDataSource(grProduct.Item(grProduct.RowSel, 1), 0, 0, "", 0, "", 0, objUser.UserName, "D")
                For i = 1 To EE.grFormParm.Rows.Count - 1
                    objFormula1.UpdateFormulaDataSource(grProduct.Item(grProduct.RowSel, 1), IIf(IsDBNull(EE.grFormParm.Item(i, 1)), 0, EE.grFormParm.Item(i, 1)), IIf(IsDBNull(EE.grFormParm.Item(i, 3)), 0, EE.grFormParm.Item(i, 3)), EE.grFormParm.Item(i, 4), EE.grFormParm.Item(i, 6), EE.grFormParm.Item(i, 8), IIf(IsDBNull(EE.grFormParm.Item(i, 9)), 0, EE.grFormParm.Item(i, 9)), objUser.UserName, "A")
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Save Service Cost Datasources", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try
        End If
        MessageBox.Show("Product saved successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillProduct()
        'grProduct.RowSel = -1
        grProduct_SearchRow(newProductID)
        'Mode = "ADD"
        Mode = "EDIT"
    End Sub

    Private Sub cbTableName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTableName.SelectedIndexChanged
        If grProduct.RowSel < 0 Then Exit Sub
        If cbTableName.SelectedIndex < 0 Then Exit Sub
        Dim objTable As New PCESTable
        Dim clsTable As New PCESTableCollection
        Dim dsTable1 As DataSet
        Dim dsTable2 As DataSet
        'TO GET VALUES FOR THE SELECTED PARAMETER & POPULATE IN GRID
        grParm_Settings()
        Try
            clsTable = objTable.GetDecisionTableItem(grProduct.Item(grProduct.RowSel, 0), "4", cbTableName.Items(cbTableName.SelectedIndex).TableID)
            For Each objTable In clsTable
                With grParm
                    If .FindRow(objTable.ParmDescription, 1, 6, False, True, False) = -1 Or .FindRow(objTable.RefTableName, 1, 4, False, True, False) = -1 Then
                        .Rows.Add()
                        .Item(.Rows.Count - 1, 0) = objTable.DataSource
                        If objTable.DataSource = 1 Then
                            .Item(.Rows.Count - 1, 1) = "PARAMETER"
                        ElseIf objTable.DataSource = 2 Then
                            .Item(.Rows.Count - 1, 1) = "DECISION TABLE"
                        End If
                        .Item(.Rows.Count - 1, 2) = objTable.RefTableID
                        .Item(.Rows.Count - 1, 3) = objTable.RefTableRef
                        .Item(.Rows.Count - 1, 4) = objTable.RefTableName
                        .Item(.Rows.Count - 1, 5) = objTable.ParmCode
                        .Item(.Rows.Count - 1, 6) = objTable.ParmDescription
                    End If
                End With
            Next
            'ApplySequence()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Populate Parameters & Values", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'POPULATING INTO GRLINK GRID
        'If cbProductType.SelectedIndex = 1 Then
        '    grLink_Settings()
        '    Try
        '        dsTable = objTable.GetDecisionTableProductLinkAsDataset(cbTableName.Items(cbTableName.SelectedIndex).TableID, 3)
        '        dsTable.Tables(0).Columns(1).Caption = "Product Name"
        '        grLink.DataSource = dsTable.Tables(0)
        '        navLink.DataSource = dsTable.Tables(0)
        '        With grLink
        '            .Cols(0).Caption = "Product ID"
        '            .Cols(0).DataType = GetType(String)
        '            .Cols(0).Width = 50
        '            .Cols(0).TextAlignFixed = TextAlignEnum.CenterCenter
        '            .Cols(0).Visible = False
        '            .Cols(1).Caption = "Product Name"
        '            .Cols(1).DataType = GetType(String)
        '            .Cols(1).Width = 230
        '            .Cols(1).TextAlignFixed = TextAlignEnum.CenterCenter
        '            .Cols(1).Visible = True
        '            .Cols(1).ComboList = Pn
        '        End With
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message, "Populate Main Products", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'End If
        'TO CHECK WHETHERE THE TABLE CONTAINS DECISION TABLE
        btnSaveAssign.Enabled = True
        Try
            dsTable1 = objTable.GetDecisionTableDetailAsDataset(cbTableName.Items(cbTableName.SelectedIndex).TableID, "")
            If dsTable1.Tables(0).Rows.Count > 0 Then
                btnSaveAssign.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Populate Main Products", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlus.Click
        If grParm.Rows.Count < 1 Then Exit Sub
        If grParm.Cols.Count < 1 Then Exit Sub
        grParm.Rows.Add()
        Dim i As Integer
    End Sub
    Private Sub btnMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinus.Click
        If grParm.Rows.Count <= 1 Then Exit Sub
        If grParm.RowSel = 0 Then Exit Sub
        If grParm.Cols.Count < 1 Then Exit Sub
        If MessageBox.Show("Are you sure delete the selected row?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        grParm.RemoveItem(grParm.RowSel)
    End Sub

    Private Sub grParm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grParm.Click
        If grParm.RowSel = -1 Then Exit Sub
        If grParm.ColSel = 6 Then
            grParm.Cols(6).ComboList = FillParameter(grParm.Item(grParm.RowSel, 0))
        ElseIf grParm.ColSel = 4 Then
            If grParm.Item(grParm.RowSel, 0) = 2 Then
                grParm.Cols(4).ComboList = FillTable()
            Else
                grParm.Cols(4).ComboList = ""
            End If
        End If
    End Sub
    Private Sub btnSaveAssign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAssign.Click
        If grProduct.RowSel < 0 Then
            MessageBox.Show("Please select a Product.", "Save - Assign Parameters", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If cbTableName.SelectedIndex < 0 Then
            MessageBox.Show("Please select a Table.", "Save - Assign Parameters", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim objTable As PCESTable
        Dim curParmCode As Integer
        Dim i As Integer
        Dim validateFlag As Boolean
        'REMOVING OLD PARAMETERS & VALUES
        Try
            objTable.UpdateDecisionTableItemHeader(cbTableName.Items(cbTableName.SelectedIndex).TableID, 0, 0, 0, 0, False, "D")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Save - Assign Parameters", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        If grParm.Rows.Count <= 1 Then
            MessageBox.Show("Please assign at least one Parameter.", "Save - Assign Parameters", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        'ASSIGNING PARAMETERS
        Try
            If grParm.Rows.Count > 1 Then
                curParmCode = 0
                For i = 1 To grParm.Rows.Count - 1
                    'If grParm.Item(i, 5) <> curParmCode Then
                    curParmCode = grParm.Item(i, 5)
                    objTable.UpdateDecisionTableItemHeader(cbTableName.Items(cbTableName.SelectedIndex).TableID, grParm.Item(i, 5), 0, grParm.Item(i, 2), grParm.Item(i, 0), False, "A")
                    'End If
                Next
            End If
        Catch ex As Exception
            If ex.Source = ".Net SqlClient Data Provider" Then
                MessageBox.Show("Duplicate parameters found. Please remove them before save.", "Save - Assign Parameters", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Old Parameters removed. Error in assigning Parameters : " & ex.Message, "Save - Assign Parameters", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Exit Sub
        End Try
        'LINK TO MAIN PRODUCTS
        'If cbProductType.SelectedIndex = 1 Then
        '    Try
        '        objTable.UpdateDecisionTableProductLink(cbTableName.Items(cbTableName.SelectedIndex).TableID, 0, "D")
        '        For i = 1 To grLink.Rows.Count - 1
        '            objTable.UpdateDecisionTableProductLink(cbTableName.Items(cbTableName.SelectedIndex).TableID, grLink.Item(i, 0), "A")
        '        Next
        '    Catch ex As Exception
        '        MessageBox.Show("Assigned Parameters saved. Error in saving Link to main Products : " & Ex.Message, "Save - Assign Parameters", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Exit Sub
        '    End Try
        'End If
        MessageBox.Show("Assigned Parameters saved successfully", "Save - Assign Parameters", MessageBoxButtons.OK, MessageBoxIcon.Information)
        cbTableName.SelectedIndex = -1
        grParm_Settings()
        'grLink_Settings()
        PopulateProduct()
    End Sub
    Private Sub grParm_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles grParm.AfterEdit
        If grParm.ColSel = 1 Then
            grParm.Item(grParm.RowSel, 2) = 0
            grParm.Item(grParm.RowSel, 3) = ""
            grParm.Item(grParm.RowSel, 4) = ""
            grParm.Cols(4).ComboList = ""
            grParm.Item(grParm.RowSel, 5) = 0
            grParm.Item(grParm.RowSel, 6) = ""
            If grParm.Item(grParm.RowSel, 1) = "PARAMETER" Then
                grParm.Item(grParm.RowSel, 0) = 1
            ElseIf grParm.Item(grParm.RowSel, 1) = "DECISION TABLE" Then
                grParm.Item(grParm.RowSel, 0) = 2
            End If
        ElseIf grParm.ColSel = 4 Then
            grParm.Item(grParm.RowSel, 5) = 0
            grParm.Item(grParm.RowSel, 6) = ""
            cbForTableID.Text = grParm.Item(grParm.RowSel, 4)
            If cbForTableID.SelectedIndex = -1 Then
                grParm.Item(grParm.RowSel, 2) = 0
                grParm.Item(grParm.RowSel, 3) = ""
                Exit Sub
            End If
            grParm.Item(grParm.RowSel, 2) = cbForTableID.Items(cbForTableID.SelectedIndex).TableID
            grParm.Item(grParm.RowSel, 3) = cbForTableID.Items(cbForTableID.SelectedIndex).TableRef
        ElseIf grParm.ColSel = 6 Then
            cbForParmCode.Text = grParm.Item(grParm.RowSel, 6)
            If cbForParmCode.SelectedIndex = -1 Then
                grParm.Item(grParm.RowSel, 5) = 0
                Exit Sub
            End If
            grParm.Item(grParm.RowSel, 5) = cbForParmCode.Items(cbForParmCode.SelectedIndex).ParmCode
        End If
    End Sub

    Private Sub grTableDT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grTableDT.Click
        PopulateDecisionTable()
    End Sub

    Private Sub btnDeleteDT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteDT.Click
        grComboList.Visible = False
        Dim objTable As PCESTable
        Dim i As Integer
        If grDT.Rows.Count <= 1 Then Exit Sub
        If MessageBox.Show("Are you sure to delete all rows for the selected table?", "Delete Decision Table", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        Try
            objTable.UpdateDecisionTableDetail(grTableDT.Item(grTableDT.RowSel, 0), "", 0, "", "", "", CDec(0), 0, "", 0, 0, "", CDec(0), CDec(0), CDec(0), CDec(0), objUser.UserName, "D")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Delete Decision Table", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        MessageBox.Show("Decision Table deleted.", "Delete Decision Table", MessageBoxButtons.OK, MessageBoxIcon.Information)
        PopulateDecisionTable()
    End Sub
    Private Sub btnSaveDT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveDT.Click
        grComboList.Visible = False
        Dim objTable As PCESTable
        Dim i, j As Integer
        Dim vRef, vQtyFormula As String
        Dim vQty, vCost, vFactor, vFixHr, vVarHr As Double
        Dim vQtyFormulaID, vCostFormulaID As Integer
        Dim objFormula As PCESFormula
        Dim objFormula1 As PCESFormula
        Dim newFormulaID As Integer
        If grDT.Rows.Count <= 1 Then Exit Sub
        'TO CHECK FOR BLANK ROWS
        Try
            For i = 1 To grDT.Rows.Count - 1
                Do While InStr(grDT.Item(i, 0), "||") > 0
                    MessageBox.Show("Parameter Values are incomplete. Save Process cencelled.", "Save Decision Table", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                    'grDT.Item(i, 0) = Replace(grDT.Item(i, 0), "||", "|")
                Loop
                If grDT.Item(i, 0) = "|" Then
                    MessageBox.Show("Parameter Values are incomplete. Save Process cencelled.", "Save Decision Table", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Next i
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Save Decision Table", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'DELETING EXISTING DECISION TABLES
        Try
            objTable.UpdateDecisionTableDetail(grTableDT.Item(grTableDT.RowSel, 0), "", 0, "", "", "", CDec(0), 0, "", 0, 0, "", CDec(0), CDec(0), CDec(0), CDec(0), objUser.UserName, "D")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Save Decision Table", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            For i = 1 To grDT.Rows.Count - 1
                'SAVING DECISION TABLE
                vRef = ""
                vQtyFormula = ""
                vQty = 0
                vCost = 0
                vFactor = 0
                vFixHr = 0
                vVarHr = 0
                vQtyFormulaID = 0
                vCostFormulaID = 0
                For j = 1 To grDT.Cols.Count - 1
                    If grDT.Cols(j).Caption.ToUpper.Trim = "QTY FORMULA" Then
                        vQtyFormula = IIf(grDT.Item(i, j) = Nothing, "", grDT.Item(i, j))
                    ElseIf grDT.Cols(j).Caption.ToUpper.Trim = "QTY FORMULAID" Then
                        vQtyFormulaID = IIf(grDT.Item(i, j) = Nothing, 0, grDT.Item(i, j))
                    ElseIf grDT.Cols(j).Caption.ToUpper.Trim = "COST FORMULAID" Then
                        vCostFormulaID = IIf(grDT.Item(i, j) = Nothing, 0, grDT.Item(i, j))
                    ElseIf grDT.Cols(j).Caption.ToUpper.Trim = "REF" Then
                        vRef = grDT.Item(i, j)
                    ElseIf grDT.Cols(j).Caption.ToUpper.Trim = "QTY" Then
                        vQty = grDT.Item(i, j)
                    ElseIf grDT.Cols(j).Caption.ToUpper.Trim = "COST" Then
                        vCost = grDT.Item(i, j)
                    ElseIf grDT.Cols(j).Caption.ToUpper.Trim = "FACTOR" Then
                        vFactor = grDT.Item(i, j)
                    ElseIf grDT.Cols(j).Caption.ToUpper.Trim = "FIXHR" Then
                        vFixHr = grDT.Item(i, j)
                    ElseIf grDT.Cols(j).Caption.ToUpper.Trim = "VARHR" Then
                        vVarHr = grDT.Item(i, j)
                    End If
                Next
                objTable.UpdateDecisionTableDetail(grTableDT.Item(grTableDT.RowSel, 0), grDT.Item(i, 0), 0, vRef, "", "", vQty, 10, vQtyFormula, vCostFormulaID, vQtyFormulaID, "", CDec(vCost), CDec(vFactor), CDec(vFixHr), CDec(vVarHr), objUser.UserName, "A")
            Next i
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Save Decision Table", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        MessageBox.Show("Decision Table saved successfully.", "Save Decision Table", MessageBoxButtons.OK, MessageBoxIcon.Information)
        PopulateDecisionTable()
    End Sub
    Private Sub btnCostFormula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCostFormula.Click
        If grDT.Rows.Count <= 1 Then Exit Sub
        Dim objTable As PCESTable
        Dim dsCheck As DataSet
        dsCheck = objTable.GetDecisionTableDetailAsDataset(grTableDT.Item(grTableDT.RowSel, 0), grDT.Item(grDT.RowSel, 0))
        If dsCheck.Tables(0).Rows.Count = 0 Then
            MessageBox.Show("Please save the Decision Table before update formula", "Formula", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        EEDD.txtFormula.Text = grDT.Item(grDT.RowSel, CostColumn + 1)
        EEDD.DecisionTableType = "SERVICECOST"
        EE.EquipmentCode = cbEquipment.Items(cbEquipment.SelectedIndex).EquipmentCode
        EE.ProductType = cbProductType.SelectedIndex + 1
        EE.ServiceType = cbServiceGroup.SelectedValue
        EEDD.DecisionTableTypeID = grDT.Item(grDT.RowSel, CostColumn + 2)
        EEDD.EquipmentCode = cbEquipment.Items(cbEquipment.SelectedIndex).EquipmentCode
        EEDD.ProductType = cbProductType.SelectedIndex + 1
        EEDD.ServiceType = cbServiceGroup.SelectedValue
        EEDD.FillGrid()
        EEDD.DecisionTableTypeID = grProduct.Item(grProduct.RowSel, 0)
        EEDD.txtResult.Text = ""
        grpFormula.Text = "Cost Formula"
        grpFormula.Visible = True
    End Sub
    Private Sub btnQtyFormula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQtyFormula.Click
        If grDT.Rows.Count <= 1 Then Exit Sub
        Dim objTable As PCESTable
        Dim dsCheck As DataSet
        dsCheck = objTable.GetDecisionTableDetailAsDataset(grTableDT.Item(grTableDT.RowSel, 0), grDT.Item(grDT.RowSel, 0))
        If dsCheck.Tables(0).Rows.Count = 0 Then
            MessageBox.Show("Please save the Decision Table before update formula", "Formula", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        EEDD.txtFormula.Text = grDT.Item(grDT.RowSel, QtyColumn + 1)
        EEDD.DecisionTableType = "SERVICECOST"
        EE.EquipmentCode = cbEquipment.Items(cbEquipment.SelectedIndex).EquipmentCode
        EE.ProductType = cbProductType.SelectedIndex + 1
        EE.ServiceType = cbServiceGroup.SelectedValue
        EEDD.DecisionTableTypeID = grDT.Item(grDT.RowSel, QtyColumn + 2)
        EEDD.EquipmentCode = cbEquipment.Items(cbEquipment.SelectedIndex).EquipmentCode
        EEDD.ProductType = cbProductType.SelectedIndex + 1
        EEDD.ServiceType = cbServiceGroup.SelectedValue
        EEDD.FillGrid()
        EEDD.DecisionTableTypeID = grProduct.Item(grProduct.RowSel, 0)
        EEDD.txtResult.Text = ""
        grpFormula.Text = "Qty Formula"
        grpFormula.Visible = True
    End Sub
    Private Sub btnDeleteFormula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteFormula.Click
        If EEDD.grFormParm.Rows.Count <= 1 Then Exit Sub
        If IsDBNull(grDT.Item(grDT.RowSel, grDT.Cols.Count - 2)) Then Exit Sub
        Dim objFormula As PCESFormula
        Dim objFormula1 As PCESFormula
        Dim newFormulaID, j As Integer
        'DELETING FORMULA DEFINITION
        Try
            objFormula.UpdateFormulaDefinition(grDT.Item(grDT.RowSel, grDT.Cols.Count - 1), "", False, "", "", CDec(0), objUser.UserName, "D", 0)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Delete Service Cost - Decision Table - Formula Definition", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
        grDT.Item(grDT.RowSel, grDT.Cols.Count - 1) = 0
        grDT.Item(grDT.RowSel, grDT.Cols.Count - 2) = ""
        'DELETING FORMULA DATASOURCES
        Try
            objFormula1.UpdateFormulaDataSource(grDT.Item(grDT.RowSel, grDT.Cols.Count - 1), 0, 0, "", 0, "", 0, objUser.UserName, "D")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Delete Service Cost - Decision Table - Datasources", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
        grpFormula.Visible = False
    End Sub
    Private Sub btnSaveFormula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveFormula.Click
        If EEDD.grFormParm.Rows.Count <= 1 Then Exit Sub
        If EEDD.txtFormula.Text = "" Then
            MessageBox.Show("Please specify a Formula", "Save Service Cost - Decision Table - Formula Definition", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim objFormula As PCESFormula
        Dim objFormula1 As PCESFormula
        Dim newFormulaID, j As Integer
        'SAVING FORMULA DEFINITION
        Try
            If IsDBNull(grDT.Item(grDT.RowSel, grDT.Cols.Count - 1)) Then
                newFormulaID = objFormula.UpdateFormulaDefinition(0, txtProductName.Text.Trim, True, "4", EEDD.txtFormula.Text.Trim, CDec(0), objUser.UserName, "A", selProductId)
                If grpFormula.Text = "Qty Formula" Then
                    grDT.Item(grDT.RowSel, QtyColumn + 2) = newFormulaID
                Else
                    grDT.Item(grDT.RowSel, CostColumn + 2) = newFormulaID
                End If
            ElseIf Val(grDT.Item(grDT.RowSel, grDT.Cols.Count - 1)) = 0 Then
                newFormulaID = objFormula.UpdateFormulaDefinition(0, txtProductName.Text.Trim, True, "4", EEDD.txtFormula.Text.Trim, CDec(0), objUser.UserName, "A", selProductId)
                If grpFormula.Text = "Qty Formula" Then
                    grDT.Item(grDT.RowSel, QtyColumn + 2) = newFormulaID
                Else
                    grDT.Item(grDT.RowSel, CostColumn + 2) = newFormulaID
                End If
            Else
                If grpFormula.Text = "Qty Formula" Then
                    newFormulaID = grDT.Item(grDT.RowSel, QtyColumn + 2)
                Else
                    newFormulaID = grDT.Item(grDT.RowSel, CostColumn + 2)
                End If
                newFormulaID = objFormula.UpdateFormulaDefinition(newFormulaID, txtProductName.Text.Trim, True, "4", EEDD.txtFormula.Text.Trim, CDec(0), objUser.UserName, "C", selProductId)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Save Service Cost - Decision Table - Formula Definition", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
        'grDT.Item(grDT.RowSel, grDT.Cols.Count - 2) = EEDD.txtFormula.Text
        If grpFormula.Text = "Qty Formula" Then
            grDT.Item(grDT.RowSel, QtyColumn + 1) = EEDD.txtFormula.Text
        Else
            grDT.Item(grDT.RowSel, CostColumn + 1) = EEDD.txtFormula.Text
        End If
        'SAVING FORMULA DATASOURCES
        Try
            objFormula1.UpdateFormulaDataSource(newFormulaID, 0, 0, "", 0, "", 0, objUser.UserName, "D")
            For j = 1 To EEDD.grFormParm.Rows.Count - 1
                objFormula1.UpdateFormulaDataSource(newFormulaID, EEDD.grFormParm.Item(j, 1), IIf(IsDBNull(EEDD.grFormParm.Item(j, 3)), 0, EEDD.grFormParm.Item(j, 3)), EEDD.grFormParm.Item(j, 4), EEDD.grFormParm.Item(j, 6), EEDD.grFormParm.Item(j, 8), IIf(IsDBNull(EEDD.grFormParm.Item(j, 9)), 0, EEDD.grFormParm.Item(j, 9)), objUser.UserName, "A")
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Save Service Cost - Decision Table - Datasources", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
        grpFormula.Visible = False
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        grpFormula.Visible = False
    End Sub
    Private Sub btnPlusDT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlusDT.Click
        grpFormula.Visible = False
        If grDT.Rows.Count < 1 Then Exit Sub
        If grDT.Cols.Count < 1 Then Exit Sub
        grDT.Rows.Add()
        Dim i As Integer
        Dim newParmCol As String
        'If grDT.Cols.Count - 3 > 1 Then
        If parmCount > 0 Then
            'For i = 1 To grDT.Cols.Count - 3
            For i = 1 To parmCount
                newParmCol = newParmCol & "|"
            Next
        Else
            If grDT.Rows.Count <= 2 Then
                newParmCol = 1
            Else
                newParmCol = grDT.Item(grDT.Rows.Count - 2, 0) + 1
            End If
        End If
        grDT.Item(grDT.Rows.Count - 1, 0) = newParmCol
    End Sub
    Private Sub btnMinusDT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinusDT.Click
        grpFormula.Visible = False
        If grDT.Rows.Count <= 1 Then Exit Sub
        If grDT.RowSel = 0 Then Exit Sub
        If grDT.Cols.Count < 1 Then Exit Sub
        If MessageBox.Show("Are you sure delete the selected row?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        grDT.RemoveItem(grDT.RowSel)
    End Sub
    Private Sub grDT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grDT.Click
        grpFormula.Visible = False
    End Sub
    Private Sub grDT_CellButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles grDT.CellButtonClick
        If grDT.Rows.Count <= 1 Then Exit Sub
        Dim strMaterialSize() As String
        Dim objValue As PCESValue
        Dim colValue As PCESValueCollection
        Dim objTable As PCESTable
        Dim colTable As PCESTableCollection
        Dim j As Integer
        If Parm(grDT.ColSel - 1, 3) = 1 Then 'IF DATASOURCE=1 THEN TAKE FROM CHAR_VALUES TABLE
            colValue = objValue.GetValues(Parm(grDT.ColSel - 1, 1), "")
            With grComboList
                .Rows.Count = 0
                .Rows.Add()
                .Rows.Fixed = 1
                .Item(0, 0) = "ValueCode"
                .Item(0, 1) = "Select"
                .Cols(0).Visible = False
                '.Cols(1).Visible = False
                .Cols(1).Visible = True
                For Each objValue In colValue
                    .Rows.Add()
                    .Item(.Rows.Count - 1, 0) = objValue.ValueCode
                    '.Item(.Rows.Count - 1, 0) = objValue.ValueDescription  '//VALUECODE IS CHANGED AS VALUE DESCRIPTION IN ORDER TO STORE MULTIPLE VALUES IN PARMCOLLECTION
                    .Item(.Rows.Count - 1, 2) = objValue.ValueDescription
                    'j = j + 1
                Next
            End With
        Else 'IF DATASOURCE=1 THEN TAKE FROM DECISIONTABLEDETAIL TABLE
            colTable = objTable.GetDecisionTableDetail(Parm(grDT.ColSel - 1, 1), "")
            With grComboList
                .Rows.Count = 0
                .Rows.Add()
                .Rows.Fixed = 1
                .Item(0, 0) = "ValueCode"
                .Item(0, 1) = "Select"
                .Cols(0).Visible = False
                .Cols(1).Visible = True
                For Each objTable In colTable
                    .Rows.Add()
                    Select Case Parm(grDT.ColSel - 1, 2)
                        Case "REFERENCE"
                            .Item(0, 2) = "REFERENCE"
                            .Item(.Rows.Count - 1, 0) = objTable.ReferenceCode
                            .Item(.Rows.Count - 1, 2) = objTable.ReferenceCode
                        Case "QUANTITY"
                            .Item(0, 2) = "QUANTITY"
                            .Item(.Rows.Count - 1, 0) = objTable.Quantity
                            .Item(.Rows.Count - 1, 2) = objTable.Quantity
                        Case "FACTOR"
                            .Item(0, 2) = "FACTOR"
                            .Item(.Rows.Count - 1, 0) = objTable.Factor
                            .Item(.Rows.Count - 1, 2) = objTable.Factor
                        Case "COST"
                            .Item(0, 2) = "COST"
                            .Item(.Rows.Count - 1, 0) = objTable.Cost
                            .Item(.Rows.Count - 1, 2) = objTable.Cost
                        Case "FIXHR"
                            .Item(0, 2) = "FIXHR"
                            .Item(.Rows.Count - 1, 0) = objTable.FixHr
                            .Item(.Rows.Count - 1, 2) = objTable.FixHr
                        Case "VARHR"
                            .Item(0, 2) = "VARHR"
                            .Item(.Rows.Count - 1, 0) = objTable.VarHr
                            .Item(.Rows.Count - 1, 2) = objTable.VarHr
                        Case Else
                            .Item(0, 2) = ""
                    End Select
                Next
            End With
        End If
        'TO SHOW/HIDE COMBOLIST GRID
        If grComboList.Visible = True Then
            grComboList.Visible = False
        Else
            If grDT.Rows.Count <= 1 Then Exit Sub
            grComboList.Top = grDT.Rows(grDT.RowSel).Top() + 20 + grDT.Top + grDT.ScrollPosition.Y
            grComboList.Left = grDT.Cols(grDT.ColSel).Left + grDT.Left + grDT.ScrollPosition.X
            grComboList.Visible = True
        End If
    End Sub
    Private Sub grComboList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grComboList.Click
        '''If grComboList.ColSel = 1 Then Exit Sub
        '''If grComboList.RowSel < 1 Then Exit Sub
        '''grComboList.Visible = False
        '''Dim parmCol, i, j, newParmCol, newParmColCode, newParmColValue, s
        '''For i = 1 To grComboList.Rows.Count - 1
        '''    If grComboList.Item(i, 1) = True Or grComboList.RowSel = i Then
        '''        newParmColCode = newParmColCode & Trim(CStr(grComboList.Item(i, 0))) & ","
        '''        newParmColValue = newParmColValue & Trim(CStr(grComboList.Item(i, 2))) & ","
        '''    End If
        '''Next i
        '''newParmColCode = Mid(newParmColCode, 1, Len(newParmColCode) - 1)
        '''newParmColValue = Mid(newParmColValue, 1, Len(newParmColValue) - 1)
        '''parmCol = grDT.Item(grDT.RowSel, 0)
        '''j = 1
        '''Do While InStr(parmCol, "|", CompareMethod.Text) > 0
        '''    s = Mid(parmCol, 1, InStr(parmCol, "|", CompareMethod.Text) - 1)
        '''    parmCol = Mid(parmCol, InStr(parmCol, "|", CompareMethod.Text) + 1)
        '''    If j = grDT.ColSel Then
        '''        newParmCol = newParmCol & newParmColCode & "|"
        '''    Else
        '''        newParmCol = newParmCol & s & "|"
        '''    End If
        '''    j = j + 1
        '''Loop
        '''grDT.Item(grDT.RowSel, 0) = newParmCol
        '''grDT.Item(grDT.RowSel, grDT.ColSel) = newParmColValue
        If grComboList.ColSel = 1 Then Exit Sub
        grComboList.Visible = False
        Dim parmCol, i, j, newParmCol, newParmColCode, newParmColValue, s
        If grComboList.Cols(1).Visible = False Then 'IF NOT MULTI-VALUE SELECTION
            For i = 1 To grComboList.Rows.Count - 1
                If grComboList.RowSel = i Then
                    newParmColCode = newParmColCode & Trim(CStr(grComboList.Item(i, 0))) & ","
                    newParmColValue = newParmColValue & Trim(CStr(grComboList.Item(i, 2))) & ","
                End If
            Next i
        Else
            For i = 1 To grComboList.Rows.Count - 1
                If grComboList.Item(i, 1) = True Then
                    newParmColCode = newParmColCode & Trim(CStr(grComboList.Item(i, 0))) & ","
                    newParmColValue = newParmColValue & Trim(CStr(grComboList.Item(i, 2))) & ","
                End If
            Next i
        End If
        If newParmColCode = "" Then Exit Sub
        newParmColCode = Mid(newParmColCode, 1, Len(newParmColCode) - 1)
        newParmColValue = Mid(newParmColValue, 1, Len(newParmColValue) - 1)
        parmCol = grDT.Item(grDT.RowSel, 0)
        j = 1
        Do While InStr(parmCol, "|", CompareMethod.Text) > 0
            s = Mid(parmCol, 1, InStr(parmCol, "|", CompareMethod.Text) - 1)
            parmCol = Mid(parmCol, InStr(parmCol, "|", CompareMethod.Text) + 1)
            If j = grDT.ColSel Then
                newParmCol = newParmCol & newParmColCode & "|"
            Else
                newParmCol = newParmCol & s & "|"
            End If
            j = j + 1
        Loop
        grDT.Item(grDT.RowSel, 0) = newParmCol
        grDT.Item(grDT.RowSel, grDT.ColSel) = newParmColValue
    End Sub
    Private Sub grDT_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles grDT.AfterEdit
        If grComboList.ColSel = 1 Then Exit Sub
        Dim parmCol, i, j, newParmCol, newParmColCode, newParmColValue, s
        newParmColCode = grDT.Item(grDT.RowSel, grDT.ColSel)
        newParmColValue = grDT.Item(grDT.RowSel, grDT.ColSel)
        parmCol = grDT.Item(grDT.RowSel, 0)
        j = 1
        If InStr(parmCol, "|", CompareMethod.Text) > 0 Then
            Do While InStr(parmCol, "|", CompareMethod.Text) > 0
                s = Mid(parmCol, 1, InStr(parmCol, "|", CompareMethod.Text) - 1)
                parmCol = Mid(parmCol, InStr(parmCol, "|", CompareMethod.Text) + 1)
                If j = grDT.ColSel Then
                    newParmCol = newParmCol & newParmColCode & "|"
                Else
                    newParmCol = newParmCol & s & "|"
                End If
                j = j + 1
            Loop
        Else
            newParmCol = parmCol
        End If
        grDT.Item(grDT.RowSel, 0) = newParmCol
        grDT.Item(grDT.RowSel, grDT.ColSel) = newParmColValue
    End Sub
    Private Sub grProduct_SearchRow(ByVal ProductId As Integer)
        Dim rr As Integer
        rr = grProduct.FindRow(CStr(ProductId), 1, 0, False, True, False)
        grProduct.Select(rr, 0, True)
        PopulateProduct()
    End Sub
    Private Sub btnNewRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewRow.Click
        If grTable1.Rows.Count < 1 Then Exit Sub
        If grTable1.Cols.Count < 1 Then Exit Sub
        grTable1.Rows.Add()

        If grTable1.Rows.Count > 2 Then
            grTable1.Item(grTable1.Rows.Count - 1, 3) = "T" & Trim(Mid(grTable1.Item(grTable1.Rows.Count - 2, 3), 2) + 1)
        Else
            grTable1.Item(grTable1.Rows.Count - 1, 3) = "T1"
        End If
        If chkDefault.Checked = True Then
            If grTable1.Rows.Count >= 2 Then
                btnNewRow.Enabled = False
                btnDeleteRow.Enabled = True
            Else
                btnNewRow.Enabled = True
                btnDeleteRow.Enabled = False
            End If
        End If

    End Sub
    Private Sub btnDeleteRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteRow.Click
        If grTable1.Rows.Count <= 1 Then Exit Sub
        If grTable1.RowSel <= 0 Then Exit Sub
        If grTable1.Cols.Count < 1 Then Exit Sub
        Dim objTable As PCESTable
        Dim dsTable As DataSet
        dsTable = objTable.GetDecisionTableDetailAsDataset(grTable1.Item(grTable1.RowSel, 0), "")
        If dsTable.Tables(0).Rows.Count > 0 Then
            MessageBox.Show("Please remove the decision table of this table. Delete process terminated.", "Add/Remove Parameters", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MessageBox.Show("Do you want to delete the row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            grTable1.RemoveItem(grTable1.RowSel)
        End If

        If chkDefault.Checked = True Then
            If grTable1.Rows.Count <= 1 Then
                btnNewRow.Enabled = True
            Else
                btnNewRow.Enabled = False
            End If
        End If
    End Sub


    Private Sub cbServiceGroup_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbServiceGroup.SelectionChangeCommitted
        FillProduct()
        EE.ServiceType = cbServiceGroup.SelectedValue
        EEDD.ServiceType = cbServiceGroup.SelectedValue
        PopulateSubCode()
    End Sub
End Class
