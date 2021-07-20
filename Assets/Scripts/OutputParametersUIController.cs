using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OutputParametersUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PeakTimeText;
    [SerializeField] TextMeshProUGUI SettlingTimeText;
    [SerializeField] TextMeshProUGUI OSText;

    private SpringController springCon;
    private DamperController damperCon;
    private MassController massCon;

    // Start is called before the first frame update
    void Start()
    {
        springCon = FindObjectOfType<SpringController>();
        damperCon = FindObjectOfType<DamperController>();
        massCon = FindObjectOfType<MassController>();
    }

    public void UpdateUI(double peakTime, double settlingTime, double OS)
    {
        string peakTimeString = peakTime.ToString("F2");
        string settlingTimeString = settlingTime.ToString("F2");
        string OSString = OS.ToString("F2");

        PeakTimeText.text = "Peak Time: " + peakTimeString;
        SettlingTimeText.text = "Settling Time: " + settlingTimeString;
        OSText.text = "% OS: " + OSString;
    }
}
