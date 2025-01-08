Imports SPMSOPCI.ConnectionModule
Public Class SelectionTags
    Private m_KeyColumn1 As String
    Private m_KeyColumn2 As String
    Private m_KeyColumn3 As String
    Private m_KeyColumn4 As String
    Private m_KeyColumn5 As String
    Private m_KeyColumn6 As Integer
    Private _p1 As String
    Private _p2 As String
    Private _p3 As String
    Private _p4 As String
    Private _p5 As String
    Public Sub New(ByVal KeyColumn11 As String, ByVal KeyColumn22 As String, ByVal KeyColumn33 As String, ByVal KeyColumn44 As String, ByVal keyColumn55 As String, ByVal keyColumn66 As String)
        m_KeyColumn1 = KeyColumn11
        m_KeyColumn2 = KeyColumn22
        m_KeyColumn3 = KeyColumn33
        m_KeyColumn4 = KeyColumn44
        m_KeyColumn5 = keyColumn55
    End Sub

    Sub New(p1 As String, p2 As String, p3 As String, p4 As String, p5 As String)
        ' TODO: Complete member initialization 
        m_KeyColumn1 = p1
        m_KeyColumn2 = p2
        m_KeyColumn3 = p3
        m_KeyColumn4 = p4
        m_KeyColumn5 = p5
    End Sub

    Public Property KeyColumn11() As String
        Get
            Return m_KeyColumn1
        End Get
        Set(ByVal value As String)
            m_KeyColumn1 = value
        End Set
    End Property

    Public Property KeyColumn22() As String
        Get
            Return m_KeyColumn2
        End Get
        Set(ByVal value As String)
            m_KeyColumn2 = value
        End Set
    End Property

    Public Property KeyColumn33() As String
        Get
            Return m_KeyColumn3
        End Get
        Set(ByVal value As String)
            m_KeyColumn3 = value
        End Set
    End Property

    Public Property KeyColumn44() As String
        Get
            Return m_KeyColumn4
        End Get
        Set(ByVal value As String)
            m_KeyColumn4 = value
        End Set
    End Property
    Public Property KeyColumn55() As String
        Get
            Return m_KeyColumn5
        End Get
        Set(ByVal value As String)
            m_KeyColumn5 = value
        End Set
    End Property
End Class

