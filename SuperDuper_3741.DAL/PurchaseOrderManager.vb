Imports System.Data.SqlServerCe
Public Class PurchaseOrderManager
    Inherits DBManager
    ' as stated in "ProductManager " class we use 4 db management method in sql syntaxis
    Public Sub Create(ByVal p As PurchaseOrder)
        Dim conn As SqlCeConnection = MyBase.Connection
        Try
            Dim sql As String = "INSERT INTO po_purchase_orders_3741 (po_date_3741, po_total_3741) VALUES ('{0:yyyy-MM-dd}','{1}')"     'takes items from table purchase And puts them In given idexes
            Dim cmd As SqlCeCommand = New SqlCeCommand(String.Format(sql,
                                                                     p.OrderDate,
                                                                     p.Total), conn)        ' to .NET syntaxis

            conn.Open()     ' connection channel opened
            cmd.ExecuteNonQuery()       ' execute related lybrary

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If conn.State <> ConnectionState.Closed Then        ' exception message
                conn.Close()
            End If
        End Try
    End Sub
    ' this and next 2 method are in the same working logic as above
    Public Sub Update(ByVal p As PurchaseOrder)
        Dim conn As SqlCeConnection = MyBase.Connection
        Try
            Dim sql As String = "UPDATE FROM po_purchase_orders_3741 set po_date_3741 = '{0:yyyy-MM-dd}', po_total_3741 = '{1}', WHERE po_id_3741 = {2}"
            Dim cmd As SqlCeCommand = New SqlCeCommand(String.Format(sql, p.OrderDate, p.Total, p.ID), conn)
            conn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If conn.State <> ConnectionState.Closed Then

            End If
        End Try
    End Sub
    Public Sub Delete(ByVal id As Integer)
        Dim conn As SqlCeConnection = MyBase.Connection
        Try
            Dim sql As String = "DELETE FROM po_purchase_orders_3741 WHERE po_id_3741={0}"
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
    ' the region below the is in the same working logic as in the productManager class 
    Public Function GetById(ByVal id As Integer) As PurchaseOrder
        Dim conn As SqlCeConnection = MyBase.Connection
        Try
            Dim sql As String = "SELECT  po_id_3741, po_date_3741, po_total_3741 FROM po_purchase_orders_3741 WHERE Id={0}"
            Dim cmd As SqlCeCommand = New SqlCeCommand(
                                            String.Format(sql, id), conn)
            conn.Open()
            Dim rdr As SqlCeDataReader = cmd.ExecuteReader
            If rdr.Read Then
                Return GetFromRdr(rdr)
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

    Public Function GetAll() As List(Of PurchaseOrder)
        Dim conn As SqlCeConnection = MyBase.Connection
        Dim result As List(Of PurchaseOrder) = New List(Of PurchaseOrder)
        Try
            Dim sql As String = "SELECT po_id_3741, po_date_3741, po_total_3741 FROM po_purchase_orders_3741"
            Dim cmd As SqlCeCommand = New SqlCeCommand(sql, conn)
            conn.Open()
            Dim rdr As SqlCeDataReader = cmd.ExecuteReader
            While rdr.Read
                result.Add(GetFromRdr(rdr))
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

    ' the impotant point here is that the getFrmRdr frim the ProductManager is absent here 
    ' and getByid and getAllPuchases are setting their class instances in the local mathods

    Private Function GetFromRdr(ByVal rdr As SqlCeDataReader) As PurchaseOrder
        Dim c As PurchaseOrder = New PurchaseOrder
        c.Id = CInt(rdr.GetValue(0))
        c.OrderDate = CDate(rdr.GetValue(1))
        c.Total = CDbl(rdr.GetValue(2))
        Return c
    End Function
End Class
