### Install dotnet core 3.1 on Ubuntu 16.04

```Bash
curl https://packages.microsoft.com/keys/microsoft.asc | sudo apt-key add -
sudo apt-add-repository https://packages.microsoft.com/ubuntu/16.04/prod
sudo apt-get update
sudo apt-get install dotnet-sdk-3.1
```

### Tutorial: Create a web API with ASP.NET Core

[https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio)

### Host ASP.NET Core on Linux with Nginx

[https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-nginx?view=aspnetcore-3.1](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-nginx?view=aspnetcore-3.1)

### Install nginx on Ubuntu 16.04

```Bash
sudo apt-get install nginx
sudo service nginx start
```
### Connect to server using FileZilla

[https://superuser.com/a/507475](https://superuser.com/a/507475)

### Publish dotnet core application

```Bash
dotnet publish --configuration Release
```

### Set as service

Create the service definition file:
```Bash
sudo nano /etc/systemd/system/classroomApi.service
```

The following is service file for the app:
```ini
[Unit]
Description= Classroom Api

[Service]
WorkingDirectory=/var/www/html/api
ExecStart=/usr/bin/dotnet /var/www/html/api/ClassroomApi.dll
Restart=always
#Restart service after 10 seconds if the dotnet service crashes:
RestartSec=10
KillSignal=SIGINT
SyslogIdentifier=dotnet-example
User=root
Environment=ASPNETCOREENVIRONMENT=Production
Environment=DOTNETPRINTTELEMETRYMESSAGE=false

[Install]
WantedBy=multi-user.target
```

Save the file and enable the service.
```Bash
sudo systemctl enable classroomApi.service
```

Start the service and check the status:
```Bash
sudo systemctl start classroomApi.service
sudo systemctl status classroomApi.service
```

Stop and restart the service:
```Bash
sudo systemctl stop classroomApi.service
sudo systemctl restart classroomApi.service
```

### How to debug/unit test webAPi in one solution

> 

    1. Start debugging Unit Test
    2. While on the first line of your test code or before calling your local web api project
    3. Right click on your web api project and Debug > Start new instance

