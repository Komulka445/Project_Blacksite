using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using TMPro;
using UnityEngine;

public class Interrogator_AI : MonoBehaviour
{
    public float speed = 10.0f;
    private Vector3 targetPosition;
    private Vector3 returnPosition;
    bool first = true;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = new Vector3(transform.position.x -6, transform.position.y, transform.position.z);
        returnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        entry();
    }
    private void entry()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (transform.position == targetPosition && first == true)
        {
            Debug.Log("lapi");
            targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5.625f);
            //Vector3.RotateTowards(Vector3())
            first = false;
        }
    }
}
