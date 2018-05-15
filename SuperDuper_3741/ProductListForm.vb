Imports SuperDuper_3741.DAL

Public Class ProductListForm
    Private Sub ProductListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load      'here refresh dgv on load
        MdiParent = My.Forms.ParentForm     'link to parent form
        RefreshData()

    End Sub

    Public Sub RefreshData()        ' refresh method
        DataGridView.DataMember = ""        ' datagrid view is empty
        DataGridView.DataSource = Nothing
        Dim productList As ProductList = New ProductList        ' new productlis
        DataGridView.DataSource = productList.GetAllProducts        ' gives dgv the list of products from variable before
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles ButtonRefresh.Click
        RefreshData()

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        Dim atribute As ByAttribute

        Dim products As ProductList = New ProductList
        Dim searchResult As Products = products.Search(TextBoxSearch.Text, atribute)
        If searchResult Is Nothing Then
            MsgBox("No such product is found")
        Else
            DataGridView.DataMember = ""
            DataGridView.DataSource = Nothing
            Dim result As List(Of Products) = New List(Of Products)
            result.Add(searchResult)
            DataGridView.DataSource = result
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        Dim form As ProductEditForm = New ProductEditForm       ' for adding new item we call method CreateForm

        form.CreateProduct()

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles ButtonDelete.Click
        If DataGridView.SelectedRows.Count = 0 Then
            MsgBox("Please choose the product listed")

        Else
            If MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Dim products As Products = CType(DataGridView.SelectedRows.Item(0).DataBoundItem, Products)
                Dim manager As ProductManager = New ProductManager
                manager.Delete(products.Id)
                RefreshData()

            End If


        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles ButtonUpdate.Click
        If DataGridView.SelectedRows.Count = 0 Then
            MsgBox("Please choose the product listed")      ' if no item is selected msg
        Else
            Dim products As Products = CType(DataGridView.SelectedRows.Item(0).DataBoundItem, Products)     ' else updates db my update method
            Dim form As ProductEditForm = New ProductEditForm
            form.UpdateProduct(products)

        End If
    End Sub

    Public Sub dgvAllProducts_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView.CellContentClick

    End Sub

    Private Sub ButtonSort_Click(sender As Object, e As EventArgs) Handles ButtonSort.Click

        Dim csort As ProductList = New ProductList
        Dim psort As List(Of Products) = New List(Of Products)


        If ComboBoxSort.SelectedIndex < 0 Then
            MsgBox("Select an attribute to sort by")
        Else
            Dim attribute As ByAttribute
            Select Case ComboBoxSort.SelectedIndex
                Case 0
                    attribute = ByAttribute.Name
                    Dim products As ProductList = New ProductList
                    DataGridView.DataMember = ""
                    DataGridView.DataSource = Nothing
                    DataGridView.DataSource = products.Sort(attribute)

                Case 1
                    psort = csort.GetAllProducts
                    psort = csort.SortByPriority(psort)
                    DataGridView.DataMember = ""
                    DataGridView.DataSource = Nothing
                    DataGridView.DataSource = psort
                    
            End Select

        End If
    End Sub

End Class