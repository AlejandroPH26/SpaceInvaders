using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float velocidad = 1;

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

        else if (collision.tag == "BalaEnemigo") // Choca con la bala enemiga
        {
            Destroy(this.gameObject); // Se destruye a bala
        }
    }

    private void OnDestroy()
    {
        Debug.Log("Bala destruida");
        SPlayer.canShoot = true;
        // El jugador puede volver a disparar
        // player.canshoot = true
    }
}
