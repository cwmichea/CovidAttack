using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCapsule : MonoBehaviour
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
        manager.AddRPill();//+1 to count how many fires are in the level/world
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Celly")
        {
            Debug.Log("ByCapsule");
            manager.AddRScore();
            this.Destroy();
        }
    }
}
