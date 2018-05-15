Public Class Products
    Private _Id As Integer ' instance variable inside the class 
    Public Property Id() As Integer  ' this method gets and sets,
        Get                          ' which sets the value instance variable from outside the class
            Return _Id               'and returns this variable outside the class
        End Get                      ' The same principle goes for below methods
        Set(ByVal value As Integer)
            _Id = value
        End Set
    End Property


    Private _Name As String         ' instance variable inside the class 
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property

    Private _Remaining As Integer   ' instance variable inside the class 
    Public Property Remaining() As Integer
        Get
            Return _Remaining
        End Get
        Set(ByVal value As Integer)
            _Remaining = value
        End Set
    End Property

    Private _Priority As Integer    ' instance variable inside the class 
    Public Property Priority() As Integer
        Get
            Return _Priority
        End Get
        Set(ByVal value As Integer)
            _Priority = value
        End Set
    End Property

    Private _PurchaseLevel As Integer   ' instance variable inside the class 
    Public Property PurchaseLevel() As Integer
        Get
            Return _PurchaseLevel
        End Get
        Set(ByVal value As Integer)
            _PurchaseLevel = value
        End Set
    End Property

    Private _Price As Double        ' instance variable inside the class 
    Public Property Price() As Double
        Get
            Return _Price
        End Get
        Set(ByVal value As Double)
            _Price = value
        End Set
    End Property

    Public Sub New()            'this method is constructor method used instead of static methods

    End Sub

    Public Sub New(ByVal Name As String,        'this method is constructor method
                   ByVal Remaining As Integer,  'this method is constructor method 
                   ByVal Priority As Integer,
                   ByVal PurchaseLevel As Integer,
                   ByVal Price As Double)
        _Name = Name                            ' here it is like setter abovemetioned
        _Remaining = Remaining
        _Priority = Priority
        _PurchaseLevel = PurchaseLevel
        _Price = Price
    End Sub

    Private _toOrder As Integer
    Public Property ToOrder() As Integer
        Get
            _toOrder = (_PurchaseLevel - _Remaining) * 2
            Return _toOrder
        End Get
        Set(ByVal value As Integer)
            _toOrder = value
        End Set
    End Property
End Class
