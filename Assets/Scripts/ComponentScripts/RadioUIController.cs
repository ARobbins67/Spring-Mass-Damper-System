using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean;
using Lean.Gui;

public class RadioUIController : MonoBehaviour
{
    [SerializeField] SpringController springCon;
    [SerializeField] DamperController damperCon;
    [SerializeField] MassController massCon;
    
    private GameManager gameMan;
    private LeanToggle leanToggle;

    // Start is called before the first frame update
    void Start()
    {
        gameMan = FindObjectOfType<GameManager>();    

        springCon.SetStiffness(20);
        damperCon.SetDampingRatio(1);
        massCon.SetWeight(10);
    }

    public void SetSpringStiffness(float value)
    {
        gameMan.ResetTimer();
        springCon.SetStiffness(value);
    }

    public void SetDampingCoefficient(float value)
    {
        gameMan.ResetTimer();
        damperCon.SetDampingRatio(value);
    }

    public void SetMassWeight(float value)
    {
        gameMan.ResetTimer();
        massCon.SetWeight(value);
    }
}
