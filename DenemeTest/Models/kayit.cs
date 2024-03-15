using System.Diagnostics;

namespace DenemeTest.Models
{
    public static class kayit
    {
        public static void RecordScreen(string outputPath, int durationInSeconds)
        {
            // FFmpeg komutunu oluştur
            string ffmpegArgs = $"-f gdigrab -framerate 30 -t {durationInSeconds} -i desktop {outputPath}";

            // FFmpeg'i çalıştır
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = @"C:\ffmpeg\bin\ffmpeg.exe",
                Arguments = ffmpegArgs,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process process = new Process();
            process.StartInfo = startInfo;
            process.ErrorDataReceived += (s, e) => Console.WriteLine($"Error: {e.Data}");
            process.OutputDataReceived += (s, e) => Console.WriteLine($"Output: {e.Data}");
            process.Start();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();
            process.WaitForExit();
        }
    }
}
