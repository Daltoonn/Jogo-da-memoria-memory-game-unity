using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonVitoriaAterro : MonoBehaviour
{
 
     public void Menu()
    {
        // Volta ao menu principal
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

}