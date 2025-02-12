using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaJugador : MonoBehaviour
{
    public static VidaJugador instance;

    public int vidaMaxima, vidaActual;

    public float tiempoFinal = 1f;

    public string final;

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

        UI.instance.MostrarDanio();

        if (vidaActual <= 0)
        {

            vidaActual = 0;

            StartCoroutine(PantallaFinal());

        }

        UI.instance.barraVida.value = vidaActual;
        UI.instance.textoVida.text = "VIDA: " + vidaActual + "/" + vidaMaxima;
    }

    public void Curar(int cura)
    {
        vidaActual += cura;

        UI.instance.MostrarCura();

        if(vidaActual > vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }

        UI.instance.barraVida.value = vidaActual;
        UI.instance.textoVida.text = "VIDA: " + vidaActual + "/" + vidaMaxima;
    }

    public IEnumerator PantallaFinal()
    {
        yield return new WaitForSeconds(tiempoFinal);

        SceneManager.LoadScene(final);

        Cursor.lockState = CursorLockMode.None;

    }
}
