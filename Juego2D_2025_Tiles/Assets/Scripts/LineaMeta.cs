using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LineaMeta : MonoBehaviour
{
    [SerializeField] float retardo = 1f;
    [SerializeField] ParticleSystem efectoFinal;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            efectoFinal.Play();
            Invoke("ReloadScene", retardo);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
