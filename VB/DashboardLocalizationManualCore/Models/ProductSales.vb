Imports System
Imports System.Collections.Generic

Public Class ProductSales
	Public Property OrderID() As Integer
	Public Property Category() As String
	Public Property Product() As String
	Public Property Sales() As Integer
	Public Property OrderDate() As DateTime

	Public Shared Function GetProductSales() As List(Of ProductSales)
		Dim data As New List(Of ProductSales)()

		data.Add(New ProductSales() With {
			.OrderID = 1,
			.Category = "Beverages",
			.Product = "Chai",
			.Sales = 10,
			.OrderDate = DateTime.Today
		})
		data.Add(New ProductSales() With {
			.OrderID = 2,
			.Category = "Beverages",
			.Product = "Chai",
			.Sales = 15,
			.OrderDate = DateTime.Today
		})
		data.Add(New ProductSales() With {
			.OrderID = 3,
			.Category = "Beverages",
			.Product = "Coffee",
			.Sales = 35,
			.OrderDate = DateTime.Today.AddMonths(3)
		})
		data.Add(New ProductSales() With {
			.OrderID = 4,
			.Category = "Beverages",
			.Product = "Coffee",
			.Sales = 20,
			.OrderDate = DateTime.Today.AddMonths(3)
		})
		data.Add(New ProductSales() With {
			.OrderID = 5,
			.Category = "Confections",
			.Product = "Chocolate",
			.Sales = 40,
			.OrderDate = DateTime.Today.AddMonths(3)
		})
		data.Add(New ProductSales() With {
			.OrderID = 6,
			.Category = "Confections",
			.Product = "Chocolate",
			.Sales = 55,
			.OrderDate = DateTime.Today.AddMonths(7)
		})
		data.Add(New ProductSales() With {
			.OrderID = 7,
			.Category = "Confections",
			.Product = "Biscuits",
			.Sales = 25,
			.OrderDate = DateTime.Today.AddMonths(7)
		})
		data.Add(New ProductSales() With {
			.OrderID = 8,
			.Category = "Confections",
			.Product = "Biscuits",
			.Sales = 35,
			.OrderDate = DateTime.Today.AddMonths(7)
		})

		Return data
	End Function
End Class