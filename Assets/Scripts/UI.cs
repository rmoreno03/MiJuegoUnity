using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI : MonoBehaviour
{
    public static UI instance;

    public Slider barraVida;
    public TextMeshProUGUI textoVida, textoMuertes;

    public int enemigosMuertos;

    public Image danio;

    public float danioAlpha = 0.3f, danioFade = 3f;

    public Image cura;

    public float curaAlpha = 0.3f, curaFade = 3f;

    public GameObject pausa;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(danio.color.a != 0)
        {
            danio.color = new Color(danio.color.r, danio.color.g, danio.color.b, Mathf.MoveTowards(danio.color.a, 0f, danioFade * Time.deltaTime));
        }

        if(cura.color.a != 0)
        {
            cura.color = new Color(cura.color.r, cura.color.g, cura.color.b, Mathf.MoveTowards(cura.color.a, 0f, curaFade * Time.deltaTime));
        }
    }

    public void MostrarDanio()
    {
        danio.color = new Color(danio.color.r, danio.color.g, danio.color.b, 0.3f);
    }

    public void MostrarCura()
    {
        cura.color = new Color(cura.color.r, cura.color.g, cura.color.b, 0.3f);
    }
}
