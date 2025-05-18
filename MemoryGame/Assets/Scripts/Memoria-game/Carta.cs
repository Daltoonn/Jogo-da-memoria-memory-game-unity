using UnityEngine;

public class Carta : MonoBehaviour
{
    public Sprite frente;
    public Sprite verso;
    private SpriteRenderer spriteRenderer;
    public bool estaVirada = false;
    private bool bloqueada = false;
    private GerenciadorDeJogo gerenciador;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //aparentemente nao faz diferença se esta ativado ou nao spriteRenderer.sprite = verso;
        VirarCarta();
        Invoke("VirarCarta", 4f); 
        MostrarFrente();
        gerenciador = FindObjectOfType<GerenciadorDeJogo>();
    }

    void OnMouseDown()
    {
        if (!bloqueada)
        {
            gerenciador.SelecionarCarta(this);
        }
    }

    public void VirarCarta()
    {
        estaVirada = !estaVirada;
        spriteRenderer.sprite = estaVirada ? frente : verso;
    }

    public void MostrarFrente()
    {
        estaVirada = true;
        spriteRenderer.sprite = frente;
    }

    public void BloquearCarta()
    {
        bloqueada = true;
    }
}