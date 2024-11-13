using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class FileHandler
{
    // chuyen danh sach thanh chuoi JSON va luu chuoi nay vao file
    public static void SaveToJSON<T>(List<T> toSave, string filename)
    {
        Debug.Log(GetPath(filename));
        string content = JsonHelper.ToJson<T>(toSave.ToArray()); // chuyen doi danh sach thanh chuoi JSON
        WriteFile(GetPath(filename), content);
    }

    public static void SaveToJSON<T>(T toSave, string filename)
    {
        string content = JsonUtility.ToJson(toSave);
        WriteFile(GetPath(filename), content);
    }

    // doc du lieu JSON tu file va tra ve mot danh sach
    public static List<T> ReadListFromJSON<T>(string filename)
    {
        string content = ReadFile(GetPath(filename));
        if (string.IsNullOrEmpty(content) || content == "{}")
        {
            return new List<T>();
        }

        List<T> res = JsonHelper.FromJson<T>(content).ToList();

        return res;

    }

    public static T ReadFromJSON<T>(string filename)
    {
        string content = ReadFile(GetPath(filename));

        if (string.IsNullOrEmpty(content) || content == "{}")
        {
            return default(T);
        }

        T res = JsonUtility.FromJson<T>(content);

        return res;

    }

    // tra ve duong dan tuyet doi
    private static string GetPath(string filename)
    {
        return Application.persistentDataPath + "/" + filename;
    }

    // Ghi một chuỗi content vào file tại path.
    private static void WriteFile(string path, string content)
    {
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(content);
        }
    }

    // Đọc dữ liệu từ file
    private static string ReadFile(string path)
    {
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string content = reader.ReadToEnd();
                return content;
            }
        }
        return "";
    }
}

//Lớp JsonHelper giúp chuyển đổi mảng đối tượng thành chuỗi JSON và ngược lại
//Unity’s JsonUtility chỉ hỗ trợ trực tiếp việc serialize/deserialize các đối tượng đơn,
//vì vậy JsonHelper được xây dựng để hỗ trợ các mảng và danh sách.
public static class JsonHelper
{

    // Chuyển đổi chuỗi JSON thành mảng các đối tượng kiểu T.
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    //Chuyển đổi một mảng các đối tượng kiểu T thành chuỗi JSON.
    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    // Giống với ToJson<T>(T[] array),
    // prettyPrint là tùy chọn (mặc định là false).
    // Nếu bạn đặt là true, chuỗi JSON sẽ được định dạng dễ đọc
    // hơn với các khoảng trắng và dòng mới.
    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    //Wrapper<T> là một lớp bao bọc (wrapper class) để chứa mảng T[] và
    //giúp chuyển đổi dễ dàng hơn giữa mảng đối tượng và JSON.
    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
