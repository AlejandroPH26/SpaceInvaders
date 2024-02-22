using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGameManager : MonoBehaviour
{
                                    
    public SInvader[,] matrizAliens;// lista doble (matriz) de SInvaders - DECLARACIÓN
    public int nFilas = 5;          // Nº filas de invaders, alto
    public int nColumnas = 11;      // Nº columnas de invaders, ancho

    // Prefab de alien
    public GameObject alien1Prefab;
    public GameObject alien2Prefab;
    public GameObject alien3Prefab;

    // Game objet padre de los alies (para movimiento)
    public SInvaderMovement padreAliens;
    // Distancia entre aliens al spawnear
    public float distanciaAliens = 1;


    // Start is called before the first frame update
    void Start()
    {
        // Decimos que matrizAliens es una nueva matriz de SInvaders de nColumnas x nFilas
        // - INICIALIZACIÓN
        matrizAliens = new SInvader[nColumnas, nFilas]; 
        SpawnAliens();
    }

    void SpawnAliens()
    {
        // Doble bucle (anidado) que recorre la matriz (de 11*5, rangos 0-10 y 0-4)

        for(int i = 0; i < nColumnas; i++)
        {
            for(int j = 0; j < nFilas; j++)
            {
                GameObject prefab;                      // Prefab del alien que spawneamos
                if (j == 4) prefab = alien1Prefab;      // La última fila
                else if (j < 2) prefab = alien3Prefab;  // Las dos primeras filas
                else prefab = alien2Prefab;             // El resto de flas

                // Dentro de los dos bucles, instanciamos un alien
                SInvader auxAlien = Instantiate(prefab, padreAliens.gameObject.transform).GetComponent<SInvader>();
                // Lo guardamos en la posición de la matriz apropiada
                matrizAliens[i,j] = auxAlien;
                // Colocamos el alien
                auxAlien.transform.position += new Vector3(i - nColumnas/2, j - nFilas/2, 0) * distanciaAliens;
                // Asignamos padre movement al alien
                auxAlien.padre = padreAliens;
            }

        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
