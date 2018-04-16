Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpf.Grid
Imports System.Windows.Interactivity
Imports System.Windows
Imports DevExpress.Xpf.Core.Native
Imports DevExpress.Xpf.Core
Imports System.Windows.Controls
Imports System.Windows.Data

Namespace Q346919
	Public Class GridCustomBehavior
		Inherits Behavior(Of TableView)
		Public Shared ReadOnly GridBottomContentProperty As DependencyProperty = DependencyProperty.Register("GridBottomContent", GetType(Object), GetType(GridCustomBehavior), New PropertyMetadata(Nothing))
		Public Shared ReadOnly GridBottomContentTemplateProperty As DependencyProperty = DependencyProperty.Register("GridBottomContentTemplate", GetType(DataTemplate), GetType(GridCustomBehavior), New PropertyMetadata(Nothing))
		Public Property GridBottomContent() As Object
			Get
				Return CObj(GetValue(GridBottomContentProperty))
			End Get
			Set(ByVal value As Object)
				SetValue(GridBottomContentProperty, value)
			End Set
		End Property
		Public Property GridBottomContentTemplate() As DataTemplate
			Get
				Return CType(GetValue(GridBottomContentTemplateProperty), DataTemplate)
			End Get
			Set(ByVal value As DataTemplate)
				SetValue(GridBottomContentTemplateProperty, value)
			End Set
		End Property

		Public Sub New()
			GridBottomControl = New ContentControl()
			BindingOperations.SetBinding(GridBottomControl, ContentControl.ContentProperty, New Binding("GridBottomContent") With {.Source = Me})
			BindingOperations.SetBinding(GridBottomControl, ContentControl.ContentTemplateProperty, New Binding("GridBottomContentTemplate") With {.Source = Me})
		End Sub
		Private privateGridBottomControl As ContentControl
		Protected Property GridBottomControl() As ContentControl
			Get
				Return privateGridBottomControl
			End Get
			Private Set(ByVal value As ContentControl)
				privateGridBottomControl = value
			End Set
		End Property
		Protected ReadOnly Property GridView() As TableView
			Get
				Return AssociatedObject
			End Get
		End Property
		Protected Overrides Sub OnAttached()
			MyBase.OnAttached()
			AddHandler GridView.Loaded, AddressOf OnGridLoaded
		End Sub
		Private Sub OnGridLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			RemoveHandler GridView.Loaded, AddressOf OnGridLoaded
			Dim filterPanel As FilterPanelControl = TryCast(LayoutHelper.FindElementByName(GridView, "PART_FilterPanel"), FilterPanelControl)
			If filterPanel Is Nothing Then
				Return
			End If
			Dim dockPanel As DXDockPanel = TryCast(filterPanel.Parent, DXDockPanel)
			If dockPanel Is Nothing Then
				Return
			End If
			DXDockPanel.SetDock(GridBottomControl, Dock.Bottom)
			dockPanel.Children.Insert(0, GridBottomControl)
		End Sub
	End Class
End Namespace
