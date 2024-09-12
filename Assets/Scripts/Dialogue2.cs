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

public class Dialogue2 : MonoBehaviour
{
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
    void Start()
    {
        textComp.text = string.Empty;
        lines = new string[18];
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
        lines[8] = "Pierce: Do you have any idea why we have brought you here?";
        //eka optioni
        lines[9] = "1. No?\n2. Yes (lie)\n3. I do not care let me go."; //index 9
        lines[10] = "No, why would I know?";//no vastaus
        lines[11] = "Yes, of course I know!";//yes vastaus
        lines[12] = "I do not care about you or your games, let me go.";//idgaf vastaus

        lines[13] = "Pierce: The thing is that you have witnessed something that could pose a threat to national security"; //NO vastuas respons
        lines[14] = "Pierce: Which means we have to make sure that you really dont remember it";
        lines[15] = "Pierce: After youve had this, we just have to make sure it worked. It takes just a minute.";
        lines[16] = "Pierce: Allright, then you probably know whats the deal, It'll take just a moment..."; //Yes vastaust respons
        lines[17] = "Someones a little grumpy today, Gladly we've prepared a special dose for you, dont worry it wont hurt."; //idgaf vastaus respons
    }
    void Update()
    {
        if (index == 3 && line3 == true){sanityMeter.value = sanityMeter.value + 0.05f;line3 = false;};
        if(index == 9) //eka kysymyes , onki idei miksi täl
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                index = 10; //no13 14 15
                
                AdvanceDialogue();
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                index = 11; //yes 16 
                AdvanceDialogue();
            }
            else if (Input.GetKey(KeyCode.Alpha3))
            {
                index = 12; //idgaf 17
                AdvanceDialogue();
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

