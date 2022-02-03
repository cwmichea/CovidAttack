using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parenting : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = transform;//catch the player on the moving platform
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;//detach the player from the moving platform
    }
    // Start is called before the first frame update

}
