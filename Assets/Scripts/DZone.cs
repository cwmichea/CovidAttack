using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DZone : MonoBehaviour
{
    private GameManager manager;
    public void Destroy()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Celly")
        {
            Debug.Log("DEATH ZONE!!!");
            this.Destroy();
            manager.Restart();
        }
    }
}
