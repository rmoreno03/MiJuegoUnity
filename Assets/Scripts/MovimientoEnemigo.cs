using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoEnemigo : MonoBehaviour
{
    public float velocidadMovimiento, distanciaDetenerse;
    private Vector3 objetivo;

    public NavMeshAgent agente;

    public GameObject proyectil;
    public Transform puntoDisparo;

    public float velocidadDisparo;
    private float contadorDisparo;

    public Animator animador;

    void Start()
    {
        
    }

    void Update()
    {
        objetivo = PlayerMove.instance.transform.position;

        // Moverse hacia el jugador si está lejos
        if (Vector3.Distance(transform.position, objetivo) > distanciaDetenerse)
        {
            agente.destination = objetivo;
        }
        else
        {
            agente.destination = transform.position;
        }

        contadorDisparo -= Time.deltaTime;

        if (contadorDisparo <= 0)
        {
            contadorDisparo = velocidadDisparo;

            puntoDisparo.LookAt(PlayerMove.instance.transform.position + new Vector3(0f, 1.7f, 0f));

            Vector3 direccionObjetivo = PlayerMove.instance.transform.position - transform.position;
            float angulo = Vector3.SignedAngle(transform.forward, direccionObjetivo, Vector3.up);

            if (Mathf.Abs(angulo) < 45f)
            {
                Instantiate(proyectil, puntoDisparo.position, puntoDisparo.rotation);
                animador.SetTrigger("disparar");
            }
            else
            {
                agente.destination = objetivo;
            }
        }

        // Control de animaciones
        if (agente.remainingDistance < 0.3f)
        {
            animador.SetBool("moviendose", false);
        }
        else
        {
            animador.SetBool("moviendose", true);
        }
    }
}

