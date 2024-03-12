using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOvni : MonoBehaviour
{
    public float speed = 3f; // Velocidad a la que se mueve
    public int points = 100; // Puntos que da al derrotarlo
    public int dir = 1;
    public float deathAnimTime = 1f;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Desplazamiento horizontal
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if(collision.tag == "Borde")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BalaJugador")
        {
            Destroy(collision.gameObject);  // Destruye la bala
            // Sumar puntos
            SGameManager.instance.AddScore(points);
            // Animación de destruirse
            animator.Play("OvniDeath");
            speed = 0;
            Destroy(gameObject, deathAnimTime);
        }
    }
}
