using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEnemyBullet : MonoBehaviour
{
    public float velocidad = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, - velocidad, 0) * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Borde") // Choca con un borde
        {
            Destroy(this.gameObject); // Se destruye a bala
        }

        else if (collision.tag == "BalaJugador") // Choca con la bala del jugador
        {
            Destroy(this.gameObject); // Se destruye a bala
            Destroy(collision.gameObject);
        }

        else if (collision.tag == "Jugador") // Choca con el jugador
        {
            // GameManager.instance.dañojugador p.ej.
            Destroy(this.gameObject); // Se destruye a bala
            Destroy(collision.gameObject);
        }

        
    }
}
