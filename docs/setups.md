### Install dotnet core 3.1 on Ubuntu 16.04

```
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

```
sudo apt-get install nginx
sudo service nginx start
```
### Connect to server using FileZilla

[https://superuser.com/a/507475](https://superuser.com/a/507475)

### Publish dotnet core application

```
dotnet publish --configuration Release
```
