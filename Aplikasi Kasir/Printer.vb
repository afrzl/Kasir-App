Imports System.Drawing.Printing

Public Class PrintData

    Private mID As Integer = Nothing
    Private mStringValue As String = Nothing
    Private mFnt As Font = Nothing
    Private mColumnWidth() As Integer = Nothing
    Private mCAlign() As StringFormat = Nothing
    Private miLeft As Integer = Nothing
    Private mImg As Image = Nothing

    Private mWidth As Integer = Nothing
    Private mHeight As Integer = Nothing


    Public Sub New(ByVal Id As Integer, Optional StringValue As String = "", Optional Fnt As Font = Nothing,
                   Optional ColumnWidth() As Integer = Nothing, Optional CAlign() As StringFormat = Nothing,
                   Optional iLeft As Integer = 0)
        Me.mID = Id
        Me.mStringValue = StringValue
        Me.mFnt = Fnt
        Me.mColumnWidth = ColumnWidth
        Me.mCAlign = CAlign
        Me.miLeft = iLeft
    End Sub

    Public Sub New(ByVal Id As Integer, ByVal img As Image)
        Me.mID = Id
        Me.mImg = img
    End Sub

    Public Sub New(ByVal Id As Integer, ByVal img As Image, ByVal Width As Integer, ByVal Height As Integer)
        Me.mID = Id
        Me.mImg = img
        Me.mWidth = Width
        Me.mHeight = Height
    End Sub


    Public Property Id() As Integer
        Get
            Return mID
        End Get
        Set(value As Integer)
            mID = value
        End Set
    End Property

    Public Property StringValue() As String
        Get
            Return mStringValue
        End Get
        Set(value As String)
            mStringValue = value
        End Set
    End Property

    Public Property Fnt() As Font
        Get
            Return mFnt
        End Get
        Set(value As Font)
            mFnt = value
        End Set
    End Property

    Public Property ColumnWidth() As Integer()
        Get
            Return mColumnWidth
        End Get
        Set(value As Integer())
            mColumnWidth = value
        End Set
    End Property

    Public Property CAlign() As StringFormat()
        Get
            Return mCAlign
        End Get
        Set(value As StringFormat())
            mCAlign = value
        End Set
    End Property

    Public Property iLeft() As Integer
        Get
            Return miLeft
        End Get
        Set(value As Integer)
            miLeft = value
        End Set
    End Property

    Public Property img() As Image
        Get
            Return mImg
        End Get
        Set(value As Image)
            mImg = value
        End Set
    End Property

    Public Property Width() As Integer
        Get
            Return mWidth
        End Get
        Set(value As Integer)
            mWidth = value
        End Set
    End Property

    Public Property Height() As Integer
        Get
            Return mHeight
        End Get
        Set(value As Integer)
            mHeight = value
        End Set
    End Property

End Class

Public Class PrintDatalist
    Inherits CollectionBase

    Public Function Add(ByVal Id As Integer, StringValue As String, Fnt As Font, Optional ColumnWidth() As Integer = Nothing,
                        Optional CAlign() As StringFormat = Nothing, Optional iLeft As Integer = 0) As PrintData
        Dim PrintData As New PrintData(Id, StringValue, Fnt, ColumnWidth, CAlign, iLeft)
        Me.InnerList.Add(PrintData)
        Return PrintData
    End Function

    Public Function Add(ByVal Id As Integer, ByVal img As Image) As PrintData
        Dim PrintData As New PrintData(Id, img)
        Me.InnerList.Add(PrintData)
        Return PrintData
    End Function

    Public Function Add(ByVal Id As Integer, ByVal img As Image, ByVal Width As Integer, ByVal Height As Integer) As PrintData
        Dim PrintData As New PrintData(Id, img, Width, Height)
        Me.InnerList.Add(PrintData)
        Return PrintData
    End Function

    Default Public ReadOnly Property Item(ByVal Index As Integer) As PrintData
        Get
            If Index > Me.InnerList.Count - 1 OrElse Index < 0 Then
                Throw New IndexOutOfRangeException("Index out of Range")
            Else
                Return DirectCast(Me.InnerList.Item(Index), PrintData)
            End If
        End Get
    End Property

    Public Function IndexOf(ByVal Id As Integer) As Integer
        Dim PrintData As PrintData
        Dim FoundIndex As Integer = -1

        For i As Integer = 0 To Me.InnerList.Count - 1
            PrintData = DirectCast(Me.InnerList.Item(i), PrintData)
            If PrintData.Id = Id Then
                FoundIndex = i
                Exit For
            End If
        Next
        Return FoundIndex
    End Function

    Public Shared Function AddItemToDataList(ByRef PrintDatalist As PrintDatalist, ByVal Id As Integer, StringValue As String,
                                             Fnt As Font, Optional ColumnWidth() As Integer = Nothing,
                                             Optional CFormat() As StringFormat = Nothing, Optional iLeft As Integer = 0)
        PrintDatalist.Add(Id, StringValue, Fnt, ColumnWidth, CFormat, iLeft)
        Return PrintDatalist
    End Function

    Public Shared Function AddItemToDataList(ByRef PrintDatalist As PrintDatalist, ByVal Id As Integer, ByVal Img As Image)
        PrintDatalist.Add(Id, Img)
        Return PrintDatalist
    End Function

    Public Shared Function AddItemToDataList(ByRef PrintDatalist As PrintDatalist, ByVal Id As Integer, ByVal Img As Image, ByVal Width As Integer, ByVal Height As Integer)
        PrintDatalist.Add(Id, Img, Width, Height)
        Return PrintDatalist
    End Function

End Class


Public Class Printer
    Private Shared Lines As New Queue(Of String)
    Private Shared _myfont As Font
    Private Shared prn As Printing.PrintDocument
    Private Shared PrintDatalist As New PrintDatalist
    Private Shared c As New PrintingFormat
    Private Shared row As Long = 0

    Shared Sub New()
        PrintDatalist = New PrintDatalist
        _myfont = New Font("Courier New", 8, FontStyle.Regular, GraphicsUnit.Point) 'Default
        prn = New Printing.PrintDocument
        row = 0
        AddHandler prn.PrintPage, AddressOf Document_PrintPage

    End Sub

    Public Shared Sub NewPrint()
        PrintDatalist = New PrintDatalist
        _myfont = New Font("Courier New", 8, FontStyle.Regular, GraphicsUnit.Point) 'Default
        prn = New Printing.PrintDocument
        row = 0

        Dim PS1 As New System.Drawing.Printing.PageSettings
        With PS1
            .PaperSize = (From s As PaperSize In prn.PrinterSettings.PaperSizes.Cast(Of PaperSize)()).FirstOrDefault
            .Margins.Left = 0
            .Margins.Right = 0
            .Margins.Top = 0
            .Margins.Bottom = 0
        End With
        prn.DefaultPageSettings = PS1

        AddHandler prn.PrintPage, AddressOf Document_PrintPage
    End Sub

    Public Shared Sub SetFont(ByVal FontFamily As String, emSize As Single, style As FontStyle)
        _myfont = New Font(FontFamily, emSize, style, GraphicsUnit.Point)
    End Sub

    Public Shared Sub Print(ByVal text As String)
        PrintDatalist = PrintDatalist.AddItemToDataList(PrintDatalist, PrintDatalist.Count, text, _myfont)
    End Sub

    Public Shared Sub Print(ByVal text As String, arrWidth() As Integer)
        PrintDatalist = PrintDatalist.AddItemToDataList(PrintDatalist, PrintDatalist.Count, text, _myfont, arrWidth)
    End Sub

    Public Shared Sub Print(ByVal text As String, arrWidth() As Integer, arrFormat() As StringFormat)
        PrintDatalist = PrintDatalist.AddItemToDataList(PrintDatalist, PrintDatalist.Count, text, _myfont, arrWidth, arrFormat)
    End Sub

    Public Shared Sub Print(ByVal text As String, arrWidth() As Integer, ByVal iLeft As Integer)
        PrintDatalist = PrintDatalist.AddItemToDataList(PrintDatalist, PrintDatalist.Count, text, _myfont, arrWidth, , iLeft)
    End Sub

    Public Shared Sub Print(ByVal img As Image)
        PrintDatalist = PrintDatalist.AddItemToDataList(PrintDatalist, PrintDatalist.Count, img)
    End Sub

    Public Shared Sub Print(ByVal img As Image, ByVal Width As Integer, ByVal Height As Integer)
        PrintDatalist = PrintDatalist.AddItemToDataList(PrintDatalist, PrintDatalist.Count, img, Width, Height)
    End Sub

    Public Shared Sub DoPrint()
        prn.Print()
    End Sub

    Private Shared Sub Document_PrintPage(ByVal sender As Object,
        ByVal e As Printing.PrintPageEventArgs)
        Dim curY As Integer = e.PageSettings.HardMarginY
        Dim xZero As Integer = 0
        Dim data As PrintData = Nothing

        Dim cFormat As StringFormat = c.MidLeft
        Do While row < PrintDatalist.Count
            data = PrintDatalist.Item(row)

            If Not data.img Is Nothing Then
                If data.Width = Nothing Then
                    e.Graphics.DrawImage(data.img, data.iLeft, curY)
                    curY = curY + data.img.Height
                Else
                    e.Graphics.DrawImage(data.img, data.iLeft, curY, data.Width, data.Height)
                    curY = curY + data.Height
                End If
            ElseIf data.ColumnWidth Is Nothing Then
                cFormat = c.MidLeft
                If Not data.CAlign Is Nothing Then cFormat = data.CAlign(0)
                If data.iLeft > 0 Then
                    curY = c.PrintCellText(data.StringValue, data.iLeft, curY, e.PageBounds.Width, e, data.Fnt, cFormat, False) - 8
                Else
                    curY = c.PrintCellText(data.StringValue, xZero, curY, e.PageBounds.Width, e, data.Fnt, cFormat, False) - 8
                End If
            Else
                Dim words As String() = data.StringValue.Split(New Char() {";"c}) : Dim word As String
                Dim iWidth As Integer : Dim iCol As Integer = 0 : Dim x As Integer = xZero
                If data.iLeft > 0 Then x = data.iLeft
                Dim iMore As Integer : Dim y As Integer = curY
                Dim iFormat As Integer = 0
                For Each word In words
                    If iCol > data.ColumnWidth.Count - 1 Then iCol = 0
                    iWidth = data.ColumnWidth(iCol)
                    If Not data.CAlign Is Nothing Then
                        If iFormat > data.CAlign.Count - 1 Then iFormat = 0
                        If iFormat < data.CAlign.Length Then cFormat = data.CAlign(iFormat)
                    End If
                    iMore = c.PrintCellText(word, x, y, iWidth, e, data.Fnt, cFormat, False) - 8

                    If iMore > curY Then curY = iMore
                    iCol = iCol + 1
                    iFormat = iFormat + 1
                    x = x + iWidth
                Next
            End If
            row = row + 1
            If curY >= 0.99 * e.PageBounds.Height Then
                e.HasMorePages = True
                Return
            End If
        Loop
    End Sub
End Class