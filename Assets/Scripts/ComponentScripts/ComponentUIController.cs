using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ComponentUIController : MonoBehaviour
{
    [SerializeField] UnityEvent OnShowComponentMenu;
    [SerializeField] UnityEvent OnHideComponentMenu;

    private GameManager gameMan;
    //private static bool bIsPaused = false;

    private void Start()
    {
        gameMan = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameMan.bIsCounting = !gameMan.bIsCounting;
            Debug.Log("Counting: " + gameMan.bIsCounting);
            if (!gameMan.bIsCounting)
            {
                gameMan.StopAllAnimations();
                OnShowComponentMenu.Invoke();
            }
            else if (gameMan.bIsCounting)
            {
                gameMan.GenerateTimeArray();
                gameMan.CreateSinusoidal();
                gameMan.CalculateOutputParameters();
                gameMan.StartAllAnimations();
                OnHideComponentMenu.Invoke();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public bool IsPaused()
    {
        return gameMan.bIsCounting;
    }
}