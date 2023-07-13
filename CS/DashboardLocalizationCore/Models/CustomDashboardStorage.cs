using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

public class CustomDashboardStorage : IEditableDashboardStorage {
    public string RootPath { get; set; }

    public CustomDashboardStorage(string path) {
        RootPath = path;
    }

    public IEnumerable<DashboardInfo> GetAvailableDashboardsInfo() {
        var dashboardInfos = new List<DashboardInfo>();

        var files = Directory.GetFiles(RootPath, "*.xml");

        foreach (var item in files) {
            var name = Path.GetFileNameWithoutExtension(item);

            if (!name.StartsWith("_"))
                dashboardInfos.Add(new DashboardInfo() { ID = name, Name = name });
        }

        return dashboardInfos;
    }

    public XDocument LoadDashboard(string dashboardID) {
        var path = Path.Combine(RootPath, dashboardID + ".xml");
        var content = File.ReadAllText(path);

        return XDocument.Parse(content);
    }

    public string AddDashboard(XDocument dashboard, string dashboardName) {
        /*var path = HttpContext.Current.Server.MapPath("~/App_Data/Dashboards/" + dashboardName + ".xml");

        File.WriteAllText(path, dashboard.ToString());

        return dashboardName;*/
        return null;
    }

    public void SaveDashboard(string dashboardID, XDocument dashboard) {
        /*var path = HttpContext.Current.Server.MapPath("~/App_Data/Dashboards/" + dashboardID + ".xml");

        File.WriteAllText(path, dashboard.ToString());*/
    }
}

