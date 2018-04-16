Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace Q346919
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			DataContext = DataList.Create()
			InitializeComponent()
		End Sub
	End Class

	Public Class DataList
		Inherits List(Of Data)
		Public Shared Function Create() As DataList
			Dim res As New DataList()
			For i As Integer = 0 To 9
				For j As Integer = 0 To 9
					Dim item As New Data() With {.Value1 = "Value1 = " & i.ToString(), .Value2 = "Value2 = " & j.ToString()}
					res.Add(item)
				Next j
			Next i
			Return res
		End Function
	End Class
	Public Class Data
		Private privateValue1 As String
		Public Property Value1() As String
			Get
				Return privateValue1
			End Get
			Set(ByVal value As String)
				privateValue1 = value
			End Set
		End Property
		Private privateValue2 As String
		Public Property Value2() As String
			Get
				Return privateValue2
			End Get
			Set(ByVal value As String)
				privateValue2 = value
			End Set
		End Property
	End Class
End Namespace
