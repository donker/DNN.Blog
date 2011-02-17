'
' DotNetNuke -  http://www.dotnetnuke.com
' Copyright (c) 2002-2010
' by Perpetual Motion Interactive Systems Inc. ( http://www.perpetualmotion.ca )
'
' Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
' documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
' the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
' to permit persons to whom the Software is furnished to do so, subject to the following conditions:
'
' The above copyright notice and this permission notice shall be included in all copies or substantial portions 
' of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
' DEALINGS IN THE SOFTWARE.
'-------------------------------------------------------------------------

Imports System
Imports System.Web.UI
Imports System.Web
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke

Public Class BlogModuleBase
  Inherits PortalModuleBase

#Region " Public Constants "
  Public Const RSS_RECENT_ENTRIES As Integer = 0
  Public Const RSS_BLOG_ENTRIES As Integer = 1
  Public Const RSS_SINGLE_ENTRY As Integer = 2
  Public Const RSS_ARCHIV_VIEW As Integer = 3
  Public Const CONTROL_VIEW_VIEWBLOG As String = "ViewBlog.ascx"
  Public Const CONTROL_VIEW_VIEWENTRY As String = "ViewEntry.ascx"
  Public Const CONTROL_VIEW_BLOGFEED As String = "BlogFeed.ascx"
  Public Const ONLINE_HELP_URL As String = ""
  Public Const BLOG_TEMPLATES_RESOURCE As String = "/DesktopModules/Blog/App_LocalResources/BlogTemplates.ascx.resx"
#End Region

#Region " Public Enums "
#End Region

#Region " Public Members "
  Public MyActions As New Entities.Modules.Actions.ModuleActionCollection
  Public Shared RssView As RssViews
#End Region

#Region " Public Methods "
  Public Sub SetModuleConfiguration(ByVal config As Entities.Modules.ModuleInfo)
    ModuleConfiguration = config
  End Sub

  Public Sub AddJQuery()
    Dim alreadyRequested As Boolean = False
    If HttpContext.Current.Items("jQueryRequested") IsNot Nothing Then
      alreadyRequested = Convert.ToBoolean(HttpContext.Current.Items("jQueryRequested"))
    End If
    If alreadyRequested Then Exit Sub ' let DNN 5 handle it
    Page.ClientScript.RegisterClientScriptInclude("jQuery", DotNetNuke.Common.ApplicationPath & "/DesktopModules/Blog/js/jquery.min.js")
    HttpContext.Current.Items("jquery_registered") = True ' let DNN 5 know we've added it
  End Sub
#End Region

#Region " Public Properties "
  Public ReadOnly Property BasePage() As DotNetNuke.Framework.CDefault
    Get
      Try
        Return CType(Me.Page, DotNetNuke.Framework.CDefault)
      Catch
        Return Nothing
      End Try
    End Get
  End Property

  Public Property BlogSettings() As Settings.BlogSettings
    Get
      If _blogSettings Is Nothing Then
        _blogSettings = DotNetNuke.Modules.Blog.Settings.BlogSettings.GetBlogSettings(PortalId, TabId)
      End If
      Return _blogSettings
    End Get
    Set(ByVal value As Settings.BlogSettings)
      _blogSettings = value
    End Set
  End Property

  Public Property OutputAdditionalFiles() As Boolean
    Get
      Return _outputAdditionalFiles
    End Get
    Set(ByVal value As Boolean)
      _outputAdditionalFiles = value
    End Set
  End Property
#End Region

#Region " Private Members "
  Private _blogSettings As Settings.BlogSettings
  Private _outputAdditionalFiles As Boolean = False
#End Region

#Region " Event Handlers "
  Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    Dim script As New StringBuilder
    script.AppendLine("<script type=""text/javascript"">")
    script.AppendLine("//<![CDATA[")
    script.AppendLine(String.Format("var appPath='{0}'", DotNetNuke.Common.ApplicationPath))
    script.AppendLine("//]]>")
    script.AppendLine("</script>")
    UI.Utilities.ClientAPI.RegisterClientScriptBlock(Page, "blogAppPath", script.ToString)
  End Sub

  Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
    If OutputAdditionalFiles Then
      If BlogSettings.AddJQuery Then
        AddJQuery()
      End If
      For Each f As String In BlogSettings.IncludeFiles.Split(";"c)
        If Not String.IsNullOrEmpty(f) Then
          If f.ToLower.EndsWith(".js") Then
            Page.ClientScript.RegisterClientScriptInclude(f.Replace("[", "").Replace("]", "_").Replace("/", "_"), f.Replace("[P]", PortalSettings.HomeDirectory & "Blog/Include/").Replace("[H]", DotNetNuke.Common.ApplicationPath & "/DesktopModules/Blog/include/"))
          ElseIf f.ToLower.EndsWith(".css") Then
            CType(Me.Page, DotNetNuke.Framework.CDefault).AddStyleSheet(f.Replace("[", "").Replace("]", "_").Replace("/", "_"), f.Replace("[P]", PortalSettings.HomeDirectory & "Blog/Include/").Replace("[H]", DotNetNuke.Common.ApplicationPath & "/DesktopModules/Blog/include/"))
          End If
        End If
      Next
    End If
  End Sub
#End Region

End Class
