Imports System.Data.SqlServerCe


'here in each method we access to DAL,  which is important to us as we get data from there
'here we use 4 main commands to do that
' 1. insert = to create new item
' 2. update to update :D
' 3. delete = to delete
' 4. select = to access the data from db


'e.g. selects table Product, where rows are followed and indexes to accces them are relatively followed

Public Class ProductManager
    Inherits DBManager
    Public Sub Create(ByVal pr As Products)
        Dim conn As SqlCeConnection = MyBase.Connection ' set connection
        Try
            ' here we access to data base and transfer it to .NET language
            Dim sql As String =
                "INSERT INTO [pr_products_3741] " &
                "([pr_name_3741], [pr_remaining_3741], [pr_priority_3741], [pr_purchase_level_3741], [pr_price_3741])" &
                 " VALUES ('{0}', {1}, {2}, {3}, {4})"
            Dim cmd As SqlCeCommand = New SqlCeCommand(
                   String.Format(sql, pr.Name, pr.Remaining, pr.Priority,
                   pr.PurchaseLevel, pr.Price), conn)
            conn.Open() ' open chanel of connection
            cmd.ExecuteNonQuery()   ' execute related libraries
        Catch ex As Exception
            MsgBox(ex.Message)      ' msgbox in case of failure
        Finally
            If conn.State <> ConnectionState.Closed Then    ' if connection state is not closed, closed byforce
                conn.Close()
            End If
        End Try
    End Sub
    'below 2 method Is the same as above
    Public Sub Update(ByVal pr As Products)
        Dim conn As SqlCeConnection = MyBase.Connection
        Try
            Dim sql As String = "UPDATE  [pr_products_3741] set [pr_name_3741] = '{0}', " &
                                "[pr_remaining_3741] = {1}, " &
                                "[pr_priority_3741] = {2}, " &
                                "[pr_purchase_level_3741] = {3}, " &
                                "[pr_price_3741] = {4}, " &
                                "WHERE [pr_id _3741] = {5}"
            Dim cmd As SqlCeCommand = New SqlCeCommand(
                    String.Format(sql, pr.Name, pr.Remaining, pr.Priority,
                    pr.PurchaseLevel, pr.Price), conn)
            conn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If conn.State <> ConnectionState.Closed Then
                conn.Close()
            End If
        End Try
    End Sub
    Public Sub Delete(ByVal id As Integer)
        Dim conn As SqlCeConnection = MyBase.Connection
        Try
            Dim sql As String = "DELETE FROM [pr_products_3741] WHERE [pr_id_3741]={0}"
            Dim cmd As SqlCeCommand = New SqlCeCommand(
                                            String.Format(sql, id), conn)
            conn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If conn.State <> ConnectionState.Closed Then
                conn.Close()
            End If
        End Try
    End Sub
    ' accesses the db items by id and return the value outside the class
    Public Function GetById(ByVal id As Integer) As Products
        Dim conn As SqlCeConnection = MyBase.Connection
        Try
            Dim sql As String = "SELECT [pr_id_3741], [pr_name_3741], [pr_remaining_3741], [pr_priority_3741], [pr_purchase_level_3741], [pr_price_3741]" &
            "FROM [pr_products_3741] WHERE [pr_id_3741] = {0}"
            Dim cmd As SqlCeCommand = New SqlCeCommand(
                                            String.Format(sql, id), conn)
            conn.Open()
            Dim rdr As SqlCeDataReader = cmd.ExecuteReader
            If rdr.Read Then
                Dim a As Products = GetFromRdr(rdr)     ' here we tell to perform setter in getFromRdr() method
                Return a
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If conn.State <> ConnectionState.Closed Then
                conn.Close()
            End If
        End Try
        Return Nothing
    End Function
    ' gets all the items existing in db and sends it for further data manipulation
    Public Function GetAll() As List(Of Products)
        Dim conn As SqlCeConnection = MyBase.Connection
        Dim result As List(Of Products) = New List(Of Products)
        Try
            Dim sql As String = "SELECT [pr_id_3741], [pr_name_3741], [pr_remaining_3741], [pr_priority_3741], [pr_purchase_level_3741], [pr_price_3741]" &
            "FROM [pr_products_3741]"
            Dim cmd As SqlCeCommand = New SqlCeCommand(sql, conn)
            conn.Open()
            Dim rdr As SqlCeDataReader = cmd.ExecuteReader
            While rdr.Read
                result.Add(GetFromRdr(rdr))     ' the same setter method below
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If conn.State <> ConnectionState.Closed Then
                conn.Close()
            End If
        End Try
        Return result
    End Function

    Private Function GetFromRdr(ByVal rdr As SqlCeDataReader) As Products   ' this is famous setter method which returns product data type
        Dim pr As Products = New Products                                   ' which accepts conncetion class istance of sql reader
        pr.Id = CInt(rdr.GetValue(0))                                       ' takes each instance of class "a "and sets its value
        pr.Name = CStr(rdr.GetValue(1))                                     ' with the items from database
        pr.Remaining = CInt(rdr.GetValue(2))
        pr.Priority = CInt(rdr.GetValue(3))
        pr.PurchaseLevel = CInt(rdr.GetValue(4))
        pr.Price = CDbl(rdr.GetValue(5))
        Return pr                                                           ' of course returns them
    End Function
End Class
