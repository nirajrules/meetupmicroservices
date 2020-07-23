# Meetup Microservices

Meetup Product Extensions

## Technology

This site is created using .NET Core Web Application (Razor Pages). .NET Core Razor Pages is a new implementation of old ASPX Web Application based on a page controller model (no complexity of MVC complex routing model). The framework is based on MVVM approach where the View & ViewModel are bundled together. Accordingly this project too bundles the views along with view models. SPA (Single Page Application - approach where the server loads the page on initial interaction, and rest all of the interactions are handled through JS variations) with AngularJS and Front-End JS variants (React, Vue, etc.) will be considered for future evolution. To that end it might help to recreate the backend too in Node.js and its variants including Express, Meteor, etc.

For Website Design Bootsrap (<https://getbootstrap.com)> dashboard template is used. The design is not optimized and due to lack to time has been a bad copy + paste. It will have to be improvised in future.

.NET Core framework, Kestrel server and dotnet cli command are mainly used for implementation. Packages like NewtonSoft, RestSharp, etc. are installed through dotnet CLI. For e.g.

```bash
dotnet add JsonTest.csproj package Newtonsoft.Json
```

The NuGet package information is stored in .CSPROJ file and the packages are not checked into source code. The Dockerfile uses `dotnet restore` command restore these packages.

In addition to packages, all the compiled binaries and artifacts are not stored in the github repo. This is done via .gitignore files. Even Docker builds uses .dockerignore to ignore files from it's build. These conventions should be followed all the time.  
