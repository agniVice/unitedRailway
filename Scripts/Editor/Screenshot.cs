using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEditor;

public class Screenshot : Editor
{
    [MenuItem("Tools/Screenshot")]
    public static void TakeScreenshot()
    {
        var dateTimeScreenshot = DateTimeOfTheScreenshot();
        Directory.CreateDirectory(ScreenshotPath);
        {
            while (File.Exists($"{ScreenshotPath}/{dateTimeScreenshot}")) { }
            ScreenCapture.CaptureScreenshot($"{ScreenshotPath}/{dateTimeScreenshot}");
        }

    }
    public static string DateTimeOfTheScreenshot()
    {
        return $"{DateTime.Now.Year}.{DateTime.Now.Month}.{DateTime.Now.Day}.[--{DateTime.Now.Hour}.{DateTime.Now.Minute}.{DateTime.Now.Second}--].png";
    }
    public static string ScreenshotPath = "Tool/Screenshot";
}
