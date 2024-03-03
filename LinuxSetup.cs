﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using iText.Commons.Utils;

class LinuxSetup
{
   public static void Setup()
    {
        Directory.SetCurrentDirectory("../../../");
        Console.WriteLine("Running on Linux");
        checkInstallGhostScript();
    }

    /// <summary>
    /// Checks if GhostScript is installed, if not, asks the user if they want to install it
    /// </summary>
    private static void checkInstallGhostScript()
    {
        //Check if GhostScript is installed
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = "/bin/bash";
        startInfo.Arguments = "-c \" " + "gs -version" + " \"";
        startInfo.RedirectStandardOutput = true;
        startInfo.UseShellExecute = false;
        startInfo.CreateNoWindow = true;
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardError = true;
        startInfo.RedirectStandardOutput = true;

        Process process = new Process();
        process.StartInfo = startInfo;
        process.Start();
        process.WaitForExit();
        string output = process.StandardOutput.ReadToEnd();
        Console.WriteLine(output);
        if (!output.Contains("GPL Ghostscript"))
        {
            Console.WriteLine("GhostScript is not installed.");
            Console.WriteLine("If you are on Ubuntu/Debian run: sudo apt install ghostscript");
            Console.WriteLine("For other Linux distros see https://www.ghostscript.com/ for installation instructions.");
        
        }
    }
}