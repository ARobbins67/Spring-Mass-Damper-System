using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Time Attributes")]
    public float StartTime;
    public float TimeStep;
    public float EndTime;

    [SerializeField] TextMeshProUGUI TimeText;

    //[HideInInspector] public static List<double> GlobalTimeArray = new List<double>();
    [HideInInspector] public static List<double> GlobalPositionArray = new List<double>();

    private SpringController springCon; 
    private DamperController damperCon;
    private MassController massCon;
    private MotorController motorCon;
    public bool bIsCounting = false;
    public float timer = 0;

    double stiffness;
    double dampingRatio;
    double weight;

    // intermediate values
    double w_N;
    double w_D;
    double zeta;

    // output values
    double settlingTime;
    double peakTime;
    double percentOS;

    string Z1, Z2;
    private OutputParametersUIController outputParametersCon;

    private void Awake()
    {
        springCon = FindObjectOfType<SpringController>();
        damperCon = FindObjectOfType<DamperController>();
        massCon = FindObjectOfType<MassController>();
        motorCon = FindObjectOfType<MotorController>();
        outputParametersCon = FindObjectOfType<OutputParametersUIController>();
    }

    public void GenerateTimeArray()
    {
        /*Debug.Log("Generating arrays...");

        double t_start = StartTime;
        double t_step = TimeStep;
        double t_end = EndTime;

        if (t_start <= 0)
        {
            Debug.Log("t_start should not be 0. Reset to .01");
            t_start = .01f;
        }

        double temp = t_start;
        while (temp < t_end)
        {
            GlobalTimeArray.Add(temp);
            temp += t_step;
        }*/
    }

    public void ResetTimer()
    {
        Debug.Log("Reset");
        massCon.index = 0;
        timer = 0;
    }

    public void StartAllAnimations()
    {
        // bIsCounting = true;
        Debug.Log("Starting animations...");
        springCon.GenerateArrays();
        springCon.StartAnimation();
        
        damperCon.GenerateArrays();
        damperCon.StartAnimation();

        massCon.GenerateArrays();
        massCon.StartAnimation();
    }

    public void StopAllAnimations()
    {
        Debug.Log("Stopping animations...");
        springCon.StopAnimation();
        damperCon.StopAnimation();
        massCon.StopAnimation();
        //bIsCounting = false;
    }

    private void FixedUpdate()
    {
        if (bIsCounting)
        {
            timer += Time.fixedDeltaTime;
            TimeText.text = "Time: " + timer.ToString("F2");
            Animate();
        }
    }

    public void CreateSinusoidal()
    {
        stiffness = springCon.GetStiffness();
        dampingRatio = damperCon.GetDampingRatio();
        weight = massCon.GetWeight();

        w_N = System.Math.Sqrt(stiffness / weight);
        zeta = dampingRatio / (2 * weight * w_N);
        w_D = w_N * System.Math.Sqrt(1 - System.Math.Pow(zeta, 2));

        /*for(int i = 0; i < GlobalTimeArray.Count; i++)
        {
            double t = GlobalTimeArray[i];
            double phi = System.Math.Atan(zeta / (System.Math.Sqrt(1 - System.Math.Pow(zeta, 2))));
            double term1 = 1 / (System.Math.Sqrt(1 - System.Math.Pow(zeta, 2)));
            double term2 = System.Math.Exp(-zeta * w_N * t);
            double term3 = System.Math.Cos((w_N * System.Math.Sqrt(1 - System.Math.Pow(zeta, 2))*t) - phi);
            double position = 0 - (term1 * term2 * term3);
            GlobalPositionArray.Add(position);
        }
        if(GlobalPositionArray.Count == 0)
        {
            throw new System.Exception("Global position array is empty");
        }*/

        
        //massCon.Move((float)position);

        //GlobalPositionArray.Add(position);
    }

    private void Animate()
    {
        if(timer > EndTime)
        {
            ResetTimer();
        }
        double phi = System.Math.Atan(zeta / (System.Math.Sqrt(1 - System.Math.Pow(zeta, 2))));
        double term1 = 1 / System.Math.Sqrt(1 - System.Math.Pow(zeta, 2));
        double term2 = System.Math.Exp(-zeta * w_N * timer);
        double term3 = System.Math.Cos((w_N * System.Math.Sqrt(1 - System.Math.Pow(zeta, 2)) * timer) - phi);
        double position = 0 - (term1 * term2 * term3);

        if(timer <= EndTime)
        {
            massCon.Move((float)position);
        }
    }

    public void CalculateOutputParameters()
    {
        peakTime = System.Math.PI / w_D;
        settlingTime = 4 * 1 / (zeta * w_N);
        percentOS = 100*System.Math.Exp((-zeta * System.Math.PI) / System.Math.Sqrt(1-System.Math.Pow(zeta,2)));

        outputParametersCon.UpdateUI(peakTime, settlingTime, percentOS);
    }
}