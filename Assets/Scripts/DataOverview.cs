using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class DataOverview
{
    public int latest;
    public List<Location> locations;

}


[Serializable]
public class Coordinates
{
    public string lat;
    public string @long;
}




[Serializable]
public class Location
{
    public List<Coordinates> coordinates;
    public string country;
    //public History history { get; set; }
    public int latest;
    public string province;
}


