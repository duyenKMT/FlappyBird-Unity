using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class _gameManager : MonoBehaviour
{
    public void ToMenuGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
