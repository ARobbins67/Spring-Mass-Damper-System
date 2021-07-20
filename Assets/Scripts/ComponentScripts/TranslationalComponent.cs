using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationalComponent
{
    public List<double> TimeArray = new List<double>();
    public List<double> PositionArray = new List<double>();
    public bool bIsAnimating = false;

    public string Name;
    private LaplaceTransform Laplace;

    /*public void GenerateTimeArray(float t_start, float t_step, float t_end)
    {
        TimeArray = Laplace.GenerateTimeArray(t_start, t_step, t_end);
    }

    public void GeneratePositionArray()
    {
        PositionArray = Laplace.GeneratePositionArray(TimeArray);
    }*/

    // Constructors
    public TranslationalComponent(string name){
        Laplace = Object.FindObjectOfType<LaplaceTransform>();
        Name = name;
    }
}
