Imports System.Net.Sockets

Public Class Form1
    Dim client As TcpClient
    Dim stream As NetworkStream

    Private Sub BtnConnect_Click() Handles BtnConnect.Click
        Dim server As String = TxtConnectIpAddr.Text
        Dim port As Integer = TxtConnectPort.Text
        If BtnConnect.Text Like "Connect" Then
            Connect(server, port)
        ElseIf BtnConnect.Text Like "Disconnect" Then
            Disconnect()
        End If
    End Sub

    Private Sub BtnSend_Click() Handles BtnSend.Click
        Try
            ' Send the message to the connected TcpServer. 
            Dim cmd As String = TxtSend.Text & vbCrLf
            Dim data As [Byte]() = System.Text.Encoding.ASCII.GetBytes(cmd)
            stream.Write(data, 0, data.Length)
            Debug.WriteLine("Sent:" & cmd)
            TxtSend.Clear()
            'Enable a 500ms receive timer to compensate for network delay.
            TimerRecv.Enabled = True
        Catch e As ArgumentNullException
            Debug.WriteLine("ArgumentNullException: {0}", e)
            'Console.WriteLine("ArgumentNullException: {0}", e)
        End Try
    End Sub

    Private Sub Connect(server As [String], port As [Int32])
        Try
            ' Create a TcpClient.
            client = New TcpClient(server, port)
            'If it doesn't throw an exception set the button name to Disconnect.
            BtnConnect.Text = "Disconnect"

            ' Get a client stream for reading and writing.
            '  Stream stream = client.GetStream();
            stream = client.GetStream()
        Catch e As SocketException
            Debug.WriteLine("SocketException: {0}", e)
            BtnConnect.Text = "Connect"
        End Try
    End Sub

    Private Sub Disconnect()
        Try
            ' Close everything.
            stream.Close()
            client.Close()
            BtnConnect.Text = "Connect"

        Catch e As ArgumentNullException
            Debug.WriteLine("ArgumentNullException: {0}", e)
        Catch e As SocketException
            Debug.WriteLine("SocketException: {0}", e)
        End Try

    End Sub

    Private Sub wait() Handles TimerRecv.Tick
        TimerRecv.Enabled = False
        GetResponse()
    End Sub
    Private Sub GetResponse()
        ' Receive the TcpServer.response.
        ' Buffer to store the response bytes.
        Dim resp = New [Byte](256) {}
        ' String to store the response ASCII representation.
        Dim responseData As [String] = [String].Empty

        ' Read the first batch of the TcpServer response bytes.
        If stream.DataAvailable Then
            Dim bytes As Int32 = stream.Read(resp, 0, resp.Length)
            responseData = System.Text.Encoding.ASCII.GetString(resp, 0, bytes)
            txtResp.AppendText(responseData & vbCrLf)
            Debug.WriteLine("Received:" & responseData)
        Else
            txtResp.AppendText("No response" & vbCrLf)
            Debug.WriteLine("No response")
        End If


    End Sub

End Class
