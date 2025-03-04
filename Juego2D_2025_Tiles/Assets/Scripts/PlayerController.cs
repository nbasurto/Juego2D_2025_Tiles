using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float velocidadBase = 10;
    [SerializeField] float velocidadCorrer = 20;
    [SerializeField] float cantidadGiro = 10f;
    [SerializeField] float fuerzaSalto = 10;
    float velocidad;
    Rigidbody2D rb;
    CapsuleCollider2D pies;
    public bool tocaSuelo = false;
    SurfaceEffector2D surfaceEffector2D;
    public bool puedeMover = true;

    void Start()
    {
        velocidad = velocidadBase;
        rb = GetComponent<Rigidbody2D>();
        pies = GetComponent<CapsuleCollider2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void FixedUpdate()
    {
        if (puedeMover && tocaSuelo)
        {
            //Acelerar();
            Mover();
            //RotarJugador();
            //Saltar();
        }
    }
    void Update()
    {
        Saltar();
        VolteaSprite();
    }

    private void Saltar()
    {
        if (pies.IsTouchingLayers(LayerMask.GetMask("Plataforma")))
            tocaSuelo = true;
        else
            tocaSuelo = false;

        if (Input.GetButtonDown("Jump") && tocaSuelo)
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }


    }

    public void PararControl()
    {
        puedeMover = false;
    }

    private void RotarJugador()
    {
        float moverHorizontal = Input.GetAxis("Horizontal");
        rb.AddTorque(-cantidadGiro * moverHorizontal);
        /*
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(cantidadGiro);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(-cantidadGiro);
        }*/
    }
    private void VolteaSprite()
    {
        bool seMueve = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if(seMueve)
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
    }

    void Acelerar()
    {
        if (Input.GetKey(KeyCode.LeftControl))
            velocidad = velocidadCorrer;
        else
            velocidad = velocidadBase;

        //surfaceEffector2D.speed = velocidad;
    }
    private void Mover()
    {
        float mover = Input.GetAxis("Horizontal");
        //Sirface effector solo funciona con fuerzas.
        //Vector2 movimiento = new Vector2(mover, 0);
        //rb.AddForce(movimiento * velocidadBase);
        Debug.Log(mover);
        Vector3 movimiento = new Vector3(mover * velocidad, rb.velocity.y, 0);
        rb.velocity = movimiento;
    }
}
