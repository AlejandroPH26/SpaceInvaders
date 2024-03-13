using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SPlayer : MonoBehaviour
{
    [Tooltip("Prefab de la bala")]
    public GameObject prefabBullet;                                         // Prefab de la bala
    [Tooltip("Velocidad del jugador en unidades de unity / jugador")]
    public float velocidad = 2;                                             // Velocidad del jugador
    public KeyCode shootKey = KeyCode.Space;
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;

    public Transform posDisparo;

    public bool canShoot = true;
    private bool canMove = true;

    public float limiteIzquierdo = -6.22f;
    public float limiteDerecho = 6.11f;

    // Animator del jugador
    public Animator pAnimator;
    public AudioClip sfxShoot;
    public AudioClip sfxDeath;
    private Vector3 posInicial;

    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position;
        pAnimator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            InputPlayer();
        }
    }

    private void InputPlayer()
    {
        if (canShoot && Input.GetKeyDown(shootKey))
        {
            Shoot();
        }
        else if (Input.GetKey(moveLeftKey))
        {
            transform.position += new Vector3(-velocidad, 0, 0) * Time.deltaTime;
            LimiteJugador();
        }
        else if (Input.GetKey(moveRightKey))
        {
            transform.position += new Vector3(velocidad, 0, 0) * Time.deltaTime;
            LimiteJugador();
        }
    }

    private void Shoot()
    {
        Debug.Log("Disparo");
        SSoundManager.instance.PlaySFX(sfxShoot);
        GameObject aux = Instantiate(prefabBullet, posDisparo.position, Quaternion.identity);
        SPlayerBullet bullet = aux.GetComponent<SPlayerBullet>();
        bullet.player = this;
        canShoot = false;
    }

    private void LimiteJugador()
    {
        Vector3 posicionActual = transform.position;

        if (posicionActual.x < limiteIzquierdo)
        {
            posicionActual.x = limiteIzquierdo;
        }
        else if (posicionActual.x > limiteDerecho)
        {
            posicionActual.x = limiteDerecho;
        }

        gameObject.transform.position = posicionActual;
    }

    public void PlayerDamaged()
    {
        SSoundManager.instance.PlaySFX(sfxDeath);
        pAnimator.Play("Anim_PlayerDeath");
        canMove = false;
    }

    public void PlayerReset()
    {
        pAnimator.Play("Anim_PlayerIdle");
        canMove = true;
        transform.position = posInicial;
    }

    public bool GetCanMove()
    {
        return canMove;
    }

    public void SetCanMove(bool b)
    {
        canMove = b;
    }
}
