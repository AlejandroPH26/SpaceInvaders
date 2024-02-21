using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuclesAnidados : MonoBehaviour
{
    public int[,] listaNumeros;

    int n = 1;

    // Start is called before the first frame update
    void Start()
    {
        //int[,] tabla = CreaTablaMultiplicar(5, 10);

        //DibujaMatriz(tabla);

        //DibujaMatriz(CreaTablaMultiplicar(2, 20));

        DibujaMatriz(CreaTablaNPrimerosNumeros(8, 10));

        ApareceNEnTabla(CreaTablaNPrimerosNumeros(5, 10), 40);
        ApareceNEnTabla(CreaTablaNPrimerosNumeros(5, 10), -40);

        ApareceNEnTabla(CreaTablaMultiplicar(10, 10), 10);
    }

    public bool ApareceNEnTabla(int[,] tabla, int nBuscar)
    {
        bool encontrado = false;

        // Recorrer tabla
        for (int i = 0; i < tabla.GetLength(0); i++)
        {
            for(int j = 0; j < tabla.GetLength(1); j++)
            {
                if (tabla[i,j] == nBuscar) // Compruebo si cada celda vale nBuscar
                {
                    // Si encuentro el numero, saco un mensaje y pongo encontrado a true
                    Debug.Log("El numero " + nBuscar + " está en la tabla");
                    encontrado = true;
                    return encontrado;
                }
            }
        }

        return encontrado;
    }

    // Crea y devuelve una matriz de col * row con los N primeros numeros naturales (N = col * row)
    public int[,] CreaTablaNPrimerosNumeros(int ancho, int alto)
    {
        int[,] tabla = new int[ancho, alto];
        int contador = 0;

        for(int i = 0; i < ancho;i++)
        {
            for(int j = 0; j < alto; j++)
            {
                tabla[i, j] = contador; // Asignar a la casilla valores 0,1,2,3,4 ... N
                contador++;

                //tabla[i, j] = i * alto + j; // Asigno su valor a la casilla
            }
        }

        return tabla;
    }

    // Crea y devuelve una matriz de col * row con las tablas de multiplicar
    public int[,] CreaTablaMultiplicar(int col, int row)
    {
        int[,] tablaMultiplicar = new int[col, row];                                // Creo la matriz/tabla de col * row

        for (int i = 0; i < tablaMultiplicar.GetLength(0); i++)                     // Recorro el ancho (columnas)
        {
            // string tablaDeI = "Esta es latabla de " + (i + 1).ToString() + " ";
            for (int j = 0; j < tablaMultiplicar.GetLength(1); j++)                 // Recorro el alto (filas)
            {
                //listaNumeros[i,j] = (i+1)*(j+1);
                tablaMultiplicar[i, j] = (i+1) * (j+1);                             // Doy un valor a cada casilla
                //tablaDeI += tablaMultiplicar[i, j].ToString() + " ";

            }
            //Debug.Log(tablaDeI);
        }

        return tablaMultiplicar;                                                    // Devuelvo la matriz entera
    }

    public void DibujaMatriz(int[,] matriz)
    {
        string texto = " ";
        for (int j = 0;  j < matriz.GetLength(0); j++) // Recorro la 2ª dimensión
        {
            
            for(int i = 0;i < matriz.GetLength(1); i++) // Recorro la 1ª dimensión
            {
                texto += matriz[j, i].ToString() + " ";
            }
            texto += '\n';
        }
        Debug.Log(texto);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
