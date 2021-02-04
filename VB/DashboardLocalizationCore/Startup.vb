Imports DevExpress.AspNetCore
Imports DevExpress.DashboardAspNetCore
Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.FileProviders
Imports Microsoft.Extensions.Hosting

Namespace ASPNETCore30Dashboard
	Public Class Startup
		Public Sub New(ByVal configuration As IConfiguration, ByVal hostingEnvironment As IWebHostEnvironment)
			Me.Configuration = configuration
			FileProvider = hostingEnvironment.ContentRootFileProvider
		End Sub

		Public ReadOnly Property Configuration() As IConfiguration
		Public ReadOnly Property FileProvider() As IFileProvider

		' This method gets called by the runtime. Use this method to add services to the container.
		Public Sub ConfigureServices(ByVal services As IServiceCollection)
			' Configures services to use the Web Dashboard Control.
			services.AddDevExpressControls().AddControllersWithViews().AddDefaultDashboardController(Sub(configurator)
				configurator.SetDashboardStorage(New DashboardFileStorage(FileProvider.GetFileInfo("App_Data/Dashboards").PhysicalPath))
				Dim dataSourceStorage As New DataSourceInMemoryStorage()
				Dim objDataSource As New DashboardObjectDataSource("ObjectDataSource", GetType(ProductSales))
				objDataSource.DataMember = "GetProductSales"
				dataSourceStorage.RegisterDataSource("objectDataSource", objDataSource.SaveToXml())
				configurator.SetDataSourceStorage(dataSourceStorage)
			End Sub)
		End Sub

		' This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		Public Sub Configure(ByVal app As IApplicationBuilder, ByVal env As IWebHostEnvironment)
			Dim supportedCultures = { "en-US", "de-DE" }
			Dim opts = (New RequestLocalizationOptions()).SetDefaultCulture(supportedCultures(1)).AddSupportedCultures(supportedCultures).AddSupportedUICultures(supportedCultures)
			opts.RequestCultureProviders.Clear()
			app.UseRequestLocalization(opts)

			If env.IsDevelopment() Then
				app.UseDeveloperExceptionPage()
			Else
				app.UseExceptionHandler("/Home/Error")
				app.UseHsts()
			End If
			app.UseHttpsRedirection()
			app.UseStaticFiles()
			' Registers the DevExpress middleware.
			app.UseDevExpressControls()
			app.UseRouting()
			app.UseAuthorization()
			app.UseEndpoints(Sub(endpoints)
				EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "api/dashboards")
				endpoints.MapControllerRoute(name:= "default", pattern:= "{controller=Home}/{action=Index}/{id?}")
			End Sub)
		End Sub
	End Class
End Namespace
