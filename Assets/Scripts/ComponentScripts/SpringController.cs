using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpringController : MonoBehaviour
{
    [SerializeField] float Stiffness = 1f;

    [Header("Scaling Properties")]
    [SerializeField] GameObject MotorHoldPoint;
    [SerializeField] GameObject MassHoldPoint;

    private LaplaceTransform laplace;
    private LineRenderer rend;
    Vector3 startPos;
    public Spring spring;
    private bool countingUp = true;
    private int index = 0;

    private void Awake()
    {
        laplace = FindObjectOfType<LaplaceTransform>();
        rend = GetComponent<LineRenderer>();
        spring = new Spring("Spring");
        rend.useWorldSpace = true;
        spring.Stiffness = .8f;
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
        Debug.Log("Animating : " + spring.bIsAnimating);
        if (spring.bIsAnimating)
        {
            AnimateSpring();
        }
    }

    public void SetStiffness(float value)
    {
        if(spring == null)
        {
            throw new NullReferenceException("Spring object is null");
        }
        spring.Stiffness = value;
    }

    public float GetStiffness()
    {
        return spring.Stiffness;
    }

    private void AnimateSpring()
    {        
        /*if (countingUp && index > spring.PositionArray.Count - 1)
        {
            countingUp = false;
            index -= 2;
        }
        if (!countingUp && index < 0)
        {
            countingUp = true;
            index = 1;
        }

        Vector3 springPos = startPos;
        springPos.z = (float)spring.PositionArray[index] + startPos.z;

        if (hasNaN(springPos))
        {
            throw new NullReferenceException("springPos has NaN");
        }*/

        rend.SetPosition(0, MotorHoldPoint.transform.position);
        rend.SetPosition(1, MassHoldPoint.transform.position);

        /*
        if (countingUp)
        {
            index++;
        }
        else if (!countingUp)
        {
            index--;
        }*/
    }

    private bool hasNaN(Vector3 vec)
    {
        if (float.IsNaN(vec.x))
        {
            return true;
        }
        else if (float.IsNaN(vec.y))
        {
            return true;
        }
        else if (float.IsNaN(vec.z))
        {
            return true;
        }
        return false;
    }

    public void GenerateArrays()
    {
        //spring.TimeArray = GameManager.GlobalTimeArray;
        //spring.PositionArray = GameManager.GlobalPositionArray;
    }

    public void StartAnimation()
    {
        spring.bIsAnimating = true;
        /*if(spring.TimeArray.Count == 0 || spring.PositionArray.Count == 0)
        {
            throw new Exception("Spring arrays are empty!");
        }*/
    }

    public void StopAnimation()
    {
        spring.bIsAnimating = false;
    }
}