# GameStore API and Client
Gamestore API and CLient, built with ASP.NET Core to gain familiarity with the framework.


# App Specifics
- Both API and Client are using `.NET 8.0.100`
- Client uses `Node 20.16.0` for Tailwind (use NVM)
  - there's no need to run Node during development, it gets run automatically by the build process.

# Run instructions
- The API needs to be running before running the client.

## Run the API
``` Shell
cd GameStore/GameStore-API
dotnet run
```

## Run the Client
``` Shell
cd GameStore/GameStore-API
```

```Shell
dotnet run
```

**Running while watching for file changes**
```Shell
dotnet watch
```

## Closing the apps
- `ctrl + c` in both respective terminals

---

### Styling isn't the focus
The client has Tailwind implemented, however the focus of the project was learning to understand ASP.NET Core and gaining familiarity with Razor Pages, working with models and the syntax etc. Though the html elements use Tailwind utility classes the project thus looks rather bland but can easily be improved upon.
