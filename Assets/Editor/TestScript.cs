using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class TestScript
{
    [UnityEditor.Callbacks.PostProcessBuild]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
		string downloadFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string verpatchPath = System.IO.Path.Combine(downloadFolderPath, "Downloads/verpatch/verpatch.exe");

		string commandLine = string.Format("\"{0}\" \"{1}\" /high /s CompanyName \"Foobar\" /s ProductName \"{2}\" /s ProductVersion \"{1}\"", pathToBuiltProject, PlayerSettings.bundleVersion, PlayerSettings.productName);
		Debug.Log("verpatch command line: " + commandLine);

		var result = System.Diagnostics.Process.Start(verpatchPath, commandLine);
		Debug.Log("verpatch process result: " + result);

        // Process process = new Process();
        // process.StartInfo.FileName = pathToBuiltProject;
        // process.Start();
    }

    public static void Build()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
        buildPlayerOptions.target = BuildTarget.StandaloneWindows;
        buildPlayerOptions.options = BuildOptions.None;
        buildPlayerOptions.locationPathName = Path.Combine("WindowsPlayer", PlayerSettings.productName + ".exe");
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
}
