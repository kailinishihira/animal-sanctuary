# Animal Sanctuary

## By Kaili Nishihira and Michael Woldemedihin

#### _A web application for a local animal sanctuary, 10.18.17_


## Description

### Assignment:
_You and your pair have been asked to build the back-end of a new web application for the local animal sanctuary. Your specific task is to design a computer system that will accept and categorize all the animals that come into the sanctuary. A team of designers will write Razor pages for the views later on, your job is to write the models, database tables, and controllers._

### User story
* A user should be able to see a list of all animals at the sanctuary.
* A user can view an individual animals details.
* A user should be able to see a list of all veterinarians at the sanctuary.
* A user can see a veterinarians details.
* A user should be able to add a new veterinarian.
* A user should be able to admit a new animal, linked with its veterinarian.

## Setup/Installation Requirements

* _Download and install [.NET Core 1.1 SDK](https://www.microsoft.com/net/download/core)_
* _Download and install [Mono](http://www.mono-project.com/download/)_
* _Download and install [MAMP](https://www.mamp.info/en/)_
* _Download and install [Visual Studio 2017](https://www.visualstudio.com/)_
* _Clone repository_

### Setup/Installation for Database
* In your terminal, navigate from the Solution folder to the project folder, Animal Sanctuary
* Enter `dotnet restore` in your terminal
* Enter `dotnet ef database udpate` in your terminal
* To create test database: go to phpMyAdmin on the MAMP website, copy the animalSanctuary database, and rename it animalSanctuary_test

## Technologies Used
* _C#_
* _.NET_
* _MVC_
* _Entity Framework_
* _[Bootstrap](http://getbootstrap.com/getting-started/)_
* _[MySQL](https://www.mysql.com/)_

### License

Copyright (c) 2017 **_Kaili Nishihira and Michael Woldemedihin_**

*Licensed under the [MIT License](https://opensource.org/licenses/MIT)*


### ASP.Net
#### Add Packages
* Microsoft.AspNetCore.Mvc - Version 1.1.2
* Microsoft.EntityFrameworkCore - Version 1.1.2
* Pomelo.EntityFrameworkCore.MySql - Version 1.1.2
* Microsoft.AspNetCore.StaticFiles - Version 1.1.2
* Microsoft.AspNetCore - Version 1.1.2
* Moq (for testing with mock databases)

### Migration
#### Add Packages
* Microsoft.EntityFrameworkCore.Design - Version 1.1.2

#### Add to .csproj
```
<Item Group>
  <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="1.0.0" />
</Item Group>
```
If missing, add:
```
<Item Group>
  <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="1.1.2" />
</Item Group>
```

#### Commands in terminal or VS Package Console (Windows only)
* `dotnet restore` (keep running restore if you come across errors)
* `dotnet ef migrations add Initial` (Initial can be any name of your migration, like a commit message)
* `dotnet ef database update`
