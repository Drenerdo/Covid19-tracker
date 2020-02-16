using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class DataOverview
{
    public List<confirmed> confirmed;
    public List<locationlist> location;

}

[Serializable]
public class confirmed
{
    public int latest;
    public List<Location> locations;
}

[Serializable]
public class locationlist
{
    public string country;
    public int latest;
    public string province;
}



