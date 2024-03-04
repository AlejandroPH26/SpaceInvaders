using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SInvader : MonoBehaviour
{
    public GameObject particulaMuerte;
    public bool isQuitting = false;

    public SInvaderMovement padre;
    public GameObject invaderBullet;

    public float bulletSpawnYOffset = -0.65f;

    public int puntosGanados = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot() // El alien dispara una bala
    {
        Vector3 aux = transform.position + new Vector3(0, bulletSpawnYOffset, 0); // Modificar posición spawn
        Instantiate(invaderBullet, aux, Quaternion.identity); // Spawnear la bala
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Borde") // Choca con el borde de la pantala
        {
            // Llamar a SwitchDirection para que se gire el padre
            padre.SwitchDirection();
        }

        else if(collision.gameObject.layer == LayerMask.NameToLayer("GameOverBarrier"))
        {
            SGameManager.instance.PlayerGameOver();
        }
    }

    private void OnApplicationQuit() // Se llama al cerrar la aplicación, antes del OnDestroy
    {
        isQuitting = true;
    }

    private void OnDestroy() // Se llama al destruir el objeto
    {
        if (!isQuitting) 
        {
            GameObject particula = Instantiate(particulaMuerte, transform.position, Quaternion.identity);
            // Destroy(particula, 0.2f); Destruimos las particulas dentro de 0.2 segundos
            // Suma puntos
            SGameManager.instance.AddScore(puntosGanados);
        }
    }
}
