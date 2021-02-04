Imports System

Namespace ASPNETCore30Dashboard.Models
	Public Class ErrorViewModel
		Public Property RequestId() As String

		Public ReadOnly Property ShowRequestId() As Boolean
			Get
				Return Not String.IsNullOrEmpty(RequestId)
			End Get
		End Property
	End Class
End Namespace
