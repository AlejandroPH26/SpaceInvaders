using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlayerBullet : MonoBehaviour
{
    public float velocidad = 1;
    public SPlayer player = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, velocidad, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Borde") // Choca con un borde
        {
            Destroy(this.gameObject); // Se destruye a bala
        }

        else if (collision.tag == "Enemigo") // Choca con el enemigo
        {
            Destroy(this.gameObject); // Se destruye a bala
            Destroy(collision.gameObject);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("Bala destruida");
        player.canShoot = true;
        // El jugador puede volver a disparar
        // player.canshoot = true
    }
}
