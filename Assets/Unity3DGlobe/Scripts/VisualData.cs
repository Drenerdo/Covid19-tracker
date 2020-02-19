using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualData : MonoBehaviour
{
    [Header("All Data")]
    public string jsonURL = "";

    [Header("Confimed Data")]
    public string confirmedURL = "";

    [Header("Confimed Data")]
    public string casualtyDataURL = "";


    [Header("Data Layout")]
    public Text latest_label;
    public Text country_label;
    public Text province_label;


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

            //latest_label.text = l.latest.ToString();

            //country_label.text = l.country.ToString();

            //province_label.text = l.province.ToString();

            if(l.country == "US")
            {
                latest_label.text = l.latest.ToString();

                country_label.text = l.country.ToString();

                province_label.text = l.province.ToString();
            }
        }

    }

    void parsingCasualtyData(string _url)
    {
        CasualtyData casualtyData = JsonUtility.FromJson<CasualtyData>(_url);

    }
}
