using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using TMPro;
using System.Data;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using Input = UnityEngine.Input;
using Slider = UnityEngine.UI.Slider;
using Unity.VisualScripting;

public class Dialogue2 : MonoBehaviour
{
    public TextMeshProUGUI percentageText;
    public float percentage;
    public Slider sanityMeter;
    public TextMeshProUGUI textComp;
    private string[] lines;
    public float textSpeed;
    private float waitTime = 10.0f;
    public float changeRowTime = 2.0f;
    private int index;
    private bool start = true;
    private int readUntilOrReadSingle = 8;
    private bool line3 = true;
    private int sanityInt;
    void Start()
    {
        textComp.text = string.Empty;
        lines = new string[40];
        lines[0] = "You: Hello?";//alku
        lines[1] = "You: Where am I?";
        lines[2] = "You: ???";

        //kun int istuu
        lines[3] = "???: Sit down";

        //kun istunut
        lines[4] = "???: We have some topics to discuss about your recent activities.";
        lines[5] = "You: Pardon me? What topics? Who are you?";
        lines[6] = "???: I am mr. Pierce, but you can call me Pierce.";
        lines[7] = "Pierce: The thing is that we really cant tell you much, neither can we let you go until we have reached a certain point.";
        lines[8] = "Pierce: I believe you might have some questions regarding the current circumstanses?";
        //eka optioni
        lines[9] = "1. Why am I here?\n2. Where am I?\n3. Who do you work for?"; //index 9
        lines[10] = "Why am I here?";//miksi oon taalla
        lines[11] = "What is this place? Where am I?";//Mika tama paikka on
        lines[12] = "Who do you work for??";//kenelle ttyoskenetelee

        lines[13] = "Pierce: The reason is classified because I am not meant to remind you about it. Only thing you need to know that you wont be leaving for a while."; //miksi taalla vastuas respons
        lines[16] = "1. For a while?\n2. Cant you just let me go?";//option 2
        lines[17] = "What do you mean that I wont be leaving for while";
        lines[18] = "Please just let me go, I havent done nothing!";

        lines[14] = "Pierce: As you probably have figured out, I do not enjoy the liberties of sharing any detailed information."; //mika paikka on vastaust respons
        lines[15] = "Pierce: The department that I work for protects our national interests is all you need to know."; //kenelle toihin vastaus respons
        

    }
    void Update()
    {
        percentageText.text = $"{sanityMeter.value}%";
        //percentageText.text = $"{sanityMeter.value}%";
        //percentageText.text = percentage;
        if (index == 3 && line3 == true){ sanityMeter.value = sanityMeter.value + 40;Debug.Log(sanityMeter.value+" "+sanityInt); line3 = false;};
        if(index == 9) //eka kysymyes , onki idei miksi t�l
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                index = 10; //no13 14 15
                
                AdvanceDialogue();
                index = 13; 
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                index = 11; //yes 16 
                AdvanceDialogue();
                index = 14;
            }
            else if (Input.GetKey(KeyCode.Alpha3))
            {
                index = 12; //idgaf 17
                AdvanceDialogue();
                index = 15;
            }
        }
        if(index == 13)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                index = 10; //no13 14 15

                AdvanceDialogue();
                index = 13;
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                index = 11; //yes 16 
                AdvanceDialogue();
                index = 14;
            }
        }
        if (index == 14)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                index = 10; //no13 14 15

                AdvanceDialogue();
                index = 13;
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                index = 11; //yes 16 
                AdvanceDialogue();
                index = 14;
            }
        }
        if (index == 15)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                index = 10; //no13 14 15

                AdvanceDialogue();
                index = 13;
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                index = 11; //yes 16 
                AdvanceDialogue();
                index = 14;
            }
        }

        Debug.Log(index + " " + lines[index]);
        if (waitTime > 0) //alotus taimeri
        {
            waitTime -= Time.deltaTime;
        }
        else if (start == true && waitTime < 0.0f) //alkulinet
        {
            Debug.Log("active");
            PrintLine();
            start = false;
        }

        
        if (Input.GetMouseButtonDown(0) && start == false) //skippaa lukeminen /nextline
        {
            AdvanceDialogue();
        }

        void AdvanceDialogue()
        {
            //Debug.Log("Linefork.Length: "+o.Length+" Index: "+index);
            if (textComp.text == lines[index]/* && index <= lineFork.Length && index >= lineFork[0]*/)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComp.text = lines[index];
            }
        }
        //ulkona updatesta
        void PrintLine()
        {
            StartCoroutine(TypeLine());
        }
        IEnumerator TypeLine() //smooth ass taippaus
        {
            // mika aapinen
            foreach (char c in lines[index].ToCharArray())
            {
                textComp.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
        void NextLine() //avaa seuraava
        {
            if (index < lines.Length - 1 && index <= readUntilOrReadSingle)
            {
                index++;
                textComp.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                //gameObject.SetActive(false);
            }
        }
    }
}

