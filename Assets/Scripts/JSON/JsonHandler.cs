using System.Collections;
using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor.PackageManager;
#endif
using UnityEngine;

public static class JsonHandler
{
    // dung de luu doi tuong vao file json
    public static void SaveToJson<T>(T data, string filename)
    {
        // chuyen doi tuong thanh chuoi json
        string json = JsonUtility.ToJson(data, true);
        // ghi chuoi jsson vao file
        WriteFile(GetPath(filename), json);
    }

    // lay du lieu cua doi tuong tu file json
    public static T LoadFromJson<T>(string filename)
    {
        string json = ReadFile(GetPath(filename));
        if (string.IsNullOrEmpty(json) || json == "{}")
        {
            return default(T);
        }
        T data = JsonUtility.FromJson<T>(json);
        return data;
    }

    // lay duong dan day du cua file
    public static string GetPath(string filename)
    {
        return Path.Combine(Application.persistentDataPath, filename);
    }

    // ghi chuoi json vao file
    private static void WriteFile(string path, string json)
    {
        FileStream fileStream = new FileStream(path, FileMode.Create);
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.WriteLine(json);
        }
    }

    // doc chuoi json tu file
    private static string ReadFile(string path)
    {
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        return "";
    }
}
