using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float espera = 3f;

    public int muertes;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Evita duplicados
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pausa();
        }
    }


    public void Pausa()
    {
        if(UI.instance.pausa.activeInHierarchy)
        {
            UI.instance.pausa.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;

            Time.timeScale = 1f;
        }
        else
        {
            UI.instance.pausa.SetActive(true);
        
            Cursor.lockState = CursorLockMode.None;

            Time.timeScale = 0f;
        }
    }
}
