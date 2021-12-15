Imports System.Drawing.Printing

Public Class PrintingFormat

    Private mTopLeft As StringFormat = New StringFormat()
    Private mTopCenter As StringFormat = New StringFormat()
    Private mTopRight As StringFormat = New StringFormat()
    Private mMidLeft As StringFormat = New StringFormat()
    Private mMidCenter As StringFormat = New StringFormat()
    Private mMidRight As StringFormat = New StringFormat()
    Private mBotLeft As StringFormat = New StringFormat()
    Private mBotCenter As StringFormat = New StringFormat()
    Private mBotRight As StringFormat = New StringFormat()

    Public ReadOnly Property FntTitle() As Font
        Get
            Return New Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point)
        End Get
    End Property

    Public ReadOnly Property FntTableHeader() As Font
        Get
            Return New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point)
        End Get
    End Property

    Public ReadOnly Property FntTableCell() As Font
        Get
            Return New Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point)
        End Get
    End Property


    Public ReadOnly Property TopLeft As StringFormat
        Get
            mTopLeft.LineAlignment = StringAlignment.Near
            mTopLeft.Alignment = StringAlignment.Near
            Return mTopLeft
        End Get
    End Property

    Public ReadOnly Property TopCenter As StringFormat
        Get
            mTopCenter.LineAlignment = StringAlignment.Near
            mTopCenter.Alignment = StringAlignment.Center
            Return mTopCenter
        End Get
    End Property

    Public ReadOnly Property TopRight As StringFormat
        Get
            mTopRight.LineAlignment = StringAlignment.Near
            mTopRight.Alignment = StringAlignment.Far
            Return mTopRight
        End Get
    End Property

    Public ReadOnly Property MidLeft As StringFormat
        Get
            mMidLeft.LineAlignment = StringAlignment.Center
            mMidLeft.Alignment = StringAlignment.Near
            Return mMidLeft
        End Get
    End Property

    Public ReadOnly Property MidCenter As StringFormat
        Get
            mMidCenter.LineAlignment = StringAlignment.Center
            mMidCenter.Alignment = StringAlignment.Center
            Return mMidCenter
        End Get
    End Property

    Public ReadOnly Property MidRight As StringFormat
        Get
            mMidRight.LineAlignment = StringAlignment.Center
            mMidRight.Alignment = StringAlignment.Far
            Return mMidRight
        End Get
    End Property

    Public ReadOnly Property BotLeft As StringFormat
        Get
            mBotLeft.LineAlignment = StringAlignment.Far
            mBotLeft.Alignment = StringAlignment.Near
            Return mBotLeft
        End Get
    End Property

    Public ReadOnly Property BotCenter As StringFormat
        Get
            mBotCenter.LineAlignment = StringAlignment.Far
            mBotCenter.Alignment = StringAlignment.Center
            Return mBotCenter
        End Get
    End Property

    Public ReadOnly Property BotRight As StringFormat
        Get
            mBotRight.LineAlignment = StringAlignment.Far
            mBotRight.Alignment = StringAlignment.Far
            Return mBotRight
        End Get
    End Property


    Public Function PrintCellText(ByVal strValue As String, ByVal x As Integer, ByVal y As Integer,
                              ByVal w As Integer, ByVal e As System.Drawing.Printing.PrintPageEventArgs,
                              Font As Font, Format As StringFormat, Optional Border As Boolean = False,
                              Optional Fill As Brush = Nothing, Optional h As Integer = 0) As Integer
        Dim cellRect As RectangleF = New RectangleF()
        cellRect.Location = New Point(x, y)

        If h > 0 Then
            cellRect.Size = New Size(w, h)
        Else
            cellRect.Size = New Size(w, 10 +
                                 (CInt(e.Graphics.MeasureString(strValue, Font, w - 10,
                                  StringFormat.GenericTypographic).Height)))
        End If


        If IsNothing(Fill) = False Then
            e.Graphics.FillRectangle(Fill, Rectangle.Round(cellRect))
        End If

        e.Graphics.DrawString(strValue, Font, Brushes.Black, cellRect, Format)

        If Border = True Then
            e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(cellRect))
        Else
            e.Graphics.DrawRectangle(Pens.Transparent, Rectangle.Round(cellRect))
        End If

        Return y + cellRect.Size.Height
    End Function

End Class
