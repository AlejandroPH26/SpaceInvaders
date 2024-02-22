using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SInvaderMovement : MonoBehaviour
{
    public float speed = 1f;        // Velocidad de movimiento en X
    public float despAbajo = 1f;    // Distancia que baja al cambiar de dirección
    private float dir = 1;

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
        dir *= -1;                                              // Invierto la dirección
        transform.position += new Vector3(0, -despAbajo, 0);    // Desplazo hacia abajo

    }
}
