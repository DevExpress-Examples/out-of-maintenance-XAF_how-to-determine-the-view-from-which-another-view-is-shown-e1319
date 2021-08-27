<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128589310/12.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1319)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MainWindowController.cs](./CS/WinWebSolution.Module/MainWindowController.cs) (VB: [MainWindowController.vb](./VB/WinWebSolution.Module/MainWindowController.vb))
<!-- default file list end -->
# How to determine the View, from which another view is shown


<p>This Controller below demonstrates how to handle the <a href="http://documentation.devexpress.com/#Xaf/DevExpressExpressAppXafApplication_ViewShowingtopic">ViewShowing</a>  and <a href="http://documentation.devexpress.com/#Xaf/DevExpressExpressAppXafApplication_ViewShowntopic">ViewShown</a> events of the XafApplication class, to provide interaction between views.<br />Use the SourceFrame and TargetFrame properties of the event arguments for additional context information.<br /><br /></p>


```cs
using System;
using DevExpress.ExpressApp;

namespace WinWebSolution.Module {
    public class MainWindowController : WindowController {
        public MainWindowController() {
            TargetWindowType = WindowType.Main;
        }
        protected override void OnActivated() {
            base.OnActivated();
            Application.ViewShowing += new EventHandler<ViewShowingEventArgs>(Application_ViewShowing);
            Application.ViewShown += new EventHandler<ViewShownEventArgs>(Application_ViewShown);
        }
        void Application_ViewShowing(object sender, ViewShowingEventArgs e) {
            if (e.SourceFrame != null && e.SourceFrame.View != null && e.SourceFrame.View.Id == "Party_PhoneNumbers_ListView") {
                Frame phoneNumberFrame = e.TargetFrame;
                DetailView phoneNumberDetailView = (DetailView)e.View;
                //...
            }
        }
        //OR
        void Application_ViewShown(object sender, ViewShownEventArgs e) {
            if (e.SourceFrame != null && e.SourceFrame.View != null && e.SourceFrame.View.Id == "Party_PhoneNumbers_ListView") {
                Frame phoneNumberFrame = e.SourceFrame;
                DetailView phoneNumberDetailView = (DetailView)phoneNumberFrame.View;
                //...
            }
        }
        protected override void OnDeactivated() {
            Application.ViewShown -= new EventHandler<ViewShownEventArgs>(Application_ViewShown);
            base.OnDeactivated();
        }
    }
}
```


<p> </p>


```vb
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
                Dim phoneNumberFrame As Frame = e.TargetFrame
                Dim phoneNumberDetailView As DetailView = CType(e.View, DetailView)
                '...
            End If
        End Sub
        'OR
        Private Sub Application_ViewShown(ByVal sender As Object, ByVal e As ViewShownEventArgs)
            If e.SourceFrame IsNot Nothing AndAlso e.SourceFrame.View IsNot Nothing AndAlso e.SourceFrame.View.Id = "Party_PhoneNumbers_ListView" Then
                Dim phoneNumberFrame As Frame = e.SourceFrame
                Dim phoneNumberDetailView As DetailView = CType(phoneNumberFrame.View, DetailView)
                '...
            End If
        End Sub
        Protected Overrides Sub OnDeactivated()
            RemoveHandler Application.ViewShown, AddressOf Application_ViewShown
            MyBase.OnDeactivated()
        End Sub
    End Class
End Namespace
```



<br/>


