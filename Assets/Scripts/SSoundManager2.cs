using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SSoundManager2 : MonoBehaviour
{
    static public SSoundManager2 instance;
    [SerializeField]
    public AudioClip backgroundMusic;
    private AudioSource musicSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = backgroundMusic; // Asignar el audio clip
        musicSource.loop = true; // Activar el bucle
        musicSource.Play(); // Iniciar la reproducción
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene") 
        {
            Destroy(gameObject); 
        }
    }
}
