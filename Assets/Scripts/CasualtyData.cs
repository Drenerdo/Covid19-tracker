using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class CasualtyData
{
    public List<Death> deaths;
}

[Serializable]
public class Death
{
    public List<Latest> latests;
}

[Serializable]
public class Latest
{
    public int confirmed;
    public int deaths;
    public int recoverd;
}
