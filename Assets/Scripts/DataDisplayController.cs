using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataDisplayController : MonoBehaviour
{
    [Header("Total Display")]
    public Text total_count_display;

    [Header("Confirmed Display")]
    public Text confirmed_count_display;

    [Header("Causality Display")]
    public Text causalty_count_display;

    [Header("Recovered Display")]
    public Text recovered_count_display;

    void Start()
    {
        //total_count_display = GameObject.FindGameObjectWithTag("total_data_display_label").GetComponent<Text>();

        //total_count_display = GameObject.FindWithTag("Total_Data_Value").GetComponent<Text>();
    }



}
