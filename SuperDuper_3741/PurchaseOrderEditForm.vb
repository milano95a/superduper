Imports SuperDuper_3741.DAL

Public Class PurchaseOrderEditForm
    Dim total As Integer
    Private Sub PurchaseOrderEditForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.ParentForm
        'populate data grid view
        RefreshData()
    End Sub

    Private _mode As FormMode
    Public Property Mode() As FormMode
        Get
            Return _mode
        End Get
        Set(ByVal value As FormMode)
            _mode = value
        End Set
    End Property

    Private _purchase_Order As PurchaseOrder
    Public Property Purchase_Order() As PurchaseOrder
        Get
            Return _purchase_Order
        End Get
        Set(ByVal value As PurchaseOrder)
            _purchase_Order = value
        End Set
    End Property

    Public Sub CreatePurchaseOrder()
        Mode = FormMode.CreateNew
        Purchase_Order = New PurchaseOrder
        Me.MdiParent = My.Forms.ParentForm
        Me.Show()

    End Sub

    Private Sub GrabUserInput()
        Purchase_Order.Total = total
        Purchase_Order.OrderDate = DateTime.Now

    End Sub



    'save button. It saves all porchase order informations to database.
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            For i As Integer = 0 To dgv.RowCount - 1
                total += dgv.Rows(i).Cells(4).Value * dgv.Rows(i).Cells(3).Value
                dgv.Rows(i).Cells(1).Value += dgv.Rows(i).Cells(4).Value
            Next
            GrabUserInput()

            For i As Integer = 0 To dgv.Rows.Count - 1
                Dim product As Products = dgv.Rows(i).DataBoundItem
                product.Remaining = dgv.Rows(i).Cells(1).Value
                Dim prmanager As ProductManager = New ProductManager
                prmanager.Update(product)

            Next

            Dim manager As PurchaseOrderManager = New PurchaseOrderManager
            If Mode = FormMode.CreateNew Then
                manager.Create(Purchase_Order)
            Else
                manager.Update(Purchase_Order)
            End If
            My.Forms.PurchaseOrderListForm.RefreshData()
            Close()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub


    Public Sub RefreshData()
        dgv.DataMember = ""
        dgv.DataSource = Nothing
        Dim productList As ProductList = New ProductList


        If productList.GetProductsForOrder.Count >= 5 Then
            MsgBox(" you can not order more than 5 products")
            dgv.DataSource = productList.GetProductsForOrder
        Else
            dgv.DataSource = productList.GetProductsForOrder
        End If

    End Sub
End Class