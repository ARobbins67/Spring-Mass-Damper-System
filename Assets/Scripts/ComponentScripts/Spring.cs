using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : TranslationalComponent
{
    public float Stiffness = 1f;

    // Constructors
    public Spring(string name) : base(name) { } 
}
