using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class Excel2Json : AssetPostprocessor
{
	public static readonly string JsonDestPath = "Tables/json/";
	public static readonly string JsonExtention = ".json";
	static readonly string ExcelSrcPath = "Assets/Tables/";
	static string[] excelExtention = { ".xlsx", ".xlsm" };
	static string exeFileName = Application.dataPath + "/Tools/Excel2Json.exe";
	static string localizationFileName = "Localization";

	static void OnPostprocessAllAssets(
		string[] importedAssets,
		string[] deletedAssets,
		string[] movedAssets,
		string[] movedFromAssetPaths
		)
	{
		ToJsonFile(importedAssets);
		return;
	}

	static void LogPostprocessAllAssets(
		string[] importedAssets,
		string[] deletedAssets,
		string[] movedAssets,
		string[] movedFromAssetPaths
		)
	{
		foreach (string str in importedAssets)
		{
			Debug.Log("Reimported Asset: " + str);
		}

		foreach (string str in deletedAssets)
		{
			Debug.Log("Deleted Asset: " + str);
		}

		for (int i = 0; i < movedAssets.Length; i++)
		{
			Debug.Log("Moved Asset: " + movedAssets[i] + " from: " + movedFromAssetPaths[i]);
		}
	}

	static void ToJsonFile(string[] importedAssets)
	{
		if (Application.platform != RuntimePlatform.WindowsEditor)
			return;

		bool isDirty = false;
		foreach (string fileName in importedAssets)
		{
			if (!fileName.StartsWith(ExcelSrcPath))
				continue;

			if (!excelExtention.Any(ext => fileName.EndsWith(ext)))
				continue;

			var relativeFileName = fileName.Substring(ExcelSrcPath.Length);
			if (relativeFileName.StartsWith("~$"))
				continue;

			string src = Path.GetDirectoryName(Application.dataPath) + "/" + fileName;
			string dest = Application.dataPath + "/" + JsonDestPath + Path.GetFileNameWithoutExtension(relativeFileName) + JsonExtention;

			System.Diagnostics.Process process = new System.Diagnostics.Process();
			process.StartInfo.FileName = exeFileName;
			process.StartInfo.Arguments = string.Format("{0} {1} {2}", src, dest, fileName.Contains(localizationFileName));
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.StandardErrorEncoding = Encoding.GetEncoding(949);
			process.Start();

			var lines = new List<string>();
			while (true)
			{
				var line = process.StandardError.ReadLine();
				if (line == null)
					break;

				if (string.IsNullOrEmpty(line) && lines.Count == 0)
					continue;

				lines.Add(line);
			}
			process.WaitForExit();

			if (process.ExitCode != 0)
			{
				Debug.Log("An error has occurred during parsing asset: " + fileName);
			}
			else
			{
				Debug.Log("Reimported asset: " + fileName);
				isDirty = true;
			}

			if (lines.Count > 0)
			{
				Debug.LogError(string.Join("\n", lines.ToArray()));
			}
		}

		if (isDirty)
		{
			AssetDatabase.Refresh(ImportAssetOptions.Default);
		}
	}
}