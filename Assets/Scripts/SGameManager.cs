using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGameManager : MonoBehaviour
{
    // lista doble (matriz) de SInvaders - DECLARACIÓN
    public SInvader[,] matrizAliens;
    public const int nFilas = 5;     // Nº filas de invaders, alto
    public const int nColumnas = 11; // Nº columnas de invaders, ancho


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
                if (matrizAliens[i, j] == null) Debug.Log("Alien no creado");
            }

        }
        
            // Dentro de los dos bucles, instanciamos un alien
            // Lo guardamos en la posición de la matriz apropiada
            // Colocamos el alien

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
