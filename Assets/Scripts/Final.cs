using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Final : MonoBehaviour
{
    public string menu;

    public TextMeshProUGUI muertos;

    public static Final instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Final.instance.muertos.text = "ENEMIGOS MUERTOS: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        Final.instance.muertos.text = "ENEMIGOS MUERTOS: " + GameManager.instance.muertes;
    }

    public void Menu()
    {
        SceneManager.LoadScene(menu);
    }
    
}
