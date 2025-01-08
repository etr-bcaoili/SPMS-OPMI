Option Explicit On
Imports System.Data.SqlClient
Imports System.IO
Namespace ConnectionModule
    Module ConnectionModule
        'all codes placed in this module should only be codes that have
        'relation to database connection
        Public SPMSConn As New ADODB.Connection
        Public v_SPMSConn2 As New SqlClient.SqlConnection
        Public j_DataReader As SqlDataReader
        Public v_SQLConnect As New SqlClient.SqlConnection

        Public Property SPMSConn2() As SqlClient.SqlConnection
            Get
                Return v_SPMSConn2
            End Get
            Set(ByVal value As SqlClient.SqlConnection)
                v_SPMSConn2 = value
            End Set
        End Property
        Public Property DataReader As SqlDataReader
            Get
                Return j_DataReader
            End Get
            Set(value As SqlDataReader)
                j_DataReader = value
            End Set
        End Property
        Public Property SQLConnect() As SqlClient.SqlConnection
            Get
                Return v_SQLConnect
            End Get
            Set(ByVal value As SqlClient.SqlConnection)
                v_SQLConnect = value
            End Set
        End Property


        Public Function GetConnectionPath() As String
            Dim DecryptedConnection As String = ""
            If ConnectionExists() = True Then
                Dim ObjReader As New IO.StreamReader(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\Connections\DBConn.txt")
                DecryptedConnection = Decrypts(ObjReader.ReadToEnd, 22)
                Return DecryptedConnection
            Else
                Return ""
            End If
        End Function

        Public Function GetSqlconnectionPath() As String
            Dim DecryptedConnection As String = ""
            If SqlConnectionExists() = True Then
                Dim objReader As New IO.StreamReader(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\Connections\SqlConn.txt")
                DecryptedConnection = Decrypts(objReader.ReadToEnd, 22)
            End If
            Return DecryptedConnection
        End Function

        Public Function SqlConnectionExists() As Boolean
            If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\Connections\SqlConn.txt") = True Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function ConnectionExists() As Boolean
            If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\Connections\DBConn.txt") = True Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function OpenConnection() As Boolean
            If SPMSConn.State = 1 Then SPMSConn.Close()
            Dim tmp As String = Replace(GetConnectionPath, ")", "")
            SPMSConn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            ' SPMSConn.Open("Provider=SQLOLEDB.1;Persist Security Info=False;User ID=sa;Initial Catalog=SPMS;Data Source=192.168.0.2")
            SPMSConn.Open(tmp)
            '  SPMSConn.Open("Provider=SQLOLEDB.1;Persist Security Info=False;User ID=sa; Password = ;Initial Catalog=gpispms;Data Source=192.168.0.5")
            If SPMSConn.State = 1 Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Function GetDefaultCompany() As String
            Dim rs As New ADODB.Recordset
            If rs.State = 1 Then rs.Close()
            rs.Open("SELECT TOP 1 COMID From Company Where DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                Return rs.Fields("COMID").Value
            End If
            Return ""
        End Function

        Public Function GetDefaultCompanyName() As String
            Dim rs As New ADODB.Recordset
            If rs.State = 1 Then rs.Close()
            rs.Open("SELECT TOP 1 COMNAME From Company Where DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                Return rs.Fields("COMNAME").Value
            End If
            Return ""
        End Function

        Public Function Connect() As Boolean
            If SPMSConn2.State = ConnectionState.Open Then SPMSConn2.Close()
            Dim tmp As String = Replace(GetSqlconnectionPath, ")", "")
            'tmp = Replace(tmp, "Provider=SQLOLEDB.1;", "Integrated Security = SSPI;")
            SPMSConn2.ConnectionString = tmp
            SPMSConn2.Open()
            If SPMSConn2.State = ConnectionState.Open Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function Disconnect() As Boolean
            If SPMSConn2.State <> ConnectionState.Closed Then SPMSConn2.Close()
            If SPMSConn2.State = ConnectionState.Closed Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Function Connect1() As Boolean
            If SQLConnect.State = ConnectionState.Open Then SQLConnect.Close()
            Dim tmp As String = Replace(GetSqlconnectionPath, ")", "")
            SQLConnect.ConnectionString = tmp
            SQLConnect.Open()
            If SQLConnect.State = ConnectionState.Open Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Function GetRecords(ByVal SQLStatement As String) As DataTable
            Connect1()
            Dim da As SqlDataAdapter ' = New SqlDataAdapter(SQLStatement, Utilities.GetPayrollConnection)
            da = New SqlClient.SqlDataAdapter(SQLStatement, SQLConnect)
            Dim dt As New DataTable
            da.Fill(dt)
            Disconnect()
            Return dt
        End Function
    End Module
End Namespace




