using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class TotalData
{
    public int confirmed { get; set; }
    public int deaths { get; set; }
    public int recovered { get; set; }
    public string dt { get; set; }
    public double ts { get; set; }
}
