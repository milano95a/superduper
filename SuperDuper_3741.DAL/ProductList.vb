Public Class ProductList

    Public Function GetAllProducts() As List(Of Products)       ' here we get all products from product and return as
        Dim manager As ProductManager = New ProductManager      ' a list to related class methods
        Return manager.GetAll
    End Function

    Public Function Sort(ByVal attribute As ByAttribute) As List(Of Products)       ' used for soring the data
        Select Case attribute                                                       ' it`s buildin sorting method
            Case ByAttribute.Name                                                   ' Here in each case of sorting 
                Dim result As List(Of Products) = GetAllProducts()                  ' returning sorted list based on attribute class
                result.Sort(New ByNameComparer)
                Return result
            Case ByAttribute.Priority                                               'sending to "ByPriorityComparer" which 
                Dim result As List(Of Products) = GetAllProducts()                  'compares by priority, below, and sends back sorted items
                result.Sort(New ByPriorityComparer)

                Return result

        End Select

        Return Nothing
    End Function

    Public Function SortLinq(ByVal attribute As ByAttribute) 'Sorting using LINQ
        Select Case attribute                                   ' it`s another buildin sorting method
            Case ByAttribute.Name                               ' here in each case of sorting 
                Dim result = From a In GetAllProducts()         ' returning sorted list based on attribute class
                             Order By a.Name
                             Select a
                Return result.ToList
            Case ByAttribute.Priority
                Dim result = From a In GetAllProducts()         'e.g. by priority attribute we get "a" 
                             Order By a.Priority                ' from database list of items and order in descending priority
                             Select a                           ' and select final form to send back to sort method
                Return result.ToList

        End Select
        Return Nothing
    End Function

    'Custom Integer Sorting 
    Public Function SortByPriority(ByVal x As List(Of Products)) As List(Of Products)

        Dim modify As Boolean = False
        While modify = False
            modify = True
            For counter As Integer = 0 To x.Count - 2
                If x.Item(counter).Priority > x.Item(counter + 1).Priority Then
                    Dim p As Products = x.Item(counter)
                    x.Item(counter) = x.Item(counter + 1)
                    x.Item(counter + 1) = p
                    modify = False
                End If
            Next
        End While
        Return x
    End Function
    '
    Private Class ByNameComparer        ' below 3 methods-classes are returning to sort mehtod the ready sorted items, based on byAttribute method
        Implements IComparer(Of Products)

        Public Function Compare(ByVal x As Products, ByVal y As Products) As Integer Implements IComparer(Of Products).Compare
            Return String.Compare(x.Name, y.Name)       ' here we get 2 names and compare them accordingly
        End Function
    End Class
    Private Class ByPriorityComparer
        Implements IComparer(Of Products)

        Public Function Compare(ByVal x As Products, ByVal y As Products) As Integer Implements IComparer(Of Products).Compare
            Return String.Compare(x.Priority, y.Priority)
        End Function
    End Class

    'SEARCHING

    Public Function Search(ByVal value As Object, ByVal attribute As ByAttribute) As Products
        Select Case attribute
            Case ByAttribute.Name
                'collection should be sorted for binary search to work
                Dim products As List(Of Products) = Sort(attribute)

                'have to pass an instance of same class
                Dim product As Products = New Products
                product.Name = value
                Dim index As Integer = products.BinarySearch(product, New ByNameComparer())

                'index will contain -1 if not found
                If index < 0 Then
                    Return Nothing
                Else
                    Return products(index)
                End If

        End Select
        Return Nothing
    End Function

    Public Function GetProductsForOrder() As List(Of Products)
        Dim manager As ProductManager = New ProductManager()
        Dim result = From p As Products In manager.GetAll() Where p.Remaining < p.PurchaseLevel Select p
        Return result.ToList
    End Function


End Class
