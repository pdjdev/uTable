<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CellControl
    Inherits System.Windows.Forms.UserControl

    'UserControl은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TopTimeLabel = New System.Windows.Forms.Label()
        Me.BottomTimeLabel = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MemoLabel = New System.Windows.Forms.Label()
        Me.ProfLabel = New System.Windows.Forms.Label()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.TopNotchPanel = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TopPanel = New System.Windows.Forms.Panel()
        Me.ChkBox1 = New System.Windows.Forms.PictureBox()
        Me.AniTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.TopPanel.SuspendLayout()
        CType(Me.ChkBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TopTimeLabel
        '
        Me.TopTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TopTimeLabel.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TopTimeLabel.Location = New System.Drawing.Point(19, 0)
        Me.TopTimeLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.TopTimeLabel.Name = "TopTimeLabel"
        Me.TopTimeLabel.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.TopTimeLabel.Size = New System.Drawing.Size(125, 19)
        Me.TopTimeLabel.TabIndex = 0
        Me.TopTimeLabel.Text = "TopTimeLabel"
        Me.TopTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BottomTimeLabel
        '
        Me.BottomTimeLabel.AutoSize = True
        Me.BottomTimeLabel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomTimeLabel.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BottomTimeLabel.Location = New System.Drawing.Point(0, 243)
        Me.BottomTimeLabel.Name = "BottomTimeLabel"
        Me.BottomTimeLabel.Size = New System.Drawing.Size(118, 17)
        Me.BottomTimeLabel.TabIndex = 1
        Me.BottomTimeLabel.Text = "BottomTimeLabel"
        Me.BottomTimeLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.MemoLabel)
        Me.Panel1.Controls.Add(Me.ProfLabel)
        Me.Panel1.Controls.Add(Me.TitleLabel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 21)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(144, 222)
        Me.Panel1.TabIndex = 2
        '
        'MemoLabel
        '
        Me.MemoLabel.AutoSize = True
        Me.MemoLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.MemoLabel.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.MemoLabel.Location = New System.Drawing.Point(0, 37)
        Me.MemoLabel.MaximumSize = New System.Drawing.Size(144, 0)
        Me.MemoLabel.Name = "MemoLabel"
        Me.MemoLabel.Size = New System.Drawing.Size(42, 15)
        Me.MemoLabel.TabIndex = 2
        Me.MemoLabel.Text = "Memo"
        Me.MemoLabel.UseMnemonic = False
        '
        'ProfLabel
        '
        Me.ProfLabel.AutoSize = True
        Me.ProfLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.ProfLabel.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ProfLabel.Location = New System.Drawing.Point(0, 20)
        Me.ProfLabel.MaximumSize = New System.Drawing.Size(144, 0)
        Me.ProfLabel.Name = "ProfLabel"
        Me.ProfLabel.Size = New System.Drawing.Size(67, 17)
        Me.ProfLabel.TabIndex = 1
        Me.ProfLabel.Text = "ProfName"
        Me.ProfLabel.UseMnemonic = False
        '
        'TitleLabel
        '
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.TitleLabel.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TitleLabel.Location = New System.Drawing.Point(0, 0)
        Me.TitleLabel.MaximumSize = New System.Drawing.Size(144, 0)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(40, 20)
        Me.TitleLabel.TabIndex = 0
        Me.TitleLabel.Text = "Title"
        Me.TitleLabel.UseMnemonic = False
        '
        'TopNotchPanel
        '
        Me.TopNotchPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopNotchPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopNotchPanel.Name = "TopNotchPanel"
        Me.TopNotchPanel.Size = New System.Drawing.Size(144, 2)
        Me.TopNotchPanel.TabIndex = 3
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 150
        '
        'TopPanel
        '
        Me.TopPanel.Controls.Add(Me.TopTimeLabel)
        Me.TopPanel.Controls.Add(Me.ChkBox1)
        Me.TopPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopPanel.Location = New System.Drawing.Point(0, 2)
        Me.TopPanel.Name = "TopPanel"
        Me.TopPanel.Size = New System.Drawing.Size(144, 19)
        Me.TopPanel.TabIndex = 3
        '
        'ChkBox1
        '
        Me.ChkBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ChkBox1.Image = Global.uTable.My.Resources.Resources.check1_w_96
        Me.ChkBox1.Location = New System.Drawing.Point(0, 0)
        Me.ChkBox1.Name = "ChkBox1"
        Me.ChkBox1.Size = New System.Drawing.Size(19, 19)
        Me.ChkBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ChkBox1.TabIndex = 3
        Me.ChkBox1.TabStop = False
        '
        'AniTimer
        '
        Me.AniTimer.Interval = 10
        '
        'CellControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BottomTimeLabel)
        Me.Controls.Add(Me.TopPanel)
        Me.Controls.Add(Me.TopNotchPanel)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "CellControl"
        Me.Size = New System.Drawing.Size(144, 260)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TopPanel.ResumeLayout(False)
        CType(Me.ChkBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TopTimeLabel As Label
    Friend WithEvents BottomTimeLabel As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents MemoLabel As Label
    Friend WithEvents ProfLabel As Label
    Friend WithEvents TitleLabel As Label
    Friend WithEvents TopNotchPanel As Panel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TopPanel As Panel
    Friend WithEvents ChkBox1 As PictureBox
    Friend WithEvents AniTimer As Timer
End Class
