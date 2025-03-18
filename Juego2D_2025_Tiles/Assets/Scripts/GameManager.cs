using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoVidas;
    [SerializeField] TextMeshProUGUI textoTiempo;

    [SerializeField] int numeroVidas = 3;
    float tiempoTranscurrido;

    void Awake()
    {
        int numeroSesiones = FindObjectsOfType<GameManager>().Length;
        if (numeroSesiones > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        textoVidas.text = numeroVidas.ToString();
        tiempoTranscurrido = 0;
        textoTiempo.text = tiempoTranscurrido.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;
        MostrarTiempo();
    }

    void MostrarTiempo()
    {
        float minutos = Mathf.FloorToInt(tiempoTranscurrido / 60);
        float segundos = Mathf.FloorToInt(tiempoTranscurrido % 60);
        textoTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);

    }
    public void MuerteJugador()
    {
    

        if (numeroVidas > 1)
        {
            Invoke("QuitarVidas", 2f);
        }
        else
        {
            Invoke("ResetearGameManager", 2f);
        }
    }

    private void ResetearGameManager()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    void QuitarVidas()
    {
        numeroVidas--;

        //Reseteo Nivel
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual);
        textoVidas.text = numeroVidas.ToString();
        tiempoTranscurrido = 0;
    }


}
