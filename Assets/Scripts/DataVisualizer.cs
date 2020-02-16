using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataVisualizer : MonoBehaviour
{
    public string WEB_URL = "";

    void Start()
    {
        StartCoroutine(DataManager.Instance.Get(WEB_URL));
    }

    void GetConfirmedCases(DataOverview dataOverview)
    {
        //foreach(confirmedList c in dataOverview.confirmed)
        //{

        //}
    }
}
