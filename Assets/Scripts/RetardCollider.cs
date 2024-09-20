using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetardCollider : MonoBehaviour
{
    public bool colliding = false;
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
        //Debug.Log("before lapi");
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("lapi");
            colliding = true;
        }
        //Debug.Log("Collidaa");
    }
}
