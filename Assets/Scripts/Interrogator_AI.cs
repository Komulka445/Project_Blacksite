using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Interrogator_AI : MonoBehaviour
{
    public float speed = 10.0f;
    private Vector3 targetPosition;
    private Vector3 returnPosition;
    public Vector3 targetAngle;
    public Vector3 currentAngle;
    public Vector3 currentPosition;
    public GameObject playerRef;
    public float rotateTime = 2.0f;
    public float waitTime = 10.0f;
    public bool seated = false;
    //bool first = true;
    bool access = true;
    int phase = -1;

    void Start()
    {
        //peruspositiot ja k��nt�kulma
        targetPosition = new Vector3(transform.position.x -6, transform.position.y, transform.position.z);
        returnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        currentPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        targetAngle = new Vector3(transform.rotation.x, transform.rotation.y - 90, transform.rotation.z);
    }
    void Update()
    {
        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }
        else if (access == true)
        {
            phase = 0;
            access = false;
        }

        if (GameObject.Find("Player").GetComponent<PlayerMovement>().horrorCompleted == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
            //Updateta nykynen kulma ja asema
            currentAngle = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        currentPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (phase == 0)
        { //eka p�tk� alusta oven eteen
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (currentPosition == targetPosition)
            {
                phase = 1;
            }
        }
        else if (phase == 1)
        { //k��nn�s
            transform.Rotate(0, Time.deltaTime * -45, 0);
            rotateTime -= Time.deltaTime;
            if (rotateTime <= 0.0f)
            {
                targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5.625f);
                phase = 2;
            }
        }
        else if (phase == 2)
        { // liikke tuolille
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (currentPosition == targetPosition)
            {
                seated = true;
                phase = 3;
            }
        }
    }
}







//ARCHIVE ALKAA
        /*if (transform.position == targetPosition && first == true)
        {
            Debug.Log("lapi");
            
            transform.Rotate(0, Time.deltaTime * 20, 0);
            if (currentAngle.y! > targetAngle.y)
            {
                transform.Rotate(0, Time.deltaTime * 20, 0);
                Debug.Log("Rotti toimii");

            }
            else if (currentAngle.y <= targetAngle.y)
            {
                first = false;
            }*/
        
  
    //private void entry()
    //{
    //    transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    //    currentAngle = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
    //    if (transform.position == targetPosition && first == true )
    //    {
    //        Debug.Log("lapi");
    //        targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5.625f);
    //        transform.Rotate(0, Time.deltaTime * 20, 0);
    //        if (currentAngle.y !> targetAngle.y)
    //        {
    //            transform.Rotate(0,Time.deltaTime * 20, 0);
    //            Debug.Log("Rotti toimii");
                
    //        }
    //        /*else if (currentAngle.y <= targetAngle.y)
    //        {
    //            first = false;
    //        }*/
    //    }
    //}