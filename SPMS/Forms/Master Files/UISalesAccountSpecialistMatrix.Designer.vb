<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UISalesAccountSpecialistMatrix
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RadButton3 = New Telerik.WinControls.UI.RadButton()
        Me.RadButton2 = New Telerik.WinControls.UI.RadButton()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.radPageView1 = New Telerik.WinControls.UI.RadPageView()
        Me.RadPageViewPage1 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.RadPageViewPage2 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.RadPageViewPage3 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.RadPageViewPage4 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.RadPageViewPage5 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Office2010SilverTheme1 = New Telerik.WinControls.Themes.Office2010BlueTheme()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.RadButton3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.radPageView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.radPageView1.SuspendLayout()
        Me.RadPageViewPage1.SuspendLayout()
        Me.RadPageViewPage2.SuspendLayout()
        Me.RadPageViewPage3.SuspendLayout()
        Me.RadPageViewPage4.SuspendLayout()
        Me.RadPageViewPage5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(952, 58)
        Me.Panel1.TabIndex = 26
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(20, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(300, 30)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Matrix Sales Account Specialist"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel2.Controls.Add(Me.RadButton3)
        Me.Panel2.Controls.Add(Me.RadButton2)
        Me.Panel2.Controls.Add(Me.RadButton1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 482)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(952, 50)
        Me.Panel2.TabIndex = 27
        '
        'RadButton3
        '
        Me.RadButton3.Location = New System.Drawing.Point(870, 4)
        Me.RadButton3.Name = "RadButton3"
        Me.RadButton3.Size = New System.Drawing.Size(73, 41)
        Me.RadButton3.TabIndex = 2
        Me.RadButton3.Text = "Close"
        Me.RadButton3.ThemeName = "Office2010Silver"
        '
        'RadButton2
        '
        Me.RadButton2.Location = New System.Drawing.Point(79, 4)
        Me.RadButton2.Name = "RadButton2"
        Me.RadButton2.Size = New System.Drawing.Size(73, 41)
        Me.RadButton2.TabIndex = 1
        Me.RadButton2.Text = "Next"
        Me.RadButton2.ThemeName = "Office2010Silver"
        '
        'RadButton1
        '
        Me.RadButton1.Location = New System.Drawing.Point(3, 4)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(73, 41)
        Me.RadButton1.TabIndex = 0
        Me.RadButton1.Text = "Back "
        Me.RadButton1.ThemeName = "Office2010Silver"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.radPageView1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 58)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(952, 424)
        Me.Panel3.TabIndex = 28
        '
        'radPageView1
        '
        Me.radPageView1.Controls.Add(Me.RadPageViewPage1)
        Me.radPageView1.Controls.Add(Me.RadPageViewPage2)
        Me.radPageView1.Controls.Add(Me.RadPageViewPage3)
        Me.radPageView1.Controls.Add(Me.RadPageViewPage4)
        Me.radPageView1.Controls.Add(Me.RadPageViewPage5)
        Me.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.radPageView1.Location = New System.Drawing.Point(0, 0)
        Me.radPageView1.Name = "radPageView1"
        Me.radPageView1.SelectedPage = Me.RadPageViewPage1
        Me.radPageView1.Size = New System.Drawing.Size(952, 424)
        Me.radPageView1.TabIndex = 2
        Me.radPageView1.Text = "Employee"
        Me.radPageView1.ThemeName = "Office2010Silver"
        '
        'RadPageViewPage1
        '
        Me.RadPageViewPage1.Controls.Add(Me.Panel4)
        Me.RadPageViewPage1.Location = New System.Drawing.Point(12, 40)
        Me.RadPageViewPage1.Name = "RadPageViewPage1"
        Me.RadPageViewPage1.Size = New System.Drawing.Size(928, 372)
        Me.RadPageViewPage1.Text = "Employee"
        '
        'Panel4
        '
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(670, 372)
        Me.Panel4.TabIndex = 0
        '
        'RadPageViewPage2
        '
        Me.RadPageViewPage2.Controls.Add(Me.Panel5)
        Me.RadPageViewPage2.Location = New System.Drawing.Point(12, 40)
        Me.RadPageViewPage2.Name = "RadPageViewPage2"
        Me.RadPageViewPage2.Size = New System.Drawing.Size(928, 372)
        Me.RadPageViewPage2.Text = "District Manager "
        '
        'Panel5
        '
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(928, 372)
        Me.Panel5.TabIndex = 1
        '
        'RadPageViewPage3
        '
        Me.RadPageViewPage3.Controls.Add(Me.Panel6)
        Me.RadPageViewPage3.Location = New System.Drawing.Point(12, 40)
        Me.RadPageViewPage3.Name = "RadPageViewPage3"
        Me.RadPageViewPage3.Size = New System.Drawing.Size(1195, 493)
        Me.RadPageViewPage3.Text = "Territory"
        '
        'Panel6
        '
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1195, 493)
        Me.Panel6.TabIndex = 1
        '
        'RadPageViewPage4
        '
        Me.RadPageViewPage4.Controls.Add(Me.Panel7)
        Me.RadPageViewPage4.Location = New System.Drawing.Point(12, 40)
        Me.RadPageViewPage4.Name = "RadPageViewPage4"
        Me.RadPageViewPage4.Size = New System.Drawing.Size(1195, 493)
        Me.RadPageViewPage4.Text = "Customer"
        '
        'Panel7
        '
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1195, 493)
        Me.Panel7.TabIndex = 2
        '
        'RadPageViewPage5
        '
        Me.RadPageViewPage5.Controls.Add(Me.Panel8)
        Me.RadPageViewPage5.Location = New System.Drawing.Point(12, 40)
        Me.RadPageViewPage5.Name = "RadPageViewPage5"
        Me.RadPageViewPage5.Size = New System.Drawing.Size(1195, 493)
        Me.RadPageViewPage5.Text = "Process"
        '
        'Panel8
        '
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1195, 493)
        Me.Panel8.TabIndex = 2
        '
        'UISalesAccountSpecialistMatrix
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(952, 532)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "UISalesAccountSpecialistMatrix"
        Me.Text = "UISalesAccountSpecialistMatrix"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.RadButton3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.radPageView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.radPageView1.ResumeLayout(False)
        Me.RadPageViewPage1.ResumeLayout(False)
        Me.RadPageViewPage2.ResumeLayout(False)
        Me.RadPageViewPage3.ResumeLayout(False)
        Me.RadPageViewPage4.ResumeLayout(False)
        Me.RadPageViewPage5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Private WithEvents radPageView1 As Telerik.WinControls.UI.RadPageView
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents Office2010SilverTheme1 As Telerik.WinControls.Themes.Office2010BlueTheme
    Friend WithEvents RadButton2 As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadButton3 As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadPageViewPage1 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents Panel4 As Panel
    Friend WithEvents RadPageViewPage2 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents Panel5 As Panel
    Friend WithEvents RadPageViewPage3 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents Panel6 As Panel
    Friend WithEvents RadPageViewPage4 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents Panel7 As Panel
    Friend WithEvents RadPageViewPage5 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents Panel8 As Panel
End Class
