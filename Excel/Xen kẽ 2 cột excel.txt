Sub MergeColumns()
'UpdatebyExtendoffice20180815
Dim xSRg, xDRg As Range
Dim xDWS As Worksheet
Dim xIntDR, xIntDC, xI As Long
Dim xFNum As Long
On Error GoTo Err1
Set xSRg = Application.InputBox("Select two columns:", "Kutools for Excel", xTxt, , , , , 8)
If xSRg Is Nothing Then
Err1:
    Application.ScreenUpdating = True
    Exit Sub
End If
Set xDRg = Application.InputBox("Select a cell to place result:", "Kutools for Excel", xTxt, , , , , 8)
If xDRg Is Nothing Then
    Exit Sub
End If
Application.ScreenUpdating = False
Set xDWS = xDRg.Worksheet
xIntDR = xDRg.Row
xIntDC = xDRg.Column
xI = 0
    For xFNum = 1 To xSRg.Count
        Set xDRg = xDWS.Cells(xIntDR + xI, xIntDC)
        xDRg.Value = xSRg.Item(xFNum).Value
        xI = xI + 1
    Next xFNum
Application.ScreenUpdating = True
End Sub
