using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    public int ActualPhase;

    private void Start()
    {
        if(ActualPhase > 0 && ActualPhase < 4)
        {
            PlayerPrefs.SetInt("FASE", ActualPhase);
        }
    }

    public void Phase (int numberPhase)
    {
        SceneManager.LoadScene(numberPhase);
    }

    public void PassPhase()
    {
        int pPhase = ActualPhase + 1;
        SceneManager.LoadScene(pPhase);
    }

    public void GoToSavedPhase()
    {
        int fSave = PlayerPrefs.GetInt("FASE");
        SceneManager.LoadScene(fSave);
    }

    public void WinPhase()
    {
        //SceneManager.LoadScene(YouWin);
    }

    public void LostPhase()
    {
        //SceneManager.LoadScene(YouDie);
    }
}
