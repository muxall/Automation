Imports System.Text.RegularExpressions
Imports Renci.SshNet
Imports Renci.SshNet.Common

Public Class Form1
    Dim client As SshClient
    Dim stream As ShellStream


    Private Sub BtnConnect_Click() Handles BtnConnect.Click
        Dim server As String = TxtConnectIpAddr.Text
        Dim port As Integer = TxtConnectPort.Text
        Dim username As String = "cisco"
        Dim password As String = "cisco"
        Dim connectionInfo = New PasswordConnectionInfo(server, port, username, password)
        connectionInfo.Timeout = TimeSpan.FromSeconds(5)
        If BtnConnect.Text Like "Connect" Then
            Connect(connectionInfo)
        ElseIf BtnConnect.Text Like "Disconnect" Then
            Disconnect()
        End If
    End Sub

    Private Sub Connect(connectionInfo As [PasswordConnectionInfo])
        Try
            ' Create a SshClient
            client = New SshClient(connectionInfo)
            client.Connect()

            'If it doesn't throw an exception set the button name to Disconnect.
            BtnConnect.Text = "Disconnect"

            'Dim dict = New Dictionary(Of TerminalModes, UInt32)
            'dict.Add(TerminalModes.ECHO, 0)
            'dict.Item(TerminalModes.ECHO) = 0
            'stream = client.CreateShellStream("vt100", 80, 24, 800, 600, 1024, dict)

            stream = client.CreateShellStream("CLI", 0, 0, 0, 0, 1024)

            ' disable terminal paging.
            TxtResp.AppendText("Disable terminal paging." & vbCrLf)
            stream.WriteLine("terminal length 0")
            stream.Flush()
            TimerRecv.Enabled = True

        Catch e As ArgumentException
            Debug.WriteLine("Host or Username is invalid: {0}", e)
            BtnConnect.Text = "Connect"
        Catch e As SshException
            Debug.WriteLine("SshException: {0}", e)
            BtnConnect.Text = "Connect"
        End Try
    End Sub

    Private Sub BtnSend_Click() Handles BtnSend.Click
        Try
            ' Send the message to the connected DUT. 
            Dim cmd = TxtSend.Text
            stream.WriteLine(cmd)
            stream.Flush()
            TxtResp.AppendText("Sent: " & cmd & vbCrLf)
            Debug.WriteLine("Sent:" & cmd)
            TxtSend.Clear()
            'Enable a 1000ms receive timer to compensate for network delay.
            TimerRecv.Enabled = True
        Catch e As ArgumentNullException
            Debug.WriteLine("ArgumentNullException: {0}", e)
            'Console.WriteLine("ArgumentNullException: {0}", e)
        End Try
    End Sub

    Private Sub Wait() Handles TimerRecv.Tick
        TimerRecv.Enabled = False
        GetResponse()
    End Sub

    Private Sub GetResponse()
        ' Read the first batch of the SshServer response .
        If stream.DataAvailable Then
            Dim strResponse = stream.Read()

            TxtResp.AppendText("Received: " & strResponse & vbCrLf)
            Debug.WriteLine("Received:" & strResponse)
        Else
            TxtResp.AppendText("No response" & vbCrLf)
            Debug.WriteLine("No response")
        End If

    End Sub


    Private Sub Disconnect()
        Try
            TxtResp.AppendText("Disconnecting...")
            stream.Close()
            client.Disconnect()
            BtnConnect.Text = "Connect"
            TxtResp.AppendText("Done!" & vbCrLf)
        Catch e As ObjectDisposedException
            Debug.WriteLine("ObjectDisposedException: {0}", e)
        End Try

    End Sub

End Class
