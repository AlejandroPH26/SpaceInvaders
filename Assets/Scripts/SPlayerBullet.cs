using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlayerBullet : MonoBehaviour
{
    public float velocidad = 1;
    [HideInInspector]
    public SPlayer player;
    public GameObject bulletExplosion;

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
            Instantiate(bulletExplosion, transform.position, Quaternion.identity); // Crea efecto de explosión de bala
        }

        else if (collision.tag == "Barrera") // Choca con un componente barrera
        {
            Destroy(this.gameObject); // Se destruye a bala
            Destroy(collision.gameObject);
            Instantiate(bulletExplosion, transform.position, Quaternion.identity); // Crea efecto de explosión de bala
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
