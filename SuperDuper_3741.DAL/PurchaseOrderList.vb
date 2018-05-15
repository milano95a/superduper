Public Class PurchaseOrderList
    Public Function GetAllPurchaseOrders() As List(Of PurchaseOrder)    ' gets the items from PurchaseOrdert class and returns them as a list
        Dim manager As PurchaseOrderManager = New PurchaseOrderManager  ' to outside the class
        Return manager.GetAll
    End Function
End Class
