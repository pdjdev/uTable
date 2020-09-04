<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewCourse
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.BodyPanel = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.MemoTB = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.SaveBT = New System.Windows.Forms.Button()
        Me.CancelBT = New System.Windows.Forms.Button()
        Me.ShadowPanel = New System.Windows.Forms.Panel()
        Me.TitlePanel = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.SubTitleLabel = New System.Windows.Forms.Label()
        Me.UpperTitleLabel = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.EditBT = New System.Windows.Forms.PictureBox()
        Me.CloseBT = New System.Windows.Forms.PictureBox()
        Me.UpperPanel = New System.Windows.Forms.Panel()
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.BodyPanel.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TitlePanel.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.EditBT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CloseBT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UpperPanel.SuspendLayout()
        Me.MainPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BodyPanel
        '
        Me.BodyPanel.BackColor = System.Drawing.Color.White
        Me.BodyPanel.Controls.Add(Me.Panel4)
        Me.BodyPanel.Controls.Add(Me.ShadowPanel)
        Me.BodyPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BodyPanel.ForeColor = System.Drawing.Color.Black
        Me.BodyPanel.Location = New System.Drawing.Point(3, 0)
        Me.BodyPanel.Name = "BodyPanel"
        Me.BodyPanel.Size = New System.Drawing.Size(252, 165)
        Me.BodyPanel.TabIndex = 27
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.MemoTB)
        Me.Panel4.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 10)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Panel4.Size = New System.Drawing.Size(252, 155)
        Me.Panel4.TabIndex = 4
        '
        'MemoTB
        '
        Me.MemoTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MemoTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MemoTB.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.MemoTB.Location = New System.Drawing.Point(7, 0)
        Me.MemoTB.Multiline = True
        Me.MemoTB.Name = "MemoTB"
        Me.MemoTB.Size = New System.Drawing.Size(238, 122)
        Me.MemoTB.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.SaveBT, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.CancelBT, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(7, 122)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(238, 33)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'SaveBT
        '
        Me.SaveBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SaveBT.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.SaveBT.FlatAppearance.BorderSize = 0
        Me.SaveBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SaveBT.Font = New System.Drawing.Font("맑은 고딕", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.SaveBT.ForeColor = System.Drawing.Color.DodgerBlue
        Me.SaveBT.Location = New System.Drawing.Point(119, 0)
        Me.SaveBT.Margin = New System.Windows.Forms.Padding(0)
        Me.SaveBT.Name = "SaveBT"
        Me.SaveBT.Size = New System.Drawing.Size(119, 33)
        Me.SaveBT.TabIndex = 0
        Me.SaveBT.Text = "저장"
        Me.SaveBT.UseVisualStyleBackColor = True
        '
        'CancelBT
        '
        Me.CancelBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CancelBT.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.CancelBT.FlatAppearance.BorderSize = 0
        Me.CancelBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CancelBT.Font = New System.Drawing.Font("맑은 고딕", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.CancelBT.ForeColor = System.Drawing.Color.DodgerBlue
        Me.CancelBT.Location = New System.Drawing.Point(0, 0)
        Me.CancelBT.Margin = New System.Windows.Forms.Padding(0)
        Me.CancelBT.Name = "CancelBT"
        Me.CancelBT.Size = New System.Drawing.Size(119, 33)
        Me.CancelBT.TabIndex = 1
        Me.CancelBT.Text = "취소"
        Me.CancelBT.UseVisualStyleBackColor = True
        '
        'ShadowPanel
        '
        Me.ShadowPanel.BackgroundImage = Global.uTable.My.Resources.Resources.shadow1
        Me.ShadowPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ShadowPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.ShadowPanel.Location = New System.Drawing.Point(0, 0)
        Me.ShadowPanel.Name = "ShadowPanel"
        Me.ShadowPanel.Size = New System.Drawing.Size(252, 10)
        Me.ShadowPanel.TabIndex = 3
        '
        'TitlePanel
        '
        Me.TitlePanel.BackColor = System.Drawing.Color.DodgerBlue
        Me.TitlePanel.Controls.Add(Me.TableLayoutPanel1)
        Me.TitlePanel.Controls.Add(Me.Panel3)
        Me.TitlePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TitlePanel.Location = New System.Drawing.Point(3, 3)
        Me.TitlePanel.Name = "TitlePanel"
        Me.TitlePanel.Size = New System.Drawing.Size(252, 53)
        Me.TitlePanel.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.SubTitleLabel, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.UpperTitleLabel, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.74648!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.25352!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(208, 53)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'SubTitleLabel
        '
        Me.SubTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubTitleLabel.Font = New System.Drawing.Font("맑은 고딕", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.SubTitleLabel.ForeColor = System.Drawing.Color.White
        Me.SubTitleLabel.Location = New System.Drawing.Point(3, 30)
        Me.SubTitleLabel.Name = "SubTitleLabel"
        Me.SubTitleLabel.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.SubTitleLabel.Size = New System.Drawing.Size(202, 23)
        Me.SubTitleLabel.TabIndex = 1
        Me.SubTitleLabel.Text = "SubTitleLabel"
        '
        'UpperTitleLabel
        '
        Me.UpperTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UpperTitleLabel.Font = New System.Drawing.Font("맑은 고딕", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.UpperTitleLabel.ForeColor = System.Drawing.Color.White
        Me.UpperTitleLabel.Location = New System.Drawing.Point(3, 0)
        Me.UpperTitleLabel.Name = "UpperTitleLabel"
        Me.UpperTitleLabel.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.UpperTitleLabel.Size = New System.Drawing.Size(202, 30)
        Me.UpperTitleLabel.TabIndex = 0
        Me.UpperTitleLabel.Text = "UpperTitleLabel"
        Me.UpperTitleLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.EditBT)
        Me.Panel3.Controls.Add(Me.CloseBT)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(208, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(44, 53)
        Me.Panel3.TabIndex = 0
        '
        'EditBT
        '
        Me.EditBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EditBT.Image = Global.uTable.My.Resources.Resources.bt_edit_w
        Me.EditBT.Location = New System.Drawing.Point(0, 28)
        Me.EditBT.Name = "EditBT"
        Me.EditBT.Size = New System.Drawing.Size(44, 25)
        Me.EditBT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EditBT.TabIndex = 7
        Me.EditBT.TabStop = False
        '
        'CloseBT
        '
        Me.CloseBT.Dock = System.Windows.Forms.DockStyle.Top
        Me.CloseBT.Image = Global.uTable.My.Resources.Resources.closeicon_w
        Me.CloseBT.Location = New System.Drawing.Point(0, 0)
        Me.CloseBT.Name = "CloseBT"
        Me.CloseBT.Size = New System.Drawing.Size(44, 28)
        Me.CloseBT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CloseBT.TabIndex = 6
        Me.CloseBT.TabStop = False
        '
        'UpperPanel
        '
        Me.UpperPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.UpperPanel.Controls.Add(Me.TitlePanel)
        Me.UpperPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.UpperPanel.Location = New System.Drawing.Point(0, 0)
        Me.UpperPanel.Name = "UpperPanel"
        Me.UpperPanel.Padding = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.UpperPanel.Size = New System.Drawing.Size(258, 56)
        Me.UpperPanel.TabIndex = 2
        '
        'MainPanel
        '
        Me.MainPanel.BackColor = System.Drawing.Color.LightGray
        Me.MainPanel.Controls.Add(Me.BodyPanel)
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanel.Location = New System.Drawing.Point(0, 56)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.MainPanel.Size = New System.Drawing.Size(258, 168)
        Me.MainPanel.TabIndex = 2
        '
        'ViewCourse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(258, 224)
        Me.Controls.Add(Me.MainPanel)
        Me.Controls.Add(Me.UpperPanel)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = Global.uTable.My.Resources.Resources.ptable_icon
        Me.MinimumSize = New System.Drawing.Size(150, 200)
        Me.Name = "ViewCourse"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "수업 추가/수정"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.BodyPanel.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TitlePanel.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.EditBT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CloseBT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UpperPanel.ResumeLayout(False)
        Me.MainPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BodyPanel As Panel
    Friend WithEvents TitlePanel As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents CloseBT As PictureBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents SubTitleLabel As Label
    Friend WithEvents UpperTitleLabel As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents MemoTB As TextBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents SaveBT As Button
    Friend WithEvents CancelBT As Button
    Friend WithEvents ShadowPanel As Panel
    Friend WithEvents UpperPanel As Panel
    Friend WithEvents MainPanel As Panel
    Friend WithEvents EditBT As PictureBox
End Class
