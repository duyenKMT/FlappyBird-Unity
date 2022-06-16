using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject CreditUI;
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void openCredit()
    {
        CreditUI.SetActive(true); // b?t credit lên
    }

    public void closeCredit()
    {
        CreditUI.SetActive(false); // t?t credit
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
   
}
