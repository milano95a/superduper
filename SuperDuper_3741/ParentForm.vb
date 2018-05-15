
Public Class ParentForm
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End     ' closes when clicked
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim about As AboutForm = New AboutForm
        about.Show()        ' show about form
        about.MdiParent = Me

    End Sub

    Private Sub AllProductsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllProductsToolStripMenuItem.Click
        My.Forms.ProductListForm.Show()     ' display this form of view for prodducts all prodducts

    End Sub

    Private Sub AllPurchaseOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllPurchaseOrdersToolStripMenuItem.Click
        My.Forms.PurchaseOrderListForm.Show()       ' display this form of view for Purchase all purchasess

    End Sub

    Private Sub NewProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewProductToolStripMenuItem.Click
        Dim form As ProductEditForm = New ProductEditForm
        form.CreateProduct()            ' display this form of Create for product

    End Sub

    Private Sub NewPurchaseOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewPurchaseOrderToolStripMenuItem.Click
        Dim form As PurchaseOrderEditForm = New PurchaseOrderEditForm
        form.CreatePurchaseOrder()          ' display this form of crate for purchase
    End Sub

    Private Sub ParentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class