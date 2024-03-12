using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SInvaderMovement : MonoBehaviour
{
    public float speed = 1f;            // Velocidad de movimiento en X
    public float despAbajo = 1f;        // Distancia que baja al cambiar de dirección
    private float dir = 1;
    [HideInInspector]
    public float originalSpeed = 3f;    // Velocidad inicial

    public bool canSwitch = true;       // Bool que indica si puede girarse
    public float switchDelay = 0.5f;    // Tiempo que debe pasar despues de girar, para poder volver a hacerlo
    public bool canMove = true;         // Bool que indica si puede moverse
    public float moveStunTime = 0.5f;   // Tiempo que se paran los aliens al destruirse uno

    private SGameManager gm; // Referencia al gameManager


    // Start is called before the first frame update
    void Start()
    {
        gm = SGameManager.instance;
        originalSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gm.gameOver && canMove)
        {
            Movement();
        }
        
    }

    private void Movement()
    {
        transform.position += new Vector3(speed, 0, 0) * dir * Time.deltaTime;
    }

    public void SwitchDirection()
    {
        if(canSwitch)
        {
            dir *= -1;                                              // Invierto la dirección
            transform.position += new Vector3(0, -despAbajo, 0);    // Desplazo hacia abajo
            canSwitch = false;
            Invoke("SwitchEnable", switchDelay);
        }
    }

    public void SwitchEnable()
    {
        canSwitch = true;
    }

    private void EnableMovement()
    {
        canMove = true;
        gm.SetInvadersAnim(true);
    }

    public void AlienDestroyedStun() // Método que se llama cuando se destruye un alien y que para su movimiento un tiempo
    {
        canMove = false;                        // Paramos el movimiento
        gm.SetInvadersAnim(false);              // Poner animación stun
        Invoke("EnableMovement", moveStunTime); // Reactivamos el movimiento tras un tiempo
    }
}

    /*
     * 1 - Despues de girar, pongo canswitch a false
     * 2 - Crear una funcion que ponga canswitch a true
     * 3 - A la vez que pongo canswitch a false, hago invoke del método que cree antes, con tiempo switchdelay 
     */