using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Nicologies 
{
  public static class PathHelper
  {
    public readonly static string UserAppDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    public readonly static string ProcessPath = Process.GetCurrentProcess().MainModule.FileName;
    public readonly static string ProcessBaseName = Path.GetFileNameWithoutExtension(
        Regex.Replace(ProcessPath, @"(.*)\.vshost\.exe$", @"$1.exe"));
    public readonly static string ProcessAppDir = Path.Combine(UserAppDataDir, ProcessBaseName);
    public readonly static string ProcessDir = Path.GetDirectoryName(ProcessPath);

    public static void CreateProcessAppDir()
    {
      if (Directory.Exists(ProcessAppDir))
      {
        return;
      }
      Directory.CreateDirectory(ProcessAppDir);
    }

    public static string GetCallingAssemblyPath()
    {
      var codeBase = Assembly.GetCallingAssembly().CodeBase;
      var uri = new UriBuilder(codeBase);
      return Uri.UnescapeDataString(uri.Path);
    }

    public static string GetCallingAssemblyDir()
    {
      return Path.GetDirectoryName(GetCallingAssemblyPath());
    }
  }
}
