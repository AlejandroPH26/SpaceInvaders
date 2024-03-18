using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SMenuPausaManager : MonoBehaviour
{
    static public SMenuPausaManager instance;
    public Button botonContinuar;
    public Button botonSalir;
    public KeyCode exitKey = KeyCode.P;
    public GameObject pauseMenu;

    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        botonContinuar.onClick.AddListener(ContinuarJuego);
        botonSalir.onClick.AddListener(SalirDelJuego);
        // Desactivar el menú de pausa al iniciar
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Si se presiona la tecla Esc, mostrar el menú de pausa
        if (Input.GetKeyDown(exitKey))
        {
            pauseMenu.SetActive(true);

            if (isPaused)
            {
                OcultarMenuPausa();
            }
            else
            {
                MostrarMenuPausa();
            }

            
        }
    }

    // Función para mostrar el menú de pausa
    public void MostrarMenuPausa()
    {
        Debug.Log("Se ha llamado al menú");
        pauseMenu.SetActive(true); // Activa el Canvas
        Time.timeScale = 0f; // Detiene el tiempo del juego
        isPaused = true;
    }

    // Función para ocultar el menú de pausa
    public void OcultarMenuPausa()
    {
        pauseMenu.SetActive(false); // Desactiva el Canvas
        Time.timeScale = 1f; // Reanuda el tiempo del juego
        isPaused = false;
    }

    // Función para iniciar el evento de "Continuar"
    public void ContinuarJuego()
    {
        OcultarMenuPausa();
    }

    // Función para iniciar el evento de "Salir del juego"
    public void SalirDelJuego()
    {
        Application.Quit();
        Debug.Log("Se ha pulsado la tecla Salir");
    }
}
