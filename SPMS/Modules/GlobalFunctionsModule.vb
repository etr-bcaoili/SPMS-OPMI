Imports SPMSOPCI.ConnectionModule
Imports System.IO
Imports System.Net.Dns
Imports System.Data.SqlClient
Module GlobalFunctionsModule

    Private b_Username As String = ""

    Public Property User() As String
        Get
            Return b_Username
        End Get
        Set(ByVal value As String)
            b_Username = value
        End Set
    End Property

    Public Sub ShowInformation(ByVal Message As String, ByVal MessageTitle As String)
        MsgBox(Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MessageTitle)
    End Sub

    Public Sub ShowExclamation(ByVal Message As String, ByVal MessageTitle As String)
        MsgBox(Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MessageTitle)
    End Sub

    Public Sub ShowSystemModal(ByVal Message As String, ByVal MessageTitle As String)
        MsgBox(Message, MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, MessageTitle)
    End Sub

    Public Function ShowQuestion(ByVal Message As String, ByVal MessageTitle As String) As MsgBoxResult
        Return MsgBox(Message, MsgBoxStyle.YesNo + MsgBoxStyle.Question, MessageTitle)
    End Function

    Public Function ErrorExist(ByVal ErrorNumber As Integer) As Boolean
        Dim rs As New ADODB.Recordset
        rs.Open("SELECT * FROM ErrorListing WHERE ERRNUM = " & ErrorNumber, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If

    End Function
   
    Public Sub ApplyGridTheme(ByVal Grid As DataGridView)

        'Dim headerStyle As New DataGridViewCellStyle
        'Dim alternatingRowStyle As New DataGridViewCellStyle
        'Dim defaultCellStyle As New DataGridViewCellStyle
        'Dim rowHeaderStyle As New DataGridViewCellStyle

        'alternatingRowStyle.BackColor = Color.AliceBlue
        'alternatingRowStyle.ForeColor = Color.Black
        'alternatingRowStyle.SelectionBackColor = Color.LightSteelBlue
        'alternatingRowStyle.SelectionForeColor = Color.Black
        'Grid.AlternatingRowsDefaultCellStyle = alternatingRowStyle


        'headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'headerStyle.BackColor = Color.SteelBlue
        'headerStyle.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
        'headerStyle.ForeColor = Color.White
        'headerStyle.SelectionBackColor = Color.LemonChiffon
        'headerStyle.SelectionForeColor = Color.Black
        'headerStyle.WrapMode = DataGridViewTriState.True

        'Grid.BackgroundColor = System.Drawing.Color.Azure
        'Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        'Grid.ColumnHeadersDefaultCellStyle = headerStyle
        'Grid.BackgroundColor = Color.Azure
        'Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize

        'defaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        'defaultCellStyle.BackColor = System.Drawing.Color.White
        'defaultCellStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'defaultCellStyle.ForeColor = System.Drawing.Color.Black
        'defaultCellStyle.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        'defaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        'defaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        'Grid.DefaultCellStyle = defaultCellStyle
        'Grid.EnableHeadersVisualStyles = False
        'Grid.GridColor = System.Drawing.Color.SteelBlue

        'Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        'rowHeaderStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        'rowHeaderStyle.BackColor = System.Drawing.Color.SteelBlue
        'rowHeaderStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'rowHeaderStyle.ForeColor = System.Drawing.Color.White
        'rowHeaderStyle.SelectionBackColor = System.Drawing.Color.LemonChiffon
        'rowHeaderStyle.SelectionForeColor = System.Drawing.Color.Black
        'rowHeaderStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        'Grid.RowHeadersDefaultCellStyle = rowHeaderStyle
        'Grid.RowTemplate.Height = 20


        Dim headerStyle As New DataGridViewCellStyle
        Dim alternatingRowStyle As New DataGridViewCellStyle
        Dim defaultCellStyle As New DataGridViewCellStyle
        Dim rowHeaderStyle As New DataGridViewCellStyle

        alternatingRowStyle.BackColor = Color.FromArgb(228, 236, 247)
        alternatingRowStyle.ForeColor = Color.Black
        alternatingRowStyle.SelectionBackColor = Color.LightSteelBlue
        alternatingRowStyle.SelectionForeColor = Color.Black
        Grid.AlternatingRowsDefaultCellStyle = alternatingRowStyle


        headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'headerStyle.BackColor = Color.SteelBlue
        headerStyle.BackColor = Color.FromArgb(33, 99, 157)
        headerStyle.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
        headerStyle.ForeColor = Color.White
        headerStyle.SelectionBackColor = Color.LemonChiffon
        headerStyle.SelectionForeColor = Color.Black
        headerStyle.WrapMode = DataGridViewTriState.True

        Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single
        Grid.ColumnHeadersDefaultCellStyle = headerStyle
        Grid.BackgroundColor = Color.White
        Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize

        defaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        defaultCellStyle.BackColor = System.Drawing.Color.White
        defaultCellStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        defaultCellStyle.ForeColor = System.Drawing.Color.Black
        defaultCellStyle.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        'defaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(214, 232, 254)
        defaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        defaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Grid.DefaultCellStyle = defaultCellStyle
        Grid.EnableHeadersVisualStyles = False
        Grid.GridColor = System.Drawing.Color.LightSteelBlue

        Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        rowHeaderStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        rowHeaderStyle.BackColor = System.Drawing.Color.SteelBlue
        rowHeaderStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        rowHeaderStyle.ForeColor = System.Drawing.Color.White
        rowHeaderStyle.SelectionBackColor = System.Drawing.Color.LemonChiffon
        rowHeaderStyle.SelectionForeColor = System.Drawing.Color.Black
        rowHeaderStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Grid.RowHeadersDefaultCellStyle = rowHeaderStyle
        Grid.RowTemplate.Height = 18

        Grid.AllowUserToResizeRows = False
        Grid.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None
        Grid.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None
        Grid.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None
        Grid.AdvancedColumnHeadersBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None
        Grid.AdvancedColumnHeadersBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None

        AddHandler Grid.KeyDown, AddressOf HandleGridKeyDown
        AddHandler Grid.DataError, AddressOf HandleDataError
        'AddHandler Grid.CellEndEdit, AddressOf HandleGridEndEdit
        'AddHandler Grid.CellValidating, AddressOf HandleGridCellValidating


    End Sub

    Private Sub HandleGridKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Dim dg As DataGridView = sender
        If dg Is Nothing Then Exit Sub
        If dg.CurrentRow Is Nothing Then Exit Sub
        If dg.CurrentRow.Index = -1 Then Exit Sub
        If e.Control Then
            Dim row As DataGridViewRow = dg.Rows(dg.CurrentRow.Index)
            Select Case e.KeyCode
                Case Keys.C
                    If dg.SelectedCells.Count > 0 Then
                        Clipboard.SetData(System.Windows.Forms.DataFormats.Text, dg.SelectedCells)
                    Else
                        Clipboard.SetData(System.Windows.Forms.DataFormats.Text, dg.CurrentCell.Value)
                    End If
                Case Keys.V
                    If Not Clipboard.GetData(System.Windows.Forms.DataFormats.Text) Is Nothing Then
                        ' selected cells must only of the same column
                        Dim m_SelectedColumn As Integer = -1
                        For j As Integer = 0 To dg.SelectedCells.Count - 1
                            If j = 0 Then
                                m_SelectedColumn = dg.SelectedCells(j).ColumnIndex
                            Else
                                If dg.SelectedCells(j).ColumnIndex <> m_SelectedColumn Then
                                    ShowExclamation("Cannot paste into cells of different columns", "Paste")
                                    Exit Sub
                                End If
                            End If
                        Next

                        If dg.SelectedCells.Count > 0 Then
                            Dim m_SelectedCells As DataGridViewSelectedCellCollection = dg.SelectedCells()
                            For j As Integer = 0 To m_SelectedCells.Count - 1
                                Dim cell As DataGridViewCell = m_SelectedCells(j)
                                cell.Value = Clipboard.GetData(System.Windows.Forms.DataFormats.Text)
                                If Not cell.ReadOnly Then
                                    dg.BeginEdit(True)
                                    dg.CurrentCell = cell
                                    dg.EndEdit()
                                End If
                            Next
                        Else
                            If Not dg.CurrentCell Is Nothing Then
                                If Not dg.CurrentCell.ReadOnly Then
                                    dg.BeginEdit(True)
                                    dg.CurrentCell.Value = Clipboard.GetData(System.Windows.Forms.DataFormats.Text)
                                    dg.EndEdit()
                                Else
                                    ShowInformation("Cell is readonly", "Read Only")
                                End If
                            End If
                        End If
                    End If

                Case Keys.X
                    If Not dg.CurrentCell Is Nothing Then
                        If Not dg.CurrentCell.ReadOnly Then
                            Clipboard.SetData(System.Windows.Forms.DataFormats.Text, dg.CurrentCell.Value)
                            dg.CurrentCell.Value = String.Empty
                        Else
                            ShowInformation("Cell is readonly", "Read Only")
                        End If
                    End If

            End Select
        End If
    End Sub

    Private Sub HandleDataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs)
        e.Cancel = True
    End Sub

    Public Function HasReferenceRecords(ByVal TableName As String, ByVal ValuetoFind As String) As Boolean
        Dim rs As New ADODB.Recordset
        Dim rsResult As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM REFERENCETABLE WHERE TABLENAME = '" & TableName & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                rsResult = New ADODB.Recordset
                Dim strSQL As String = ""
                strSQL = "SELECT * FROM " & rs.Fields("LINKTABLE").Value
                strSQL = strSQL & " WHERE " & rs.Fields("LINKFIELD").Value
                strSQL = strSQL & " = '" & ValuetoFind & "' "
                rsResult.Open(strSQL, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                If rsResult.RecordCount > 0 Then
                    Return True
                Else
                    rs.MoveNext()
                End If
            Next
        Else
            Return False
        End If

    End Function
    Public Function HandleSingleQuoteInSql(ByVal StringToRefine As String) As String
        Return Replace(StringToRefine, "'", "''")
    End Function
    Public Function ShowSearchDialog(ByVal Columns As String, ByVal Tablename As String, Optional ByVal FormName As String = "Search") As SelectionTag
        Return ShowSearchDialog(Columns, Tablename, SPMSConn, FormName)
    End Function

    Public Function ShowSearchDialog(ByVal Columns As String, ByVal Tablename As String, ByVal ConnectionID As ADODB.Connection, Optional ByVal FormName As String = "Search") As SelectionTag
        Try
            Dim m_Search As New SearchDialog1
            If Columns = "" Then
                Throw New Exception("You must supply the columns of the table")
            ElseIf Tablename = "" Then
                Throw New Exception("You must supply the name of the table")
            Else
                m_Search.FormName = FormName
                m_Search.TableColumns = Columns
                m_Search.TableName = Tablename
                m_Search.ConnectionID = ConnectionID
                If m_Search.ShowDialog = DialogResult.OK Then
                    Dim m_Tag As New SelectionTag(m_Search.Keycolumn, m_Search.Keycolumn1, m_Search.Keycolumn2, m_Search.Keycolumn3, m_Search.KeyColumn4)
                    Return m_Tag
                Else
                    Return Nothing
                End If
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function Encrypts(ByVal sStr As String, ByVal skey As String) As String

        Dim j As Integer = 0
        Dim mStr As String = ""
        j = 1
        For i As Integer = 1 To Len(sStr)
            mStr = mStr & Chr((Asc(Mid(sStr, i, 1)) + Asc(Mid(skey, j, 1))) - 50)
            j = j + 1
            If j = Len(skey) Then j = 1
        Next
        Encrypts = mStr
    End Function

    Public Function Decrypts(ByVal sStr As String, ByVal skey As String) As String

        Dim j As Integer = 0
        Dim mStr As String = ""
        j = 1
        For i As Integer = 1 To Len(Trim(sStr))
            mStr = mStr & Chr((Asc(Mid(sStr, i, 1)) + 50) - Asc(Mid(skey, j, 1)))
            'mStr = mStr & Chr((Asc(Mid(skey, j, 1)) - Asc(Mid(sStr, i, 1))) + 50)
            j = j + 1
            If j = Len(skey) Then j = 1
        Next
        Decrypts = mStr
    End Function

    Public Function GetTextFileContent(ByVal Directory As String) As String
        Dim Content As String = "'"
        Dim ObjReader As New IO.StreamReader(Directory)
        Content = ObjReader.ReadToEnd

        Return Content
    End Function
    Public Function GetPcIPAddress() As String
        Dim a As System.Net.IPHostEntry = GetHostEntry(GetHostName)

        Return a.AddressList(0).ToString
    End Function
    Public Sub BackupDatabase(ByVal LocationPath As String)

        SPMSConn.Execute("BACKUP DATABASE " & SPMSConn.DefaultDatabase & " TO DISK ='" & LocationPath & "\" & SPMSConn.DefaultDatabase & Now.ToString("mmddyyyy") & Now.ToString("hhmmss") & "' ")
    End Sub
    Public Function GetbackupLocationPath() As String
        Return System.AppDomain.CurrentDomain.BaseDirectory & "Resources\BackupDB\"

    End Function
    Public Function GetSplittedText(ByVal Text As String, ByVal Numbercount As Integer, ByVal Delimeter As String) As String
        Return Split(Text, Delimeter)(Numbercount)
    End Function
    Public Sub CreateBackUpDatabaseRecord(ByVal BackupLocation As String)
        Dim StrSql As String = ""
        StrSql = StrSql & "INSERT INTO DATABASEBACKUPHISTORY "
        StrSql = StrSql & "SELECT '" & SPMSConn.DefaultDatabase & "', "
        StrSql = StrSql & "'" & Today.ToShortDateString & "', "
        StrSql = StrSql & "'SystemAutoBackup', "
        StrSql = StrSql & "'" & BackupLocation & "', "
        StrSql = StrSql & "'" & Today.ToShortDateString & "', "
        StrSql = StrSql & "'" & Today.ToShortDateString & "'"

        SPMSConn.Execute(StrSql)
    End Sub

    Public Function AutoBackUpExist() As Boolean
        Dim rs As New ADODB.Recordset
        rs.Open("SELECT * FROM DATABASEBACKUPHISTORY WHERE UPDATEDATE = '" & Today.ToShortDateString & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetSourceIP() As String
        Dim myip As String = ""
        myip = GetSplittedText(GetSqlconnectionPath(), 0, ";")
        Return GetSplittedText(myip, 1, "=")
    End Function

    Public Function GetSourceUserID() As String
        Dim MyID As String = ""
        MyID = GetSplittedText(GetSqlconnectionPath, 2, ";")
        MyID = GetSplittedText(MyID, 1, "=")
        Return MyID
    End Function

    Public Function GetSourcePassword() As String
        Dim MyPassword As String = ""
        MyPassword = GetSplittedText(GetSqlconnectionPath, 3, ";")
        MyPassword = GetSplittedText(MyPassword, 1, "=")
        Return MyPassword
    End Function

    Public Function GetSourceDatabaseName() As String
        Dim MyDatabase As String = ""
        MyDatabase = GetSplittedText(GetSqlconnectionPath, 1, ";")
        MyDatabase = GetSplittedText(MyDatabase, 1, "=")
        Return MyDatabase
    End Function

    Public Function RsModules(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If
        rs.Open("select * from projectsubmodules where dltflg = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return rs
    End Function



    Public Function RsUsers(Optional ByVal filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If filter <> "" Then
            filter = " AND " & filter
        End If
        rs.Open("SELECT * FROM USERACCESS WHERE DLTFLG =0 " & filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return rs
    End Function

    Public Sub SetAccountforUse(ByVal UserName As String)
        SPMSConn.Execute("UPDATE USERACCESS SET ISACTIVE = 1 WHERE DLTFLG = 0 AND USERNAME = '" & UserName & "' ")
        User = UserName
    End Sub

    Public Sub LogOutAccount(ByVal Username As String)
        SPMSConn.Execute("UPDATE USERACCESS SET ISACTIVE = 0 WHERE DLTFLG = 0 AND USERNAME = '" & Username & "' ")
    End Sub


    Public Function ConvertImageFiletoBytes(ByVal ImageFilePath As String) As Byte()
        Dim _tempByte() As Byte = Nothing
        If String.IsNullOrEmpty(ImageFilePath) = True Then
            Throw New ArgumentNullException("Image File Name Cannot be Null or Empty", "ImageFilePath")
            Return Nothing
        End If
        Try
            Dim _fileInfo As New IO.FileInfo(ImageFilePath)
            Dim _NumBytes As Long = _fileInfo.Length
            Dim _FStream As New IO.FileStream(ImageFilePath, IO.FileMode.Open, IO.FileAccess.Read)
            Dim _BinaryReader As New IO.BinaryReader(_FStream)
            _tempByte = _BinaryReader.ReadBytes(Convert.ToInt32(_NumBytes))
            _fileInfo = Nothing
            _NumBytes = 0
            _FStream.Close()
            _FStream.Dispose()
            _BinaryReader.Close()
            Return _tempByte
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ConvertBytesToImageFile(ByVal ImageData As Byte(), ByVal FilePath As String) As Boolean
        If IsNothing(ImageData) = True Then
            Return False
            'Throw New ArgumentNullException("Image Binary Data Cannot be Null or Empty", "ImageData")
        End If
        Try
            Dim fs As IO.FileStream = New IO.FileStream(FilePath, IO.FileMode.OpenOrCreate, IO.FileAccess.Write)
            Dim bw As IO.BinaryWriter = New IO.BinaryWriter(fs)
            bw.Write(ImageData)
            bw.Flush()
            bw.Close()
            fs.Close()
            bw = Nothing
            fs.Dispose()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ReturnExePath() As String
        Return System.AppDomain.CurrentDomain.BaseDirectory
    End Function

    Public Sub DeleteObject(ByVal fileDirectory As String)
        If fileDirectory = "" Then
        Else
            File.Delete(fileDirectory)
        End If
    End Sub

    Public Function GetRecords(ByVal SQLStatement As String, Optional ByVal TableName As String = "Table1") As DataTable
        Connect()
        Dim sqlCommand As New SqlCommand(SQLStatement, SPMSConn2)
        sqlCommand.CommandTimeout = 0
        sqlCommand.CommandType = CommandType.Text

        Dim da As New SqlDataAdapter(sqlCommand)
        Dim dt As New DataTable
        da.Fill(dt)
        Disconnect()
        dt.TableName = TableName
        Return dt
    End Function

    Public Function ExecuteCommand(ByVal SQLCommand As String) As Object
        Connect()
        Dim m_Return As Object = Nothing
        m_Return = New SqlCommand(SQLCommand, SPMSConn2).ExecuteScalar
        Return m_Return
    End Function

    Public Function GetServerDate() As Date
        Connect()
        Dim m_Return As Object = Nothing
        m_Return = New SqlCommand("SELECT GETDATE()", SPMSConn2).ExecuteScalar
        Return m_Return
    End Function
    Public Function GetCompanyName() As String
        Connect()
        Dim m_return As Object = Nothing
        m_return = New SqlCommand("Select Top 1 ComName FROM Company Order By CompanyID ASC", SPMSConn2).ExecuteScalar
        Return m_return
    End Function


    Public Function ExecuteQueryStoredProcedure(ByVal StoredProcedure As String) As DataTable
        Dim cmd As New SqlCommand(StoredProcedure, SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        ' da.Fill(dt)
        da.Dispose()
        cmd.Dispose()
        Return dt
    End Function

    Public Function ExecuteStoredProcedure(ByVal StoredProcedure As String) As DataTable
        Dim cmd As New SqlCommand(StoredProcedure, SPMSConn2)
        cmd.CommandType = CommandType.Text
        cmd.CommandTimeout = 0
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        da.Dispose()
        cmd.Dispose()
        Return dt
    End Function

    Public Function RefineSQL(ByVal StringToRefine As String) As String
        StringToRefine = Replace(StringToRefine, "'", "''")
        StringToRefine = Replace(StringToRefine, "[", "")
        StringToRefine = Replace(StringToRefine, "]", "")
        StringToRefine = Replace(StringToRefine, "ñ", "n")
        StringToRefine = Replace(StringToRefine, "Ñ", "N")
        StringToRefine = Replace(StringToRefine, " ", "")
        StringToRefine = Replace(StringToRefine, "*", "0")
        StringToRefine = Replace(StringToRefine, vbCrLf, String.Empty)
        StringToRefine = Replace(StringToRefine, vbLf, String.Empty)
        If IsDBNull(StringToRefine) Then
            StringToRefine = ""
        End If
        Return IIf(StringToRefine Is Nothing, "", StringToRefine)
    End Function
End Module
