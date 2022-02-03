using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public bool dontInterrupt = true;
    public static BackgroundMusic instance = null;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else if (instance!=this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (dontInterrupt)
        {
            Object.DontDestroyOnLoad(this.gameObject);// preserve the object when moving to a new scene
        }
    }

    // Update is called once per frame
    void Update()
    {
        //
    }
}
