using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damper : TranslationalComponent
{
    public float DampingRatio = 1f;

    // Constructor
    public Damper(string name) : base(name) { }
}
