using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public int vidaActual;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void recibirDanio(int danio){
        vidaActual -= danio;

        if(vidaActual <= 0)
        {
            Destroy(gameObject);
        }
    }
}
