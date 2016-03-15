Public Class frmRecords

    Private Sub frmRecords_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblEasy.Text = My.Settings.easyRecord.ToString
        lblNormal.Text = My.Settings.mediumRecord.ToString
        lblHard.Text = My.Settings.hardRecord.ToString
    End Sub

    Private Sub cmdCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub
End Class