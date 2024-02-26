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

    public float tiempoEntreDisparos = 2f;
    // Start is called before the first frame update
    void Start()
    {
        // Decimos que matrizAliens es una nueva matriz de SInvaders de nColumnas x nFilas
        // - INICIALIZACIÓN
        matrizAliens = new SInvader[nColumnas, nFilas]; 
        SpawnAliens();

        InvokeRepeating("SelectAlienShoot", tiempoEntreDisparos, tiempoEntreDisparos);
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

    // Busca el alien más cercano al jugador en una columna aleatoria y le dice que dispare
    private void SelectAlienShoot()
    {
        // Variable de control de la busqueda. Cuando esta a true ya he encontrado al alien y paro.
        bool encontrado = false;

        while (!encontrado) // Se repite con columnas aleaorias hasta encontrar un alien
        {
            // Elegir una columna aleatoria que no esté vacia
            int randomCol = Random.Range(0, nColumnas); // Columna aleatoria

            // Buscar al alie mas cercano al jugador en esa columna (el que este más abajo)
            // En este for tenemos dos condiciones: Que j > -1 y que encontrado == false
            // Como usamos && entre ellas (AND), deben cumplirse las dos, o salimos del bucle for
            for(int j = 0; j < nFilas && !encontrado; j++) // Recorrer la columna aleatoria
            {
                // Compruebo si el alien existe (no se ha destruido)
                if(matrizAliens[randomCol, j] != null) // Si la casilla no está vacia (null) el alien sigue vivo
                {
                    // Si encuentro un alien vivo, es el mas cercano de la columna al jugador porque la estoy recorriendo de abajo a arriba
                    matrizAliens[randomCol, j].Shoot(); // El alien dispara
                    encontrado = true; // He acabado la busqueda
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
