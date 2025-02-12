using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArañas : MonoBehaviour
{

    public GameObject enemigo;

    public float tiempo;
    private float contador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contador -= Time.deltaTime;

        if(contador <= 0)
        {
            contador = tiempo;

            Instantiate(enemigo, transform.position, transform.rotation);
        }
    }
}
