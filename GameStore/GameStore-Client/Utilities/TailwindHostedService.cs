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