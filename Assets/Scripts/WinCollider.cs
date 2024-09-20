using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCollider : MonoBehaviour
{
    public bool colliding4 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("before lapi");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("lapi");
            colliding4 = true;
        }
        //Debug.Log("Collidaa");
    }
}
