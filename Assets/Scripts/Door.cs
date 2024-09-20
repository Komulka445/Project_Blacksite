using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
    public float speed = 0.1f;
    private Vector3 targetPosition;
    private Vector3 currentPosition;
    private Vector3 returnPosition;
    private bool IsOperating = false;
    public float closingTime = 1.0f;
    private bool primary = true;
    public GameObject playerRef;
    //private float timeToWait = ;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        currentPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        returnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (primary == false)
        {
            Debug.Log("PRIMARY FALSE");
        }*/
        currentPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (GameObject.Find("Player").GetComponent<PlayerMovement>().horrorCompleted == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }

        if (IsOperating == true)
        {
            //Debug.Log("Lapi");
            //Liike
            if (primary == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                if (currentPosition.y >= targetPosition.y)
                {
                    primary = false;
                }
                
            }
            else if (primary == false)
            {
                //palauta ovi kiinni implementointi t‰g‰‰n
                closingTime -= Time.deltaTime;
                if (closingTime <= 0.0f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, returnPosition, speed * Time.deltaTime);
                    if (currentPosition.y <= returnPosition.y)
                    {
                        IsOperating = false;
                    } 
                }
                
            }
        }
        /*if (isClosing == true)
        {
            //Liike
            transform.position = Vector3.MoveTowards(transform.position, returnPosition, speed * Time.deltaTime);

            //Pys‰yt‰ ku valmis
            if (transform.position == returnPosition)
            {
                isClosing = false;
            }
        }*/
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Interrogator"))
        {
            OperateDoor();
        }
            
        //Debug.Log("Collidaa");
    }

    public void OperateDoor()
    {
        //Debug.Log("opennoor toimmi");
        IsOperating = true; //avaus
    }
}
