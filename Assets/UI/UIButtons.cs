using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UIButtons : MonoBehaviour
{
    public GameObject playCanvas;
    public GameObject MainMenuCanvas;
    public GameObject CreditsCanvas;
    public GameObject HowToPlayCanvas;
    public void OnPlayClicked()
    {
        playCanvas.SetActive(true);
        MainMenuCanvas.SetActive(false);
    }
   
  


    public void OnCreditsClicked()
    {
        CreditsCanvas.SetActive(true);
        MainMenuCanvas.SetActive(false);
    }

   
    public void OnHowToPlayClicked()
    {
        HowToPlayCanvas.SetActive(true);
        MainMenuCanvas.SetActive(false);
    }

    public void OnBackClicked()
    {
       
        playCanvas.SetActive(false);
        CreditsCanvas.SetActive(false);
        
        HowToPlayCanvas.SetActive(false);
        MainMenuCanvas.SetActive(true);
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }
    
    public void OnLevel1Clicked()
    {
        
        SceneManager.LoadScene("Level1");
    }
    public void OnLevel2Clicked()
    {

        SceneManager.LoadScene("Level2");
    }
    public void OnLevel3Clicked()
    {

        SceneManager.LoadScene("Level3");
    }

}
