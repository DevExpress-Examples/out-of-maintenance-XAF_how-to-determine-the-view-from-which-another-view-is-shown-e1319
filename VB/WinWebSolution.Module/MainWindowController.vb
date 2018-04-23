Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.SystemModule

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
				Dim phoneNumberFrame As Frame = e.TargetFrame
				Dim phoneNumberDetailView As DetailView = CType(e.View, DetailView)
				'...
			End If
		End Sub
		'OR
		Private Sub Application_ViewShown(ByVal sender As Object, ByVal e As ViewShownEventArgs)
			If e.SourceFrame IsNot Nothing AndAlso e.SourceFrame.View IsNot Nothing AndAlso e.SourceFrame.View.Id = "Party_PhoneNumbers_ListView" Then
				Dim phoneNumberFrame As Frame = e.Frame
				Dim phoneNumberDetailView As DetailView = CType(phoneNumberFrame.View, DetailView)
				'...
			End If
		End Sub
		Protected Overrides Sub OnDeactivating()
			RemoveHandler Application.ViewShown, AddressOf Application_ViewShown
			MyBase.OnDeactivating()
		End Sub
	End Class
End Namespace