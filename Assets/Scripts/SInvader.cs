using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InvaderType {SQUID, CRAB, OCTOPUS}

public class SInvader : MonoBehaviour
{
    public InvaderType tipo = InvaderType.SQUID;

    public GameObject particulaMuerte;
    public bool isQuitting = false;
    public SInvaderMovement padre;

    public GameObject invaderBullet;
    public AudioClip sfxInvaderDeath;

    public float bulletSpawnYOffset = -0.65f;

    public int puntosGanados = 10;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
            SSoundManager.instance.PlaySFX(sfxInvaderDeath);
            GameObject particula = Instantiate(particulaMuerte, transform.position, Quaternion.identity);
            // Destroy(particula, 0.2f); Destruimos las particulas dentro de 0.2 segundos
            // Stun a los aliens (movimiento)
            padre.AlienDestroyedStun();
            // Suma puntos
            SGameManager.instance.AddScore(puntosGanados);
        }
    }

    public void MovementAnimation()
    {
        //Reproduce la animación idle según el tipo
        if(tipo == InvaderType.SQUID)
        {
            animator.Play("Anim_Alien_1");
        }
        else if(tipo == InvaderType.CRAB)
        {
            animator.Play("Anim_Alien_2");
        }
        else if (tipo == InvaderType.OCTOPUS)
        {
            animator.Play("Anim_Alien_3");
        }

        //Vale cualquiera de las dos opciones

        // animator.Play("Anim_Alien_" + ((int)tipo+1).ToString()); 
    }

    public void StunAnimation()
    {
        animator.Play("Anim_Alien_" + ((int)tipo + 1).ToString() + "_Stun");
    }
}
