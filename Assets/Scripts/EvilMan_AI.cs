using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class EvilMan_AI : MonoBehaviour
{
    public Light roomLight;
    private Vector3 targetPosition;
    private Vector3 friendPosition;
    private Vector3 spookPosition;
    private Vector3 currentPosition;
    private bool hunt = false;
    public bool doNotRun2 = false;
    public bool startMusic = true;
    public GameObject spookTrigger;
    public GameObject exitTrigger;
    public GameObject playerRef;
    private AudioSource commieAudioSource;
    [SerializeField]
    public AudioClip EvilManTaunt;
    [SerializeField]
    public AudioClip EvilManMusic;
    //public AudioSource EvilManMusic;
    public GameObject Target;
    public float timeTaunt = 20.0f;
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        currentPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        spookPosition = new Vector3(16.96875f, 3.125f, 217.375f);
        friendPosition = new Vector3(5.09375f, 5.734375f, 21.65625f);
        commieAudioSource = GetComponent<AudioSource>();
        //EvilManTaunt = GetComponent<AudioSource>();
        //EvilManMusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        targetPosition = new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z);//xz

        if (GameObject.Find("Player").GetComponent<PlayerMovement>().horrorCompleted == true) //hyvyys
        {
            transform.position = friendPosition;
        }

        if (GameObject.Find("ExitTrigger").GetComponent<ExitCollider>().colliding3 == true)
        {
            roomLight.gameObject.SetActive(true);
            hunt = false;
        }

        if (GameObject.Find("SpookTrigger").GetComponent<SpookCollider>().colliding2 == true && doNotRun2 == false)
        {
            transform.position = spookPosition;
            doNotRun2 = true;
        }

        if (hunt == true)
        {
            timeTaunt -= Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        if (roomLight.gameObject.activeSelf == false && startMusic == true)
        {
            commieAudioSource.PlayOneShot(EvilManMusic);
            startMusic = false;
            hunt = true;
        }
        if (timeTaunt <= 0.0f)
        {
            commieAudioSource.PlayOneShot(EvilManTaunt);
            timeTaunt = 20.0f;
        }
        /*if(currentPosition.x  == targetPosition.x || currentPosition.y == targetPosition.y)
        {
            hunt = false;
        */
    }
}
