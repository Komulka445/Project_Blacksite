using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Burst.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    //parametrit
    public Camera playerCamera;
    public float cRotSpeed = 1.0f;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public float defaultHeight = 2f;
    public float crouchHeight = 1.0f;
    public float crouchSpeed = 3f;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;
    public GameObject exitTrigger;
    public GameObject dialogueGObject;
    public GameObject eyeLids;
    public GameObject victory;
    private Vector3 exitSpawn;
    private Vector3 horrorSpawn;
    private bool canMove = true;
    private bool runOnce = true;
    public bool horrorStarted = false;
    public bool horrorCompleted = false;
    public Light flashlight;
    
    void Start()
    {
        exitSpawn = new Vector3(5.0f, 3.875f, 10.375f);
        horrorSpawn = new Vector3(0.28125f, 0.96875f, 145.6875f);
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        canMove = false;
        flashlight.gameObject.SetActive(false);
        if (tag == "Player")
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
            Rotate90Degrees();
        }
    }

    void Update()
    {
        //liike
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        if(GameObject.Find("WinTrigger").GetComponent<WinCollider>().colliding4 == true)
        {
            canMove = false;
        }
        if (GameObject.Find("DialogueSystem") != null) 
        {
            if (GameObject.Find("DialogueSystem").GetComponent<Dialogue2>().transferReady == true && horrorStarted == false)
            {
                canMove = false;
                transform.position = horrorSpawn;
                transform.rotation = Quaternion.Euler(0, 0, 270);
                Rotate90Degrees();
                horrorStarted = true;
            }
        }
        if (GameObject.Find("ExitTrigger").GetComponent<ExitCollider>().colliding3 == true && runOnce == true)
        {
            //scripti pelaajan lapi
            //Debug.Log("scpritci pelaaja lapi"+ transform.position+" "+exitSpawn);
            transform.position = exitSpawn;
            horrorCompleted = true;
            runOnce = false;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if(flashlight.gameObject.activeSelf == true)
            {
                flashlight.gameObject.SetActive(false);
            }
            else if (flashlight.gameObject.activeSelf == false)
            {
                flashlight.gameObject.SetActive(true);
            }
        }

        //hyppy
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }

        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        //hiippailu
        if (Input.GetKey(KeyCode.C) && canMove)
        {
            characterController.height = crouchHeight;
            walkSpeed = crouchSpeed;
            runSpeed = crouchSpeed;
        }

        else
        {
            characterController.height = defaultHeight;
            walkSpeed = 6f;
            runSpeed = 12f;
        }

        characterController.Move(moveDirection * Time.deltaTime);
        //freezaus
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    //spawnauskamerakääntely
    public void Rotate90Degrees()
    {
        StartCoroutine(Rotate());
    }
    private IEnumerator Rotate()
    {
        yield return new WaitForSeconds(5);

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, 0, 90);
        float timeElapsed = 0;
        
        while (timeElapsed < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, timeElapsed);
            timeElapsed += Time.deltaTime * cRotSpeed;
            yield return null;
        }
        
        transform.rotation = endRotation;
        canMove = true;
    }
}