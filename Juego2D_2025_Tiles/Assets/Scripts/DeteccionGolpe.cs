using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeteccionGolpe : MonoBehaviour
{
    [SerializeField] ParticleSystem efectoMuerte;
    PlayerController controlador;
    // Start is called before the first frame update
    void Start()
    {
        controlador = GetComponent<PlayerController>();
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pinchos"))
        {
            controlador.PararControl();
            controlador.Morir();
            efectoMuerte.Play();
            Invoke("cargarEscena", 2f);
        }
    }

    void cargarEscena()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual);
    }

}
