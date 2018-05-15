Public Class PurchaseOrder              'the same goes here with explanation of "Product" class- no nudity to reinvent a circle
    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property


    Private _OrderDate As DateTime
    Public Property OrderDate() As DateTime
        Get
            Return _OrderDate
        End Get
        Set(ByVal value As DateTime)
            _OrderDate = value
        End Set
    End Property


    Private _Total As Double
    Public Property Total As Double
        Get
            Return _Total
        End Get
        Set(ByVal value As Double)
            If value < 0 Then
                Throw New Exception("Saved")
            End If
            _Total = value
        End Set
    End Property
    Public Sub New()

    End Sub

    Public Sub New(ByVal d As DateTime,
                    ByVal t As Double)
        _OrderDate = d
        _Total = t
    End Sub
    Public Overrides Function ToString() As String      ' here it overrides the String method of the class which it is returnin and adds the 
        '''''' object Purchase date which is also accessed from db/DAL
        Return _OrderDate
        Return _Total
    End Function

End Class
