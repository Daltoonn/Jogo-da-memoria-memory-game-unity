using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottaoDerrota : MonoBehaviour
{

    public void ReiniciarJogo()
    {
        // Reinicia a cena atual
        Time.timeScale = 1;
        SceneManager.LoadScene("Jogo01");
    }

    public void Menu()
    {
        // Volta ao menu principal
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
