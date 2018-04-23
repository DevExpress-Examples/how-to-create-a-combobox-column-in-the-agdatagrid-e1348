Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.AgDataGrid

Namespace ComboInGridExample
	Partial Public Class Page
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
		End Sub
	End Class
	Public Class MyGrid
		Inherits AgDataGrid
		Protected Overrides Sub OnCurrentEditorLostFocus(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If TypeOf CurrentEditor Is ComboBox Then
				Return
			Else
				MyBase.OnCurrentEditorLostFocus(sender, e)
			End If
		End Sub
	End Class
	Public Class DataSourceNamesDictionary
		Inherits List(Of String)
		Public Sub New()
			For Each p As Person In New Persons()
				If (Not Contains(p.Name)) Then
					Add(p.Name)
				End If
			Next p
		End Sub
	End Class
	Public Class Person
		Private privateID As Integer
		Public Property ID() As Integer
			Get
				Return privateID
			End Get
			Set(ByVal value As Integer)
				privateID = value
			End Set
		End Property
		Private privateName As String
		Public Property Name() As String
			Get
				Return privateName
			End Get
			Set(ByVal value As String)
				privateName = value
			End Set
		End Property
		Public Sub New(ByVal i As Integer)
			ID = i
			Name = "John_" & i.ToString()
		End Sub
	End Class
	Public Class Persons
		Inherits List(Of Person)
		Public Sub New()
			For i As Integer = 0 To 9
				Add(New Person(i))
			Next i
		End Sub
	End Class

End Namespace
