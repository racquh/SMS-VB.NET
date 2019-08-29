Imports Zenoph.SMSLib
Imports Zenoph.SMSLib.Enums

Public Class Main
    Private Const Token As String = "Status"


    'message
    Dim senderId As String
    Dim Reciepient As String
    Dim message As String
    'image

    Private images As New List(Of Image)
    Private index As Integer
    Public Sub New()
        InitializeComponent()

        images.Add(My.Resources.banner_a)
        images.Add(My.Resources.banner_b)
        images.Add(My.Resources.banner_c)
        images.Add(My.Resources.banner_d)

        tmImage.Interval = 6000
        tmImage.Start()

    End Sub

    Private Sub TmImage_Tick(sender As Object, e As EventArgs) Handles tmImage.Tick
        If images.Count > 0 Then
            If index >= images.Count Then
                index = 0
            End If
            picLogo.Image = images(index)
            index += 1
        End If
    End Sub


    'Time and date
    Private Sub TmTime_Tick(sender As Object, e As EventArgs) Handles tmTime.Tick
        lblTime.Text = TimeOfDay
    End Sub

    Private Sub TmDate_Tick(sender As Object, e As EventArgs) Handles tmDate.Tick
        lblDate.Text = Date.Today
    End Sub

    'forms Load
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmImage.Start()
        tmTime.Start()
        tmDate.Start()
    End Sub

    'close button
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnClose_MouseHover(sender As Object, e As EventArgs) Handles btnClose.MouseHover
        btnClose.BackColor = Color.Red
    End Sub

    Private Sub btnClose_MouseLeave(sender As Object, e As EventArgs) Handles btnClose.MouseLeave
        btnClose.BackColor = Color.Transparent
    End Sub




    'Buttons
    Private Sub BtnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        sptSide.Height = btnHome.Height
        sptSide.Top = btnHome.Top

        BunifuPages1.SetPage(Home)
    End Sub

    Private Sub BtnRegisteration_Click(sender As Object, e As EventArgs) Handles btnRegisteration.Click
        sptSide.Height = btnRegisteration.Height
        sptSide.Top = btnRegisteration.Top

        BunifuPages1.SetPage(Register)
    End Sub

    Private Sub BtnUsers_Click(sender As Object, e As EventArgs) Handles btnUsers.Click
        sptSide.Height = btnUsers.Height
        sptSide.Top = btnUsers.Top

        BunifuPages1.SetPage(Users)
    End Sub

    Private Sub BtnEmpInfo_click(sender As Object, e As EventArgs) Handles btnEmpInfo.Click
        sptSide.Height = btnEmpInfo.Height
        sptSide.Top = btnEmpInfo.Top

        BunifuPages1.SetPage(EmployeeInfo)
    End Sub


    Private Sub BtnStudents_Click(sender As Object, e As EventArgs) Handles btnStdInfo.Click
        sptSide.Height = btnStdInfo.Height
        sptSide.Top = btnStdInfo.Top

        BunifuPages1.SetPage(StudentsInfo)
    End Sub

    Private Sub BtnAttendance_Click(sender As Object, e As EventArgs) Handles btnAttendance.Click
        sptSide.Height = btnAttendance.Height
        sptSide.Top = btnAttendance.Top

        BunifuPages1.SetPage(Attendance)
    End Sub

    Private Sub BtnClasses_Click(sender As Object, e As EventArgs) Handles btnClasses.Click
        sptSide.Height = btnClasses.Height
        sptSide.Top = btnClasses.Top

        BunifuPages1.SetPage(Classes)
    End Sub

    Private Sub BtnPayment_Click(sender As Object, e As EventArgs) Handles btnPayment.Click
        sptSide.Height = btnPayment.Height
        sptSide.Top = btnPayment.Top

        BunifuPages1.SetPage(Payments)
    End Sub

    Private Sub BtnTimetable_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        sptSide.Height = btnReports.Height
        sptSide.Top = btnReports.Top

        BunifuPages1.SetPage(Reports)
    End Sub

    Private Sub BtnExamination_Click(sender As Object, e As EventArgs) Handles btnExamination.Click
        sptSide.Height = btnExamination.Height
        sptSide.Top = btnExamination.Top

        BunifuPages1.SetPage(Examination)
    End Sub

    Private Sub BtnMessage_Click(sender As Object, e As EventArgs) Handles btnMessage.Click
        sptSide.Height = btnMessage.Height
        sptSide.Top = btnMessage.Top

        BunifuPages1.SetPage(Messages)
    End Sub

    Private Sub BtnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        sptSide.Height = btnSettings.Height
        sptSide.Top = btnSettings.Top

        BunifuPages1.SetPage(Settings)
    End Sub

    Private Sub BtnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        sptSide.Height = btnAbout.Height
        sptSide.Top = btnAbout.Top

        BunifuPages1.SetPage(About)
    End Sub


    Private Sub BtnRegStudent_Click(sender As Object, e As EventArgs) Handles btnRegStudent.Click
        BunifuPages2.SetPage(Student)
    End Sub

    Private Sub BtnRegEmployee_Click(sender As Object, e As EventArgs) Handles btnRegEmployee.Click
        BunifuPages2.SetPage(Employee)
    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles btnSRBack.Click
        BunifuPages2.SetPage(RegistrationType)
    End Sub

    Private Sub BtnERBack_Click(sender As Object, e As EventArgs) Handles btnERBack.Click
        BunifuPages2.SetPage(RegistrationType)
    End Sub

    Private Sub BtnSRDone_Click(sender As Object, e As EventArgs) Handles btnSRDone.Click
        BunifuPages2.SetPage(Done)
        lblRDone.Text = "Student has been successfully been registered!"
    End Sub

    Private Sub BtnEMDone_Click(sender As Object, e As EventArgs) Handles btnEMDone.Click
        BunifuPages2.SetPage(Done)
    End Sub

    Private Sub BtnRDOk_Click(sender As Object, e As EventArgs) Handles btnRDOk.Click
        BunifuPages2.SetPage(RegistrationType)
    End Sub

    Private Sub BtnSendMessage_Click(sender As Object, e As EventArgs) Handles btnSendMessage.Click

        Dim sms As New ZenophSMS
        Dim status As Dictionary(Of STATUSQUERY, List(Of String)) = Nothing


        If txtSenderId.Text = Nothing Then
            MsgBox("Please Enter an Id")
        Else
            senderId = txtSenderId.Text
        End If

        If txtMyMessage.Text = Nothing Then
            MsgBox("please input message")
        Else
            message = txtMyMessage.Text
        End If

        If txtMessageReciever.Text = Nothing Then
            MsgBox("please enter the reciepient number")

        Else
            If sms.isValidPhoneNumber(Reciepient, True) Then
                Reciepient = txtMessageReciever.Text
            Else
                MsgBox("Please enter a valid phone number")
            End If
        End If




        Try

            ' Initialise SMS object and perform authentication.
            'Dim sms As New ZenophSMS
            sms.setUser("racquh@gmail.com")
            sms.setPassword("smsonlinegh")
            sms.authenticate()

            ' set message parameters.
            sms.setSenderId(senderId)
            sms.setMessageType(MSGTYPE.TEXT)
            sms.setMessage(message)

            ' add destinations.
            sms.addRecipient(Reciepient)
            'sms.addRecipient("233506813454")

            sms.submit()

            MsgBox("message sent")
        Catch sex As SMSException
            ' handle exception here
            MsgBox(sex)
            ' Catch ex As Exception
            ' handle exception here

        End Try
    End Sub


End Class
