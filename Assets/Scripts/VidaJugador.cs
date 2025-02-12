using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    public static VidaJugador instance;

    public int vidaMaxima, vidaActual;

    private void Awake() 
    {
        instance = this;
    }

    void Start()
    {
        vidaActual = vidaMaxima;
        UI.instance.barraVida.maxValue = vidaMaxima;
        UI.instance.barraVida.value = vidaActual;
        UI.instance.textoVida.text = "VIDA: " + vidaActual + "/" + vidaMaxima;
    }

    void Update()
    {
        
    }

    public void RecibirDanio(int danio)
    {
        vidaActual -= danio;

        if (vidaActual <= 0)
        {
            gameObject.SetActive(false);

            vidaActual = 0;

            GameManager.instance.MuerteJugador();
        }

        UI.instance.barraVida.value = vidaActual;
        UI.instance.textoVida.text = "VIDA: " + vidaActual + "/" + vidaMaxima;
    }
}
