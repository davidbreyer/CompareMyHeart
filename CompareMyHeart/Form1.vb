Imports System.IO
Imports System.Security.Cryptography
Imports System.Threading

<Assembly: CLSCompliant(True)> 

Public Class Form1

    Delegate Sub SetTextCallback(ByVal [text] As String)
    Delegate Sub IncrementBarCallback()
    Delegate Sub ShowHideProgressCallBack(ByVal [show] As Boolean)
    Delegate Sub EnableDisableCheckButtonCallBack(ByVal [enable] As Boolean)
    Delegate Sub SetStatusLabelCallBack(ByVal [text] As String)

    Dim _elapsed_time As TimeSpan
    Dim _start_time As DateTime
    Dim _stop_time As DateTime
    Dim _NumberOfFiles As Int64 = 0
    Dim Dir1 As String = String.Empty
    Dim Dir2 As String = String.Empty
    Dim MD5Alg As New MD5CryptoServiceProvider
    Dim _fileOne As Stream = Nothing
    Dim _fileTwo As Stream = Nothing


#Region "Form Events"

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not MD5Alg Is Nothing Then
            MD5Alg.Clear()
            MD5Alg = Nothing
        End If

        If Not _fileOne Is Nothing Then
            _fileOne.Dispose()
        End If

        If Not _fileTwo Is Nothing Then
            _fileTwo.Dispose()
        End If
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtInitialDirectory.Text = My.Settings.FolderA
        txtDirectoryToCheck.Text = My.Settings.FolderB
    End Sub

    Private Sub btnCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheck.Click

        ResetEngine()

        EnginePrep()

        Dim thread1 As New Thread(AddressOf ProcessFiles)
        thread1.Start()

        Me.Refresh()
    End Sub

    Private Sub btnFolder1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFolder1.Click
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtInitialDirectory.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub btnFolder2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFolder2.Click
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtDirectoryToCheck.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
#End Region

#Region "Form Logic"

    Private Sub ResetEngine()
        'Clear the result display
        TextBox1.Clear()
        'Reset the number of processed files
        _NumberOfFiles = 0
        'Notify user that comparision engine is starting
        Me.SetStatusLabel(My.Settings.CompareStartMessage)
    End Sub

    Private Sub EnginePrep()
        'Collect user input
        'This stores the settings in the user directory.
        My.Settings.FolderA = txtInitialDirectory.Text
        My.Settings.FolderB = txtDirectoryToCheck.Text
        'Set the variables that the engine will be working with.
        Dir1 = txtInitialDirectory.Text
        Dir2 = txtDirectoryToCheck.Text
        'Being time calculations - to compare performance
        StopWatchStart()
        'Disable Verify button to prevent duplicate input
        EnableDisableCheckButton(False)
        'Bring the continous progress bar online
        ShowHideProgress(True)
        'Increment bar to demonstrate start of engine
        IncrementBar()
        'Notify user that application engine is ready
        WriteMessage(My.Settings.CompareStartMessage)
    End Sub

    Private Sub EngineShutdown(ByVal Success As Boolean)
        'If the comparision was a success
        If Success Then
            WriteMessage(My.Settings.SuccessMessage) 'Notify user of success
        Else 'If unsuccessful, one or more directories does not exists, etc.
            WriteMessage(My.Settings.FailureMessage) 'Notify user of failure
            Me.SetStatusLabel(String.Empty) 'Clear the statusbar.
        End If

        ShowHideProgress(False) 'hide the progress bar
        EnableDisableCheckButton(True) 'Enable the Verify button for new input
    End Sub

    Private Sub ProcessFiles()
        ' Try
        If System.IO.Directory.Exists(Dir1) And System.IO.Directory.Exists(Dir2) Then
            'Compare files in the root directory
            For Each textFile As String In Directory.GetFiles(Dir1)
                CompareFile(textFile, Dir1)
            Next

            'Start of the recursive comparision operation
            ExamineDirectory(Dir1)

            'Once the comparision is complete, clean up
            EngineShutdown(True)
            StopWatchStop()
        Else
            EngineShutdown(False)
            MsgBox(My.Settings.InvalidFolderMessage)
        End If
    End Sub

    Private Sub ExamineDirectory(ByVal ExamineDir As String)
        Try
            'Get the first folder
            For Each folder As String In Directory.GetDirectories(ExamineDir)
                'Process the files in the selected folder
                For Each textfile As String In Directory.GetFiles(folder)
                    CompareFile(textfile, folder)
                Next
                'This recursive operation will process subfolders within the selected folder
                ExamineDirectory(folder)
            Next
        Catch ex As IOException 'Quietly handles any file operation exceptions.
        End Try
    End Sub

    Private Sub CompareFile(ByVal textFile As String, ByVal Folder As String)
        Try
            'Incremement file counter
            _NumberOfFiles += 1
            'Increment our progress bar
            IncrementBar()

            'Notify user that file is being processed.
            'Incase of large files the user will know which
            'file is slowing down the folder comparision process.
            Me.SetStatusLabel(String.Format("Processing {0}...", textFile))

            'Open the file from the source directory
            _fileOne = File.OpenRead(textFile)

            'Check to see if the file exists in the target directory
            'Set target file name, makes code more readable
            Dim _targetFile As String = String.Format("{0}\{1}", Folder.Replace(Dir1, Dir2), System.IO.Path.GetFileName(textFile))
            If System.IO.File.Exists(_targetFile) Then
                _fileTwo = File.OpenRead(_targetFile)

                'We will use the ComputeHash method to get our hash values of each file
                Dim hashValue1 As Byte() = MD5Alg.ComputeHash(_fileOne)
                Dim hashValue2 As Byte() = MD5Alg.ComputeHash(_fileTwo)

                'Done reading so close the files
                _fileOne.Close()
                _fileTwo.Close()

                Dim stringValue1 As String = BitConverter.ToString(hashValue1)
                Dim stringValue2 As String = BitConverter.ToString(hashValue2)

                'Notify user if target file fails checksum
                If Not stringValue1 = stringValue2 Then
                    WriteMessage(String.Format("{0} has failed checksum validation.", textFile))
                End If
            Else
                'Notify user that Target file does not exists.
                WriteMessage(String.Format("{0} does not exist in the target folder.", textFile))
            End If
        Catch ex As IOException
            'This can happen if the file is open.
            'Notify the user then continue processing files in the source directory.
            WriteMessage(String.Format("{0} is in use and cannot be examined.", textFile))
        End Try
    End Sub

    Private Sub StopWatchStart()
        _start_time = Now
    End Sub

    Private Sub StopWatchStop()
        _stop_time = Now
        _elapsed_time = _stop_time.Subtract(_start_time)
        Me.SetStatusLabel(String.Format("Compared {0} file(s) in {1} seconds.", _NumberOfFiles, _elapsed_time.TotalSeconds.ToString("0.000000")))
    End Sub

    Private Sub WriteMessage(ByVal message As String)
        SetText(message)
    End Sub
#End Region

#Region "Thread Safe Functions"
    ' This method demonstrates a pattern for making thread-safe
    ' calls on a Windows Forms control. 
    '
    ' If the calling thread is different from the thread that
    ' created the TextBox control, this method creates a
    ' SetTextCallback and calls itself asynchronously using the
    ' Invoke method.
    '
    ' If the calling thread is the same as the thread that created
    ' the TextBox control, the Text property is set directly. 

    Private Sub SetText(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.TextBox1.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.TextBox1.AppendText([text] & vbCrLf)
        End If
    End Sub

    Private Sub IncrementBar()

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ProgressBar1.InvokeRequired Then
            Dim d As New IncrementBarCallback(AddressOf IncrementBar)
            Me.Invoke(d, New Object() {})
        Else
            If Me.ProgressBar1.Value < 99 Then
                Me.ProgressBar1.Increment(1)
                Me.ProgressBar1.Refresh()
            Else
                Me.ProgressBar1.Value = 0
            End If
        End If
    End Sub

    Private Sub ShowHideProgress(ByVal show As Boolean)
        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ProgressBar1.InvokeRequired Then
            Dim d As New ShowHideProgressCallBack(AddressOf ShowHideProgress)
            Me.Invoke(d, New Object() {show})
        Else
            ProgressBar1.Value = 0
            ProgressBar1.Step = 1
            ProgressBar1.Visible = show
        End If
    End Sub

    Private Sub SetStatusLabel(ByVal text As String)
        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.btnCheck.InvokeRequired Then
            Dim d As New SetStatusLabelCallBack(AddressOf SetStatusLabel)
            Me.Invoke(d, New Object() {[text]})
        Else
            ToolStripStatusLabel1.Text = text
            Me.StatusStrip1.Refresh()
        End If
    End Sub


    Private Sub EnableDisableCheckButton(ByVal enable As Boolean)
        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.btnCheck.InvokeRequired Then
            Dim d As New EnableDisableCheckButtonCallBack(AddressOf EnableDisableCheckButton)
            Me.Invoke(d, New Object() {enable})
        Else
            If enable Then
                btnCheck.Text = My.Settings.ButtonReadyMessage
                btnCheck.Enabled = True
            Else
                btnCheck.Text = My.Settings.ButtonExecutingMessage
                btnCheck.Enabled = False
            End If
        End If
    End Sub
#End Region

End Class
