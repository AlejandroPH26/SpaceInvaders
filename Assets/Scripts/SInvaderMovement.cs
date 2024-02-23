using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SInvaderMovement : MonoBehaviour
{
    public float speed = 1f;        // Velocidad de movimiento en X
    public float despAbajo = 1f;    // Distancia que baja al cambiar de dirección
    private float dir = 1;

    public bool canSwitch = true;   // Bool que indica si puede girarse
    public float switchDelay = 0.5f;// Tiempo que debe pasar despues de girar, para poder volver a hacerlo


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
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
}

    /*
     * 1 - Despues de girar, pongo canswitch a false
     * 2 - Crear una funcion que ponga canswitch a true
     * 3 - A la vez que pongo canswitch a false, hago invoke del método que cree antes, con tiempo switchdelay 
     */