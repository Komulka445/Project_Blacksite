using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{

    public float speed = 0.1f;
    private Vector3 targetPosition;
    private Vector3 returnPosition;
    private bool isOpening = false;
    private bool isClosing = false;
    //private float timeToWait = ;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        returnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpening == true)
       {
            Debug.Log("Lapi");
            //Liike
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            //Pysäytä ku valmis
            if (transform.position == targetPosition)
            {
                isOpening = false;
            }
        }
        if (isClosing == true)
        {
            //Liike
            transform.position = Vector3.MoveTowards(transform.position, returnPosition, speed * Time.deltaTime);

            //Pysäytä ku valmis
            if (transform.position == returnPosition)
            {
                isClosing = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Interrogator"))
        {
            OpenDoor();
            CloseDoor();
        }
            
        Debug.Log("Collidaa");
    }

    public void OpenDoor()
    {
        Debug.Log("opennoor toimmi");
        isOpening = true; //avaus
    }

    public void CloseDoor()
    {
        isClosing = true;
    }
}
