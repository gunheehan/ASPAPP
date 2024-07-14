#Game Store API

## Starting SQL Server

```powershell
$sa_password = "[SA PASSWORD HERE]"
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Salin@2017" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 2033:1433 -v sqlvolume:/var/opt/mssql -d --name=demouser mcr.microsoft.com/azure-sql-edge
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Salin@2017" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1555:1433 -v sqlvolume:/var/opt/mssql -d --name=usersql mcr.microsoft.com/azure-sql-edge
```

## Setting the connection string ro secret manager
```powershell
$sa_password = "[SA PASSWORD HERE]"
dotnet user-secrets set "ConnectionStrings:UserContext" "Server=localhost; Database = User; User Id = sa; Password = Pass@word123; TrustServerCertificate = True"
dotnet user-secrets set "ConnectionStrings:UserContext" "Server=localhost; Database = usersql; User Id = sa; Password = Salin@2017; TrustServerCertificate = True"
dotnet user-secrets set "ConnectionStrings:UserContext" "Server=localhost:1555; Database = usersql; User Id = signuser; Password = Salin@2017; TrustServerCertificate = True"
```
