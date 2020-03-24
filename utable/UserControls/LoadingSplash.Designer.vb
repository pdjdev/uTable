<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoadingSplash
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.P1 = New System.Windows.Forms.Panel()
        Me.P2 = New System.Windows.Forms.Panel()
        Me.P3 = New System.Windows.Forms.Panel()
        Me.P4 = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.P1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.P2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.P3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.P4, 2, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(120, 120)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'P1
        '
        Me.P1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.P1.Location = New System.Drawing.Point(3, 3)
        Me.P1.Name = "P1"
        Me.P1.Size = New System.Drawing.Size(48, 48)
        Me.P1.TabIndex = 0
        '
        'P2
        '
        Me.P2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.P2.Location = New System.Drawing.Point(69, 3)
        Me.P2.Name = "P2"
        Me.P2.Size = New System.Drawing.Size(48, 48)
        Me.P2.TabIndex = 1
        '
        'P3
        '
        Me.P3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.P3.Location = New System.Drawing.Point(3, 69)
        Me.P3.Name = "P3"
        Me.P3.Size = New System.Drawing.Size(48, 48)
        Me.P3.TabIndex = 2
        '
        'P4
        '
        Me.P4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.P4.Location = New System.Drawing.Point(69, 69)
        Me.P4.Name = "P4"
        Me.P4.Size = New System.Drawing.Size(48, 48)
        Me.P4.TabIndex = 3
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'LoadingSplash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Name = "LoadingSplash"
        Me.Size = New System.Drawing.Size(120, 120)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents P1 As Panel
    Friend WithEvents P2 As Panel
    Friend WithEvents P3 As Panel
    Friend WithEvents P4 As Panel
    Friend WithEvents Timer1 As Timer
End Class
