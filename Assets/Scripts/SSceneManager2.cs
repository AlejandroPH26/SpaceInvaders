using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SSceneManager2 : MonoBehaviour
{
    public Button botonReturn;
    // Start is called before the first frame update
    void Start()
    {
        botonReturn.onClick.AddListener(CargarEscenaInicial);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CargarEscenaInicial()
    {
        SceneManager.LoadScene("StartMenu");
        Debug.Log("Se ha clickado para ir al startmenu");
    }
}
