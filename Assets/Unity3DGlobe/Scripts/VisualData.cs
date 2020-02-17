using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualData : MonoBehaviour
{
    public string jsonURL = "";

    void Start()
    {
        StartCoroutine(getData());
    }

    IEnumerator getData()
    {
        Debug.Log("Parsing your data!");

        WWW _www = new WWW(jsonURL);
        yield return _www;
        if (_www.error == null)
        {
            parsingData(_www.text);
            parsingCasualtyData(_www.text);

        }
        else
        {
            Debug.Log("Oops something went completely wrong!");
        }
    }

    void parsingData(string _url)
    {
        DataOverview dataOverview = JsonUtility.FromJson<DataOverview>(_url);
        Debug.Log(dataOverview.latest);
        //Debug.Log(dataOverview.location);

        Debug.Log(dataOverview.locations);

        //Debug.LogError(dataOverview.deaths);

        foreach (Location l in dataOverview.locations)
        {
            //Debug.LogError("Parsing through this!");
            Debug.Log(l.latest);
            Debug.Log(l.country);
            Debug.Log(l.province);
        }

    }

    void parsingCasualtyData(string _url)
    {
        CasualtyData casualtyData = JsonUtility.FromJson<CasualtyData>(_url);

    }
}
