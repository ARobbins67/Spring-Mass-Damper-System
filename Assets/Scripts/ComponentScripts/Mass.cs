using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mass : TranslationalComponent
{
    public float Weight;

    // Constructor
    public Mass(string name) : base(name) { }
}
