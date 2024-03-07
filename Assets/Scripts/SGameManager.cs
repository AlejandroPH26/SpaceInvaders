using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SGameManager : MonoBehaviour
{
                                    
    public SInvader[,] matrizAliens;        // lista doble (matriz) de SInvaders - DECLARACIÓN
    public int nFilas = 5;                  // Nº filas de invaders, alto
    public int nColumnas = 11;              // Nº columnas de invaders, ancho

    // Jugador
    private SPlayer player;

    // Prefab de alien
    public GameObject alien1Prefab;
    public GameObject alien2Prefab;
    public GameObject alien3Prefab;

    
    public SInvaderMovement padreAliens;        // Game objet padre de los alies (para movimiento)
    public float distanciaAliens = 1;           // Distancia entre aliens al spawnear
    public float tiempoEntreDisparos = 2f;      // Tiempo entre disparos de los aliens
    
    // CICLO DEL JUEGO
    // Fin de la partida
    public bool gameOver = false;
    // Vidas actuales del jugador
    public int vidas = 3;
    // Puntuacion actual de jugador
    public int score = 0;
    // Nº de aliens derrotados
    private int defeatedAliens = 0;

    public float playerDamageDelay = 1.5f;

    // SINGLETON
    public static SGameManager instance = null;

    // Interfaz
    public TextMeshPro scoreText;
    public TextMeshPro lifesText;
    public GameObject spriteVida3;
    public GameObject spriteVida2;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Busco al jugador y lo guardo
        player = FindObjectOfType<SPlayer>();

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

    // Método que se llama cuando perdemos la partida (nos quedamos sin vidas o los aliens llegan abajo)
    public void PlayerGameOver()
    {
        gameOver = true;
        CancelInvoke();                     // Interrumpimos todos lo invokes de este componente (se deja de disparar)
        Debug.Log("El jugador ha perdido");
    }

    public void PlayerWin()
    {
        gameOver = true;
        CancelInvoke();                     // Interrumpimos todos lo invokes de este componente (se deja de disparar)
        Debug.Log("El jugador ha ganado");
    }

    public void DamagePlayer()
    {
        if(!gameOver && player.GetCanMove())
        {
            vidas--;
            UpdateLifeUI();
            // Animación de daño de jugador
            player.PlayerDamaged();
            padreAliens.canMove = false; // Boqueo el movimiento de los aliens
            SetInvadersAnim(false);
            Invoke("UnlockDamagedPlayer", 1.5f);
            if(vidas <= 0)
            {
                PlayerGameOver();
            }
        }
    }

    private void UnlockDamagedPlayer()
    {
        player.PlayerReset();           // Desbloqueo el movimiento del jugador
        padreAliens.canMove = true;     // Desbloqueo el movimiento de los aliens
        SetInvadersAnim(true);
    }

    private void UpdateLifeUI()
    {
        lifesText.text = vidas.ToString();                  // Actualiza el texto        
        spriteVida2.SetActive(vidas >= 2);                  // Actualiza los sprites de las vidas
        spriteVida3.SetActive(vidas >= 3);

    }

    // Comprueba si el jugador ha ganado (si ha destruido todos los aliens)
    public void AlienDestroyed()
    {
        defeatedAliens++;                               // Aumento la cuenta de aliens derrotados
        if(defeatedAliens >= nFilas * nColumnas)        // Si ha derrotado a todos los aliens
        {
            PlayerWin(); // El jugador gana
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Suma points puntos a la puntuación
    public void AddScore(int points)
    {
        score += points;      
        scoreText.text = "SCORE\n" + score.ToString(); // Actaliza texto puntos

    }

    public void SetInvadersAnim(bool movement)
    {
       for(int i = 0; i < nColumnas; i++)
        {
            for(int j = 0; j < nFilas; j++)
            {
                if (matrizAliens[i, j] != null) // Comprobamos que existe
                {
                    // Asignamos la animacion que toque
                    if(movement) matrizAliens[i, j].MovementAnimation();
                    else matrizAliens[i, j].StunAnimation();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
