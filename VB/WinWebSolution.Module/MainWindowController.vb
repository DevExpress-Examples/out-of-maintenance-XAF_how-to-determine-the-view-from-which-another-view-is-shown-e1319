Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp

Namespace WinWebSolution.Module
	Public Class MainWindowController
		Inherits WindowController
		Public Sub New()
			TargetWindowType = WindowType.Main
		End Sub
		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			AddHandler Application.ViewShowing, AddressOf Application_ViewShowing
			AddHandler Application.ViewShown, AddressOf Application_ViewShown
		End Sub
        Private Sub Application_ViewShowing(ByVal sender As Object, ByVal e As ViewShowingEventArgs)
            If e.SourceFrame IsNot Nothing AndAlso e.SourceFrame.View IsNot Nothing AndAlso e.SourceFrame.View.Id = "Party_PhoneNumbers_ListView" Then
                Dim targetView As DetailView = CType(e.View, DetailView)
                Dim sourceView As ListView = CType(e.SourceFrame.View, ListView)
                '...
            End If
        End Sub
        'OR
        Private Sub Application_ViewShown(ByVal sender As Object, ByVal e As ViewShownEventArgs)
            If e.SourceFrame IsNot Nothing AndAlso e.SourceFrame.View IsNot Nothing AndAlso e.SourceFrame.View.Id = "Party_PhoneNumbers_ListView" Then
                Dim targetView As DetailView = CType(e.TargetFrame.View, DetailView)
                Dim sourceView As ListView = CType(e.SourceFrame.View, ListView)
                '...
            End If
        End Sub
        Protected Overrides Sub OnDeactivated()
            RemoveHandler Application.ViewShown, AddressOf Application_ViewShown
            MyBase.OnDeactivated()
        End Sub
    End Class
End Namespace