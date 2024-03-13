using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSoundManager : MonoBehaviour
{
    static public SSoundManager instance;
    [SerializeField]
    private AudioSource clickSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void PlaySFX(AudioClip clip)
    {
        clickSource.PlayOneShot(clip);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
