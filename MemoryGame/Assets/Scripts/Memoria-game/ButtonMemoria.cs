using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMemoria : MonoBehaviour
{
    [SerializeField] private GameObject painelMenu;
    [SerializeField] private GameObject painelGameIV;

    public void AbrirJogo(){
        painelMenu.SetActive(false);
        painelGameIV.SetActive(true);
    }
    
     public void Menu()
    {
        // Volta ao menu principal
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}