using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SSceneManager : MonoBehaviour
{
    public Button botonStart;
    public Button botonControles;
    public Button botonSalir;

    // Start is called before the first frame update
    void Start()
    {
        botonStart.onClick.AddListener(CargarEscenaJuego);
        botonSalir.onClick.AddListener(SalirDelJuego);
        botonControles.onClick.AddListener(CargarEscenaControles);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CargarEscenaJuego()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Se ha clickado para ir al samplescene");
    }

    public void CargarEscenaControles()
    {
        SceneManager.LoadScene("ControlScene");
        Debug.Log("Se ha clickado para ir al controlscene");
    }

    public void SalirDelJuego()
    {
        Application.Quit();
        Debug.Log("Se ha salido del juego");
    }
}
