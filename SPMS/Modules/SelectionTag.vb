Imports SPMSOPCI.ConnectionModule
Public Class SelectionTag
    Private m_KeyColumn1 As String
    Private m_KeyColumn2 As String
    Private m_KeyColumn3 As String
    Private m_KeyColumn4 As String
    Private m_KeyColumn5 As String
    Private m_KeyColumn6 As Integer
    Private m_ConnectionID As ADODB.Connection = SPMSConn

    Public Property ConnectionID() As ADODB.Connection
        Get
            Return m_ConnectionID
        End Get
        Set(ByVal value As ADODB.Connection)
            m_ConnectionID = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal KeyColumn1 As String, ByVal KeyColumn2 As String, ByVal KeyColumn3 As String, ByVal KeyColumn4 As String, ByVal keyColumn5 As String)
        m_KeyColumn1 = KeyColumn1
        m_KeyColumn2 = KeyColumn2
        m_KeyColumn3 = KeyColumn3
        m_KeyColumn4 = KeyColumn4
        m_KeyColumn5 = keyColumn5
        m_KeyColumn6 = KeyColumn6
    End Sub

    Public Property KeyColumn1() As String
        Get
            Return m_KeyColumn1
        End Get
        Set(ByVal value As String)
            m_KeyColumn1 = value
        End Set
    End Property

    Public Property KeyColumn2() As String
        Get
            Return m_KeyColumn2
        End Get
        Set(ByVal value As String)
            m_KeyColumn2 = value
        End Set
    End Property

    Public Property KeyColumn3() As String
        Get
            Return m_KeyColumn3
        End Get
        Set(ByVal value As String)
            m_KeyColumn3 = value
        End Set
    End Property

    Public Property KeyColumn4() As String
        Get
            Return m_KeyColumn4
        End Get
        Set(ByVal value As String)
            m_KeyColumn4 = value
        End Set
    End Property
    Public Property KeyColumn5() As String
        Get
            Return m_KeyColumn5
        End Get
        Set(ByVal value As String)
            m_KeyColumn5 = value
        End Set
    End Property
    Public Property KeyColumn6() As Integer
        Get
            Return m_KeyColumn6
        End Get
        Set(ByVal value As Integer)
            m_KeyColumn6 = value
        End Set
    End Property
End Class
