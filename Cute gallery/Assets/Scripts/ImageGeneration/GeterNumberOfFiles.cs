using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GeterNumberOfFiles : MonoBehaviour
{
    const string URL = "http://data.ikppbb.com/test-task-unity-data/pics/";
    const string JPG = ".jpg";

    private static int _fileCount;

    private static GeterNumberOfFiles Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);

        StartCoroutine(CountFilesInDirectory());

    }

    public static int GetFilesCount()
    { 
        return _fileCount;
    }

    private void SetFilesCount(int numOfFiles)
    {
        _fileCount = numOfFiles;
    }

    // делал парсер для получения количества файлов, но в билдах он почему-то не работает


    //private int CountFilesInDirectory(string serverAddress, string directoryPath)
    //{
    //    int fileCount = 0;

    //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serverAddress + "/" + directoryPath);
    //    request.Method = "GET";

    //    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    //    using (Stream stream = response.GetResponseStream())
    //    using (StreamReader reader = new StreamReader(stream))
    //    {
    //        string line;
    //        while ((line = reader.ReadLine()) != null)
    //        {
    //            if (line.Contains(".jpg"))
    //            {
    //                string fileName = line.Substring(line.IndexOf(">") + 1).TrimEnd('/');
    //                if (!fileName.StartsWith("."))
    //                {
    //                    fileCount++;
    //                }
    //            }
    //        }
    //    }

    //    return fileCount;
    //}


    private IEnumerator CountFilesInDirectory()
    {
        int fileCount = 0;

        for (int i = 1; true; i++)
        {
            string url = URL + i + JPG;
            UnityWebRequest webRequest = UnityWebRequest.Head(url);

            yield return webRequest.SendWebRequest();

            if (webRequest.error != null)
            {
                break;
            }
            else
            {
                fileCount++;
            }

            SetFilesCount(fileCount);
        }
    }
}
