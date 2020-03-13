<<<<<<< HEAD
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
=======
﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine.UI;
>>>>>>> origin/develop

public class DataManager : DataDisplayController
{
    public static DataManager _instance;

    void Start()
    {
        StartCoroutine(getCurrent());
        StartCoroutine(getTotal());
        StartCoroutine(getRecovered());
        StartCoroutine(getCountries());

<<<<<<< HEAD
        StartCoroutine(getImage());

=======
        StartCoroutine(getImage());

        // For Text display
        total_count_display = GameObject.FindGameObjectWithTag("total_data_display_label").GetComponent<Text>();
        confirmed_count_display = GameObject.FindGameObjectWithTag("confirmed_data_display_label").GetComponent<Text>();
        recovered_count_display = GameObject.FindGameObjectWithTag("recovered_data_display_label").GetComponent<Text>();
        causalty_count_display = GameObject.FindGameObjectWithTag("causalty_data_display_label").GetComponent<Text>();

>>>>>>> 50753c44a5a54eac42bf4690a47dbf66e15da077
    }

    IEnumerator getImage()
    {
        //UnityWebRequest www = UnityWebRequest.GetTexture("https://covid2019-api.herokuapp.com/total");
        //Debug.Log("Start");

        //yield return www;

        //Debug.Log("Loaded");
        //Texture2D texture = www.texture;
        ////this.gameObject.GetComponent<>().material.SetTexture( 0,texture );
        //Image img = this.gameObject.GetComponent<Image>();
        //img.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture("https://flagpedia.net/download/country-codes-case-upper.json"))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                // Get downloaded asset bundle
                var texture = DownloadHandlerTexture.GetContent(uwr);

                Debug.Log(texture);
            }
        }
    }

    IEnumerator getTotal()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://covid2019-api.herokuapp.com/total");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {


            byte[] results = www.downloadHandler.data;

            if (www.isDone)
            {
                string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                Debug.Log(jsonResult);

                TotalData totalData = JsonUtility.FromJson<TotalData>(jsonResult);

                Debug.Log(" Here are the confirmed cases " + totalData.confirmed);
                Debug.Log(" Here are the recovered cases " + totalData.recovered);
                Debug.Log(" Here are the casualities " + totalData.deaths);

                total_count_display.text = totalData.confirmed.ToString();
                



                //DataTypeVisualizer dataType = JsonUtility.FromJson<DataTypeVisualizer>(jsonResult);
            }
        }
    }

    IEnumerator getCurrent()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://covid2019-api.herokuapp.com/current");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {


            byte[] results = www.downloadHandler.data;

            if (www.isDone)
            {
                string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                Debug.Log(jsonResult);

                DataTypeVisualizer dataType = JsonUtility.FromJson<DataTypeVisualizer>(jsonResult);
                Debug.Log("Getting current data!");

                Debug.Log(dataType.Mainland_China);

                foreach(MainlandChina china in dataType.Mainland_China)
                {
                    Debug.Log("Confirmed from china" + china.confirmed);
                    Debug.Log("Deaths from china" + china.deaths);
                    Debug.Log("Recovered from china" + china.recovered);
                }
            }
        }
    }

    IEnumerator getRecovered()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://covid2019-api.herokuapp.com/recovered");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            byte[] results = www.downloadHandler.data;

            if (www.isDone)
            {
                string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                Debug.Log(jsonResult);

                //DataTypeVisualizer dataType = JsonUtility.FromJson<DataTypeVisualizer>(jsonResult);

                //Debug.Log(dataType.recovered);
                //Debug.Log(dataType.dt);
                //Debug.Log(dataType.ts);
            }
        }
    }

    IEnumerator getCountries()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://covid2019-api.herokuapp.com/countries");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            byte[] results = www.downloadHandler.data;

            if (www.isDone)
            {
                string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                Debug.Log(jsonResult);

                //DataTypeVisualizer dataType = JsonUtility.FromJson<DataTypeVisualizer>(jsonResult);

                //Debug.Log(dataType.recovered);
                //Debug.Log(dataType.dt);
                //Debug.Log(dataType.ts);
            }
        }
    }

    IEnumerator getconfirmed()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://covid2019-api.herokuapp.com/deaths");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {


            byte[] results = www.downloadHandler.data;

            if (www.isDone)
            {
                string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                Debug.Log(jsonResult);

                //DataTypeVisualizer dataType = JsonUtility.FromJson<DataTypeVisualizer>(jsonResult);

                //Debug.Log(dataType.recovered);
                //Debug.Log(dataType.dt);
                //Debug.Log(dataType.ts);
            }

        }
    }
}
