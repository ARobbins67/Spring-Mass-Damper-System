using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MassController : MonoBehaviour
{
    [SerializeField] float MassValue = 2f;
    
    private MeshRenderer cubeMesh;
    private GameObject CameraObj;
    private Camera camera;
    private LaplaceTransform laplace;
    private bool countingUp = true;
    public int index = 0;
    private GameManager gameMan;
    Vector3 startPos;
    public Mass mass;
    private bool bIsAnimating = false;

    private void Awake()
    {
        CameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        camera = CameraObj.GetComponent<Camera>();
        gameMan = FindObjectOfType<GameManager>();
        laplace = FindObjectOfType<LaplaceTransform>();
        cubeMesh = GetComponent<MeshRenderer>();

        mass = new Mass("Mass01");
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (bIsAnimating)
        {
            AnimateMass();
        }
    }

    public float GetWeight()
    {
        return mass.Weight; 
    }

    public void GenerateArrays()
    {
        //mass.TimeArray = GameManager.GlobalTimeArray;
        //mass.PositionArray = GameManager.GlobalPositionArray;
    }

    private void AnimateMass() {

        /*if(index > mass.PositionArray.Count-1)
        {
            gameMan.ResetTimer();
        }

        Vector3 massPos = startPos;
        massPos.z = (float)mass.PositionArray[index] + startPos.z;
        transform.position = massPos;

        index++;*/
    }

    public void Move(float zPos)
    {
        Debug.Log("Mass pos: " + zPos);
        Vector3 massPos = startPos;
        massPos.z = zPos+startPos.z;
        transform.position = massPos;
    }

    public void StartAnimation()
    {
        bIsAnimating = true;
    }

    public void StopAnimation()
    {
        bIsAnimating = false;
    }

    public void SetWeight(float value)
    {
        mass.Weight = value;
    }
}