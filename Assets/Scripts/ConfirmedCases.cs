using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ConfirmedCases
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
    public Coordinates coordinates;
    public int latest;
    public string province;
}
