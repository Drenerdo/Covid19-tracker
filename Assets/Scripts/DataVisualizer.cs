using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class DataVisual : MonoBehaviour
{
    [Header("")]
    public string confirmedData = "";

    [Header("")]
    public string casualityData = "";

    [Header("")]
    public string allData = "";

    [Header("")]
    public Text countryText;
    public Text latestText;
    public Text provinceText;


    void Start()
    {
        StartCoroutine(getData());
    }

    IEnumerator getData()
    {
        Debug.Log("Parsing your data!");

        WWW _www = new WWW(confirmedData);
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

            if (l.country == "US" && l.province == "")
            {
                countryText.text = l.country.ToString();
                latestText.text = l.latest.ToString();
                provinceText.text = l.province.ToString();
            }
        }

        //foreach(confirmed c in dataOverview.confirmed)
        //{
        //    Debug.Log(c.latest);
        //}
    }
}
