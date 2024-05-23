
# [Secure a .NET web app with the ASP.NET Core Identity framework](https://learn.microsoft.com/en-us/training/modules/secure-aspnet-core-identity)

## Add ASP.NET core identity

```
dotnet tool install dotnet-aspnet-codegenerator --version 6.0.2 --global
```

Install nuget packages

```
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 6.0.2
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 6.0.3
dotnet add package Microsoft.AspNetCore.Identity.UI --version 6.0.3
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.3
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.3
```

Add default idendity components

```
dotnet aspnet-codegenerator identity --useDefaultUI --dbContext RazorPagesPizzaAuth
```

## Update the db

```
dotnet tool install dotnet-ef --version 6.0.3 --global
dotnet ef migrations add CreateIdentitySchema
dotnet ef database update
```


## [Customize Identity](https://learn.microsoft.com/en-us/training/modules/secure-aspnet-core-identity/5-customize-identity)

Generate  registration files

```
dotnet aspnet-codegenerator identity --dbContext RazorPagesPizzaAuth --files "Account.Manage.EnableAuthenticator;Account.Manage.Index;Account.Register;Account.ConfirmEmail" --userClass RazorPagesPizzaUser --force
```

Some manual changes

Update database

```
dotnet ef migrations add UpdateUser
dotnet ef database update
```

## [2FA](https://learn.microsoft.com/en-us/training/modules/secure-aspnet-core-identity/6-multi-factor-authentication)

### TOTP

- Codes sent by SMS are reletivly easy to defeat but better than nothing. TOTP is a better option.

Add lib , using nuget, to generate a QR code

```
dotnet add package QRCoder --version 1.4.3
```

## [Authorization](https://learn.microsoft.com/en-us/training/modules/secure-aspnet-core-identity/9-enable-claims-policy-authorization)

