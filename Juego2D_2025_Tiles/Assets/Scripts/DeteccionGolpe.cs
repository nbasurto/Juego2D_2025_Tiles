using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeteccionGolpe : MonoBehaviour
{
    [SerializeField] ParticleSystem efectoMuerte;
    PlayerController controlador;
    [SerializeField]LayerMask layersMuerte;
    BoxCollider2D cuerpo;
    // Start is called before the first frame update
    void Start()
    {
        controlador = GetComponent<PlayerController>();
        cuerpo = GetComponent<BoxCollider2D>();
    }

   

    private void Update()
    {
        //if (collision.gameObject.CompareTag("Pinchos") || collision.gameObject.CompareTag("Enemigo"))
        if(cuerpo.IsTouchingLayers(layersMuerte))
        {
            Debug.Log("¡El personaje colisiona a un enemigo!");
            controlador.PararControl();
            controlador.Morir();
            efectoMuerte.Play();
            Invoke("cargarEscena", 2f);
        }
    }
    /*void OnTriggerEnter(Collider other)
    {
        if (cuerpo.IsTouchingLayers(layersMuerte))
        {
            Debug.Log("¡El personaje tocó a un enemigo!");
        }
        if (cuerpo.IsTouchingLayers(LayerMask.GetMask("Enemigo", "Pinchos")))
        {
            Debug.Log("¡El personaje tocó a un enemigo 222!");
        }
    }*/

    void cargarEscena()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual);
    }

}
