Public Class ForDeletes
    Private m_ID As Integer = -1

    Public Property ID() As Integer
        Get
            Return m_ID
        End Get
        Set(ByVal value As Integer)
            m_ID = value
        End Set
    End Property
End Class

Public Class ForDeletesCollection
    Inherits CollectionBase

    Default Public ReadOnly Property Item(ByVal Index As Integer) As ForDeletes
        Get
            Return List(Index)
        End Get
    End Property
    Public Function Add() As ForDeletes
        Dim obj As New ForDeletes
        List.Add(obj)
        Return obj
    End Function
    Public Sub Add(ByVal obj As ForDeletes)
        List.Add(obj)
    End Sub
End Class
