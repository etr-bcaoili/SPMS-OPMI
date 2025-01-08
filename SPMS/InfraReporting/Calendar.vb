Public Class Calendar
    Private m_HasError As Boolean = False
    Private m_Err As New ErrorProvider


    Private v_Date As Date = Now.Date

    Public Property DateValue() As Date
        Get
            Return v_Date
        End Get
        Set(ByVal value As Date)
            v_Date = value
        End Set
    End Property

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Me.DialogResult = Windows.Forms.DialogResult.OK
        v_Date = MonthCalendar1.SelectionStart.ToShortDateString
        Me.Close()
    End Sub

    Private Sub Calendar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MonthCalendar1.SetDate(Now.Date)
    End Sub

    Private Sub MonthCalendar1_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateChanged

    End Sub
    Public Shared Function getFillterPopullar() As DataTable
        Return GetRecords("SELECT Distinct CAYR  FROM Calendar ")
    End Function

    Private Sub MonthCalendar1_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateSelected

    End Sub

    Private Sub MonthCalendar1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MonthCalendar1.KeyDown
        If e.KeyCode = Keys.Enter Then

            Me.DialogResult = Windows.Forms.DialogResult.OK
            v_Date = MonthCalendar1.SelectionStart.ToShortDateString
            Me.Close()
        End If
    End Sub

End Class