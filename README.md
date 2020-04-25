# Entertainment Lib

## Description

Entertainment Lib is simply something like a library in which you can store info about some movies and TV programs. I created it to practise `ASP.NET MVC`.

## How to run (deploy) locally

### Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/downloads/)
- Internet connection

### Steps

1. Clone or download this repo.
2. Navigate to `Entertainment_Lib` folder **inside** your local repo.
3. Create a folder named `App_Data`.
4. Open the solution in `Visual Studio`.
5. Type these two commands in the `Package Manager Console`: 
```
Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
update-database
```
6. Build and run (Ctrl + F5)
7. Enjoy :tada: :tada: