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
public class Location
{
    //public Coordinates coordinates;
    public string country;
    public int latest;
    public string province;
}


