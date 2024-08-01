# Comands

### Create Global.json
dotnet new globaljson --sdk-version 8.0.100

### Create sln 
dotnet new sln -n CleanArchitectureDDD

### Create classlib
dotnet new classlib -n CleanArchitectureDDD.Domain

### Add to sln
dotnet sln CleanArchitectureDDD.sln add CleanArchitectureDDD.Domain/CleanArchitectureDDD.Domain.csproj

### Add references
dotnet add CleanArchitectureDDD.Infrastructure/CleanArchitectureDDD.Infrastructure.csproj reference CleanArchitectureDDD.Domain/CleanArchitectureDDD.Domain.csproj