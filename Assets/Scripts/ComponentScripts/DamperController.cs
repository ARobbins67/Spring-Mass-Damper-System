using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamperController : MonoBehaviour
{
    [SerializeField] float DampingRatio = 1f;
    [SerializeField] GameObject MotorHoldPoint;
    [SerializeField] GameObject MassHoldPoint;

    private LineRenderer rend;
    public Damper damper;
    private int index = 0;
    private bool countingUp = true;
    private float startOffset;
    private List<double> DamperPositionList = new List<double>();
    Vector3 startPos;
    bool bIsAnimating = false;

    private void Awake()
    {
        damper = new Damper("Damper01");
        rend = GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //startPos = transform.position;
        rend.useWorldSpace = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bIsAnimating)
        {
            AnimateDamper();
        }
    }

    public void GenerateArrays()
    {
        //damper.TimeArray = GameManager.GlobalTimeArray;
        // damper.PositionArray = GameManager.GlobalPositionArray;
    }

    private void AnimateDamper()
    {
        /*if (countingUp && index > damper.PositionArray.Count - 1)
        {
            countingUp = false;
            index -= 2;
        }
        if (!countingUp && index < 0)
        {
            countingUp = true;
            index = 1;
        }

        ObjectsToStayWithMotor.transform.position = MotorHoldPoint.transform.position;
        ObjectsToStayWithMass.transform.position = MassHoldPoint.transform.position;

        Vector3 newScale = Vector3.one;
        newScale.z = ObjectsToStayWithMass.transform.position.z - ObjectsToStayWithMotor.transform.position.z;
        ObjectsToScale.transform.position = new Vector3(ObjectsToStayWithMass.transform.position.x, ObjectsToStayWithMass.transform.position.y, ObjectsToScale.transform.position.z);
        ObjectsToScale.transform.localScale = newScale;

        if (countingUp)
        {
            index++;
        }
        else if (!countingUp)
        {
            index--;
        }*/

        rend.SetPosition(0, MotorHoldPoint.transform.position);
        rend.SetPosition(1, MassHoldPoint.transform.position);
    }

    public void StartAnimation()
    {
        bIsAnimating = true;
    }

    public void StopAnimation()
    {
        bIsAnimating = false;
    }

    public void SetDampingRatio(float value)
    {
        damper.DampingRatio = value;
    }

    public float GetDampingRatio()
    {
        return damper.DampingRatio;
    }
}