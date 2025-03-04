using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    [SerializeField] float velocidadEnemigo = 1f;
    Rigidbody2D rb;

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(velocidadEnemigo, 0f);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        velocidadEnemigo = -velocidadEnemigo;
        GirarEnemigo();
    }
    void GirarEnemigo()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), 1f);
    }

}
