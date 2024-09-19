using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCollider : MonoBehaviour
{
    public bool colliding3 = false;
    private Vector3 exitSpawn;
    // Start is called before the first frame update
    void Start()
    {
        exitSpawn = new Vector3(1.0f, 4.0625f, 18.96875f);
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
            colliding3 = true;
            transform.position = exitSpawn;
        }
        //Debug.Log("Collidaa");
    }
}
