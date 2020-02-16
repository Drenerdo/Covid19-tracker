using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DataManager : MonoBehaviour
{
    private static DataManager _instance;

    public static DataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DataManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = typeof(DataManager).Name;
                    _instance = go.AddComponent<DataManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return _instance;
        }
    }

    public IEnumerator Get(string url)
    {
        using(UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if(www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);

                    //DataOverview dataOverview = JsonUtility.FromJson<DataOverview>(jsonResult);

                    ConfirmedCases confirmedCases = JsonUtility.FromJson<ConfirmedCases>(jsonResult);


                    Debug.Log(jsonResult);
                }
            }
        }
    }
}
