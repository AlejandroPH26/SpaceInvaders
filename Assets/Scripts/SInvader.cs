using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SInvader : MonoBehaviour
{
    public GameObject particulaMuerte;
    public bool isQuitting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }
    }
}
