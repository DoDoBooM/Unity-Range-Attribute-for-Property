using System.Collections;
using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class RangeProperty : PropertyAttribute
{
    public string propertyName { get; private set; }
    public float min { get; private set; }
    public float max { get; private set; }
    public bool dirty { get; set; }
    public RangeProperty(string propertyName, float min, float max)
    {
        this.propertyName = propertyName;
        this.min = min;
        this.max = max;
    }
}
