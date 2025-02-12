using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed, lifeTime;

    public Rigidbody theRigidbody;

    public int danio;

    public bool damageEnemy, damagePlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        theRigidbody.velocity = transform.forward * bulletSpeed;

        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemigo" && damageEnemy)
        {
            other.gameObject.GetComponent<VidaEnemigo>().recibirDanio(danio);
        }
    
        if(other.gameObject.tag == "Player" && damagePlayer)
        {
            VidaJugador.instance.RecibirDanio(danio);
        }

        Destroy(gameObject);
    }
}
