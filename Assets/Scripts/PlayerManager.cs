using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{    
    private RigidbodyFirstPersonController fpController;
    
    private void Awake()
    {
        fpController = GetComponent<RigidbodyFirstPersonController>();
    }

    private void Start()
    {
        FreezeFirstPersonController();
    }

    public void UnfreezeFirstPersonController()
    {
        Cursor.visible = false;
        fpController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void FreezeFirstPersonController()
    {
        fpController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    } 
}