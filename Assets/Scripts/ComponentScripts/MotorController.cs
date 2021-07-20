using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MotorController : MonoBehaviour
{
    [SerializeField] float Force = 1f;

    // private GameObject InnerShaft;
    private Vector3 shaftPos;
    private float startOffset;
    private LaplaceTransform laplace;
    private List<double> ShaftPositionList = new List<double>();
    private int i = 0;
    private bool countingUp = true;
    private float ForceMagnitude = .5f;

    // Start is called before the first frame update
    void Start()
    {
        laplace = FindObjectOfType<LaplaceTransform>();
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // AnimateShaft();                
        
        //Push
    }

    // animate shaft (must loop at the end of the list)
    private void AnimateShaft()
    {
        if (countingUp && i > ShaftPositionList.Count - 1)
        {
            countingUp = false;
            i -= 2;
        }
        if (!countingUp && i < 0)
        {
            countingUp = true;
            i = 1;
        }

        shaftPos.x = (float)ShaftPositionList[i];
        //InnerShaft.transform.localPosition = new Vector3(shaftPos.x, 0, 0);
        // Debug.Log("i: " + i + ", pos: " + shaftPos.x + ", countingUp: " + countingUp);

        if (countingUp)
        {
            i++;
        }
        else if (!countingUp)
        {
            i--;
        }
    }

    public float GetForce()
    {
        return Force;
    }

    public void SetForce(float value)
    {
        ForceMagnitude = value;
        Debug.Log("New force magnitude: " + value);
    }
}
