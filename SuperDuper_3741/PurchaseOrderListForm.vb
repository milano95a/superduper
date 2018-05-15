Imports SuperDuper_3741.DAL

Public Class PurchaseOrderListForm
    Private Sub PurchaseOrderListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.ParentForm
        RefreshData()
    End Sub

    Public Sub RefreshData()
        dgv.DataMember = ""
        dgv.DataSource = Nothing
        Dim purchaseorderList As PurchaseOrderList = New PurchaseOrderList
        dgv.DataSource = purchaseorderList.GetAllPurchaseOrders
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim form As PurchaseOrderEditForm = New PurchaseOrderEditForm
        form.CreatePurchaseOrder()
    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgv.SelectedRows.Count = 0 Then
            MessageBox.Show("Please, select product", "Error")
        Else
            Dim purchaseorder As PurchaseOrder = CType(dgv.SelectedRows.Item(0).DataBoundItem, PurchaseOrder)
            Dim manager As PurchaseOrderManager = New PurchaseOrderManager
            manager.Delete(purchaseorder.Id)
            RefreshData()
        End If
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
    End Sub
End Class