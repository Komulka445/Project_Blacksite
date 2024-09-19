using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpookCollider : MonoBehaviour
{
    public bool colliding2 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("before lapi");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("lapi");
            colliding2 = true;
        }
        //Debug.Log("Collidaa");
    }
}
