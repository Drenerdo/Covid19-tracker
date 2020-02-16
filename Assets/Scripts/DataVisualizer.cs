using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class DataVisual : MonoBehaviour
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
        if(_www.error == null)
        {
            parsingData(_www.text);
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

        foreach (Location l in dataOverview.locations)
        {
            Debug.LogError("Parsing through this!");
            Debug.Log(l.latest);
            Debug.Log(l.country);
            Debug.Log(l.province);
        }

        //foreach(confirmed c in dataOverview.confirmed)
        //{
        //    Debug.Log(c.latest);
        //}
    }
}
