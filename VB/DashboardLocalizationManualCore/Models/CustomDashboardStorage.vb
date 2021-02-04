Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports Microsoft.AspNetCore.Http
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Xml.Linq

Public Class CustomDashboardStorage
	Implements IEditableDashboardStorage

	Public Property RootPath() As String

	Public Sub New(ByVal path As String)
		RootPath = path
	End Sub

	Public Function GetAvailableDashboardsInfo() As IEnumerable(Of DashboardInfo)
		Dim dashboardInfos = New List(Of DashboardInfo)()

		Dim files = Directory.GetFiles(RootPath, "*.xml")

		For Each item In files
			Dim name = Path.GetFileNameWithoutExtension(item)

			If Not name.StartsWith("_") Then
				dashboardInfos.Add(New DashboardInfo() With {
					.ID = name,
					.Name = name
				})
			End If
		Next item

		Return dashboardInfos
	End Function

	Public Function LoadDashboard(ByVal dashboardID As String) As XDocument
		Dim path As System.String = System.IO.Path.Combine(RootPath, dashboardID & ".xml")
		Dim content = File.ReadAllText(path)

		Return XDocument.Parse(content)
	End Function

	Public Function AddDashboard(ByVal dashboard As XDocument, ByVal dashboardName As String) As String
'        var path = HttpContext.Current.Server.MapPath("~/App_Data/Dashboards/" + dashboardName + ".xml");
'
'        File.WriteAllText(path, dashboard.ToString());
'
'        return dashboardName;
		Return Nothing
	End Function

	Public Sub SaveDashboard(ByVal dashboardID As String, ByVal dashboard As XDocument)
'        var path = HttpContext.Current.Server.MapPath("~/App_Data/Dashboards/" + dashboardID + ".xml");
'
'        File.WriteAllText(path, dashboard.ToString());
	End Sub
End Class

