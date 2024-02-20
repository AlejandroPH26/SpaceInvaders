using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuclesAnidados : MonoBehaviour
{
    public int[,] listaNumeros;
    public List<int> listaDinamicaNumeros;

    int n = 1;

    // Start is called before the first frame update
    void Start()
    {
        listaNumeros = new int[10, 10];
        Debug.Log(listaNumeros.Length);

        for (int i = 0;i < listaNumeros.GetLength(0) ; i++)
        {
            string tablaDeI = "Esta es latabla de " + (i+1).ToString() + " ";
            for (int j = 0;j < listaNumeros.GetLength(1); j++)
            {
                //listaNumeros[i,j] = (i+1)*(j+1);
                listaNumeros[i, j] = n;
                tablaDeI += listaNumeros[i,j].ToString() + " ";
                //Debug.Log(listaNumeros[i,j]);
                n++;
            }
            //Debug.Log(tablaDeI);
        }
        DibujaMatriz(listaNumeros);
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
