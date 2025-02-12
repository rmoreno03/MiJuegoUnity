using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botiquin : MonoBehaviour
{
    public int cura;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            VidaJugador.instance.Curar(cura);

            Destroy(gameObject);
        }
    }
}
