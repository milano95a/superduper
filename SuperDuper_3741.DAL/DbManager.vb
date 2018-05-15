Imports System.Data.SqlServerCe

Public Class DBManager
    Protected ReadOnly Property Connection() As SqlCeConnection   ' connects to the sql and returs the connection to the ones which inherit this class: PurchaseManager and ProductOrderManager
        Get
            Return New SqlCeConnection(My.Settings.ConnectionString)
        End Get
    End Property
End Class
