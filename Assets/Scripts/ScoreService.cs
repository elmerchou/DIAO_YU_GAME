using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ScoreService : MonoBehaviour
{



    [SerializeField] InputField ID;
    [SerializeField] int score;

    [SerializeField] Text[] names;



    void Start()
    {
        // Start the coroutine of sending the request to the API url.
        // StartCoroutine(Upload("Bob", 100));
        StartCoroutine(Get());
    }


    public void Use()
    {
        StartCoroutine(Upload(ID.text.ToString(), FindObjectOfType<Session>().GetScore()));
    }


    public IEnumerator Upload(string name, int score)
    {
        // Create the form object.
        WWWForm form = new WWWForm();
        // Add the method data to the form object. (read or write data)
        form.AddField("method", "write");

        // Add the data to the form object. (the data you want to pass to GAS)
        form.AddField("name", name);
        form.AddField("score", score);

        // Sending the request to API url with form object.
        using (UnityWebRequest www = UnityWebRequest.Post("https://script.google.com/macros/s/AKfycbzasO6WPT7qPE7KJAWqvaPK6xKWjwu8fCAraLwpQJCNzNM-MT-uL3n3_S7IxXubeyc/exec", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Done and get the response text.
                string jsonString = www.downloadHandler.text;
                ScoreData[] records = JsonHelper.FromJson<ScoreData>(jsonString);

                Debug.Log("Form upload complete!");
            }
            StartCoroutine(Get());
        }
    }
    public IEnumerator Get()
    {
        WWWForm form = new WWWForm();
        // Add the method data to the form object. (read or write data)
        form.AddField("method", "read");

        // Sending the request to API url with form object.
        using (UnityWebRequest www = UnityWebRequest.Post("https://script.google.com/macros/s/AKfycbzasO6WPT7qPE7KJAWqvaPK6xKWjwu8fCAraLwpQJCNzNM-MT-uL3n3_S7IxXubeyc/exec", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Done and get the response text.
                string jsonString = www.downloadHandler.text;
                ScoreData[] records = JsonHelper.FromJson<ScoreData>(jsonString);
                for (int i = 0; i < records.Length; i++)
                {
                    Debug.Log(records[i].name + ", " + records[i].score);
                }

                names[0].text = records[0].name;
                names[1].text = records[0].score.ToString();
                names[2].text = records[1].name;
                names[3].text = records[1].score.ToString();
                names[4].text = records[2].name;
                names[5].text = records[2].score.ToString();
                yield return records;
            }
        }
    }
}

[Serializable]
public class ScoreData
{
    public string name;
    public int score;
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}