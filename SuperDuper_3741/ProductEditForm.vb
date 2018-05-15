Imports SuperDuper_3741.DAL     ' imports DAL to use its methods 

Public Class ProductEditForm

    Private _mode As FormMode       ' this and next method is setter and getter
    Public Property Mode() As FormMode      ' in this setter- getter method it is of the data type which is defined by enumerator form mode
        Get
            Return _mode        ' returns instance
        End Get
        Set(ByVal value As FormMode)
            _mode = value       ' sets the instance
        End Set
    End Property


    Private _product As Products        ' the same
    Public Property Product() As Products
        Get
            Return _product
        End Get
        Set(ByVal value As Products)
            _product = value
        End Set
    End Property


    Public Sub CreateProduct()      ' here it creates new product
        Mode = FormMode.CreateNew       ' bythe enumerator value of {CreateNew} itsets mode instance 
        Product = New Products          ' new Product object type of Product
        Me.MdiParent = My.Forms.ParentForm      ' dispalys it to the form
        Me.Show()

    End Sub


    Public Sub UpdateProduct(ByVal product As Products)     ' update the db
        Mode = FormMode.Update          ' bythe enumerator value of {CreateNew} itsets mode instance 
        Me.Product = product            ' sets Prodcuts instance in field by argument type object
        InitializeControls()            ' Show in form
        ShowProductInControls()         ' it can also be without Me.
        Me.MdiParent = My.Forms.ParentForm
        Me.Show()

    End Sub


    Private Sub InitializeControls()

    End Sub

    Private Sub ShowProductInControls()     ' sets controls in the form what db has got, top alter details
        tbxName.Text = Product.Name         ' diplay name to change and so on
        nudRemaining.Value = Product.Remaining
        nudPriority.Value = Product.Priority
        nudPurchaseLevel.Value = Product.PurchaseLevel
        nudPrice.Value = Product.Price

    End Sub

    Private Sub GrabUserInput()         ' sets db item in the form what user has input
        Product.Name = tbxName.Text     ' change the name to what user has typed in
        Product.Remaining = nudRemaining.Value
        Product.Priority = nudPriority.Value
        Product.PurchaseLevel = nudPurchaseLevel.Value
        Product.Price = nudPrice.Value
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()     ' close when clicked

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click       ' to save changes
        ' if name textbox empty show error
        If tbxName.Text.Trim.Length = 0 Then
            MsgBox("Please fill in name space")
        Else
            Try ' exception
                GrabUserInput()     ' user input method to be executed

                Dim manager As ProductManager = New ProductManager

                If Mode = FormMode.CreateNew Then       ' case og crateNew FormMode enumerator
                    manager.Create(Product)             ' if CrateNew crate new record else alter existing one
                Else
                    manager.Update(Product)     ' updates
                End If

                My.Forms.ProductListForm.RefreshData()      ' refresh existing data and close the form

                tbxName.Clear()


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ProductEditForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class