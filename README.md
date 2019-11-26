# elkTester
Sends test message to specified Logstash.

# Usage
Clone repo and publish the app
```console
foo@bar:~$ dotnet publish
foo@bar:~$ cd bin/Debug/netcoreapp2.2/publish
foo@bar:~$ dotnet elkTester.dll localhost 5001

```

# Configuration from file
To use configuration from file uncomment folowing line:

```csharp
// .ReadFrom.AppSettings(config)
```
