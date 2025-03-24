using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerController jugador;
    GameManager manager;
    [SerializeField] private float velocidad = 20f;
    float tiempoVida = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoDestruccion());
        rb = GetComponent<Rigidbody2D>();
        jugador = FindAnyObjectByType<PlayerController>();
        manager = FindAnyObjectByType<GameManager>();
        velocidad = jugador.transform.localScale.x * velocidad;
    }

    // Update is called once per frame
    void Update()
    {
        //Rotación de la felcha
        //transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), Mathf.Sign(rb.velocity.x));
        rb.velocity = new Vector2(velocidad, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            manager.ActualizaEnemigos();
            Destroy(other.gameObject);
        }
        Destroy(this.gameObject);
    }

    IEnumerator AutoDestruccion()
    {
        yield return new WaitForSeconds(tiempoVida);

        Destroy(this.gameObject);

    }
}
