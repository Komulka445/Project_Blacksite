using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject victory;
    public GameObject dialogue;
    public GameObject victoryScreen;
    public GameObject playerRef;
    public GameObject insanityMeter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("WinTrigger").GetComponent<WinCollider>().colliding4 == true)
        {
            victoryScreen.SetActive(true);
        }
        if (GameObject.Find("Player").GetComponent<PlayerMovement>().horrorStarted == true)
        {
            dialogue.SetActive(false);
        }
        if (GameObject.Find("Player").GetComponent<PlayerMovement>().horrorCompleted == true)
        {
            insanityMeter.SetActive(false);
        }
    }
}
