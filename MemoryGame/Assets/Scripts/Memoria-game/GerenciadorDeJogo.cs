using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GerenciadorDeJogo : MonoBehaviour
{
    public Carta[] cartas;           // Todas as cartas na cena
    public Text jogadasRestantesUI;  // Texto na UI para mostrar jogadas restantes
    public GameObject telaVitoria;   // Tela de vitória
    public GameObject telaDerrota;   // Tela de derrota
    private Carta cartaSelecionada1 = null;
    private Carta cartaSelecionada2 = null;
    private int jogadasRestantes = 10; // Limite de jogadas
    private bool podeJogar = true;
    private int paresEncontrados = 0;

    void Start()
    {
        // Inicializa o jogo mostrando todas as cartas brevemente
        StartCoroutine(MostrarTodasCartas());
        AtualizarJogadasUI();
    }

    void Update()
    {
        AtualizarJogadasUI();
    }

    public void SelecionarCarta(Carta carta)
    {
        if (!podeJogar || jogadasRestantes <= 0 || carta.estaVirada) return; // Impede jogadas se o limite for atingido

        if (cartaSelecionada1 == null)
        {
            cartaSelecionada1 = carta;
            carta.VirarCarta();
        }
        else if (cartaSelecionada2 == null)
        {
            cartaSelecionada2 = carta;
            carta.VirarCarta();
            jogadasRestantes--;
            AtualizarJogadasUI();

            if (cartaSelecionada1.tag == cartaSelecionada2.tag)
            {
                cartaSelecionada1.BloquearCarta();
                cartaSelecionada2.BloquearCarta();
                ResetarSelecao();
                paresEncontrados++;
                jogadasRestantes++;
                VerificarVitoria();
            }
            else
            {
                StartCoroutine(EsconderCartas());
            }
        }
    }

    IEnumerator EsconderCartas()
    {
        podeJogar = false;
        yield return new WaitForSeconds(1f);
        cartaSelecionada1.VirarCarta();
        cartaSelecionada2.VirarCarta();
        ResetarSelecao();
        podeJogar = true;

        if (jogadasRestantes <= 0)
        {
            SceneManager.LoadScene("Derrota");
        }
    }

    private void ResetarSelecao()
    {
        cartaSelecionada1 = null;
        cartaSelecionada2 = null;
    }

    IEnumerator MostrarTodasCartas()
    {
        foreach (Carta carta in cartas)
        {
            carta.MostrarFrente();
        }

        yield return new WaitForSeconds(2f);

        foreach (Carta carta in cartas)
        {
            carta.VirarCarta();
        }
    }

    private void AtualizarJogadasUI()
    {
        jogadasRestantesUI.text = "Tentativas: " + jogadasRestantes;
    }

    private void VerificarVitoria()
    {
        if (paresEncontrados == 10)
        {
            SceneManager.LoadScene("Victoryy");
        }
    }

    private void MostrarTelaDerrota()
    {
        telaDerrota.SetActive(true);
    }

    public void ReiniciarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ProximoNivel()
    {
        // Aqui você pode adicionar a lógica para carregar a próxima cena
        SceneManager.LoadScene("ProximoNivel");
    }

}
