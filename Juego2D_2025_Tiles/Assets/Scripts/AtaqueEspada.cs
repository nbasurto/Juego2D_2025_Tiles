using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEspada : MonoBehaviour
{
    Animator animator; // Referencia al Animator
    public Transform attackPoint; // Punto desde donde se genera el ataque
    public float rangoAtaque = 0.5f; // Radio del área de ataque
    public LayerMask enemyLayer; // Capa de los enemigos
    public float cooldownAtaque = 0.5f; // Tiempo entre ataques

    private float tiempoProximoAtaque = 0f; // Control del cooldown
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && Time.time >= tiempoProximoAtaque)
        {
            animator.SetTrigger("Atacar");
            tiempoProximoAtaque = Time.time + cooldownAtaque; // Aplicar cooldown
        }
    }

    /*void Attack()
    {
        // Reproducir la animación de ataque
        animator.SetTrigger("Atacar");

        // Detectar enemigos en el rango de ataque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, rangoAtaque, enemyLayer);

        // Aplicar daño a cada enemigo golpeado
        foreach (Collider2D enemy in hitEnemies)
        {
            Destroy(enemy.gameObject);
            //enemy.GetComponent<MovimientoEnemigo>().TakeDamage(attackDamage);
        }
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemigo"))
        {
            Destroy(collision.gameObject);
        }
    }

    // Dibujar el área de ataque en la escena
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, rangoAtaque);
    }
}
