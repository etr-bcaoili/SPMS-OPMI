Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class NoSalesTransaction
    Public Shared Function NoSalesTransaction(ByVal CustomerCode As String, ByVal ShiptoCode As String) As String
        Return "Select Year,[Distributor Code],[Customer Code],[Customer Name],[ShipTo Address1],[ShipTo Address2],[Item Mother Code],[Item Brand Name] ,SUM([Quantity Sold]) [Qty],SUM([Net Amount])[Net Amount] From SC02File Where [Customer Code] = '" & CustomerCode & "' And [ShipTo Code] = '" & ShiptoCode & "' And Configtypecode NOT IN ('Y2018A','Y2020A') Group by  Year ,[Distributor Code]   ,[Customer Code] ,[Customer Name],[ShipTo Address1] ,[ShipTo Address2] ,[Item Mother Code],[Item Brand Name] Order by year Desc"
    End Function
End Class
