using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SPlayer : MonoBehaviour
{
    [Tooltip("Prefab de la bala")]
    public GameObject prefabBullet;                 // Prefab de la bala
    [Tooltip("Velocidad del jugador en unidades de unity / jugador")]
    public float velocidad = 2;                     // Velocidad del jugador
    public KeyCode shootKey = KeyCode.Space;
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;

    public Transform posDisparo;

    static public bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot && Input.GetKeyDown(shootKey))
        {
            Shoot();
        }
        else if (Input.GetKey(moveLeftKey))
        {
            transform.position += new Vector3(-velocidad, 0, 0) * Time.deltaTime;
        }
        else if (Input.GetKey(moveRightKey))
        {
            transform.position += new Vector3(velocidad, 0, 0) * Time.deltaTime;
        }
    }

    private void Shoot()
    {
        Debug.Log("Disparo");
        Instantiate(prefabBullet, posDisparo.position, Quaternion.identity);
        canShoot = false;
    }

    
}
