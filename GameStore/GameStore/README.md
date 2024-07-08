#Game Store API

## Starting SQL Server

```powershell
$sa_password = "[SA PASSWORD HERE]"
docker run -e "ACCEPT_EULA=1" -e "SA_PASSWORD=Pass@word123" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=mssql mcr.microsoft.com/azure-sql-edge
```

## Setting the connection string ro secret manager
```powershell
$sa_password = "[SA PASSWORD HERE]"
dotnet user-secrets set "ConnectionStrings:GameStoreContext" "Server=localhost; Database = GameStore; User Id = sa; Password = Pass@word123; TrustServerCertificate = True"
```