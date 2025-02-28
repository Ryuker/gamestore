# Tailwind Setup
- with support for `dotnet watch`
- currently works with v3 or Tailwind, had issues with v4 file watching

- make sure to add `node-modules` to `.gitignore`

## Install Tailwind
```Shells
npm init -y
npm install -D tailwindcss@3
npm i
npx tailwindcss init
```
- the above creates a `package.json` file and installs Tailwind 3
- adds `tailwind.config.js`

## Config
```JS
/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./Pages/**/*.cshtml", "./Pages/*.cshtml"],
  theme: {
    extend: {},
  },
  plugins: [],
};
```

## Add scripts to package.json
```JS
"css:build": "npx tailwindcss -i ./wwwroot/css/site.css -o ./wwwroot/css/output.css",
"tailwind:watch": "npx tailwindcss -i ./wwwroot/css/site.css -o ./wwwroot/css/output.css --watch"
```

## Modify wwwroot/css/site.css to import tailwind classes
```CSS
@tailwind base;
@tailwind components;
@tailwind utilities;
```

## Import output.css in Pages/Shared/cshtml
```HTML
<link rel="stylesheet" href="~/css/output.css" asp-append-version="true" />
```

## supporting watch changes with hot reload
- Add `Utilities` folder
- Add `TailwindHostedService.cs`
```CS
using System.Diagnostics;

namespace GameStore_Client.Utilities;

public class TailwindHostedService : IHostedService
{
    private Process? _process;
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _process = Process.Start(new ProcessStartInfo
        {
            FileName = "npm",
            Arguments = "run tailwind:watch",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        })!;
        
        _process.EnableRaisingEvents = true;
        _process.OutputDataReceived += (_, e) => Console.WriteLine($"Tailwind: {e.Data}");
        _process.ErrorDataReceived += (_, e) => Console.WriteLine($"Tailwind: {e.Data}");

        _process.BeginOutputReadLine();
        _process.BeginErrorReadLine();
        
        return Task.CompletedTask;
    }
    
    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Tailwind: STOP");
        _process?.Kill(entireProcessTree: true);
        return Task.CompletedTask;
    }
}
```

- modify `Program.cs` to run the Service in development mode

``` CS
using GameStore_Client.Utilities;

// other code

// Tailwind Recompile after each file change
if (builder.Environment.IsDevelopment())
{
  builder.Services.AddHostedService<TailwindHostedService>();
}
```

## Run with watch support
- Tailwind rebuilds output.css when a file is changed

```Shell
dotnet watch
```


