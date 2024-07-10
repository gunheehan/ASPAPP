#Game Store API

## Starting SQL Server

```powershell
$sa_password = "[SA PASSWORD HERE]"
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Salin@2017" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 2000:1433 -v sqlvolume:/var/opt/mssql -d --name=demouser mcr.microsoft.com/azure-sql-edge
```

## Setting the connection string ro secret manager
```powershell
$sa_password = "[SA PASSWORD HERE]"
dotnet user-secrets set "ConnectionStrings:UserContext" "Server=localhost; Database = User; User Id = salin; Password = salin2017; TrustServerCertificate = True"
```

docker run -e "ACCEPT_EULA=1" -e "SA_PASSWORD=Pass@word123" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1436:1436 -d --name=mssql mcr.microsoft.com/azure-sql-edge
/opt/mssql/bin/sqlcmd -S localhost -U SA -P 'Salin2017'
