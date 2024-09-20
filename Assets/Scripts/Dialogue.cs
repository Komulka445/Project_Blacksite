using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using TMPro;
using System.Data;
using UnityEngine.UIElements;
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComp;
    public string[] lines;
    public float textSpeed;
    private float waitTime = 10.0f;
    public float changeRowTime = 2.0f;
    private int index;
    private bool start = true;
    //private int[] lineFork;
    //textfeidaus
    public float fadeTime;
    public float alphaValue;
    public float fadeAwayPerSecond;
    void Start()
    {
        //lineFork = new int[1];
        //lineFork[0] = 0;
        index = 0;
        textComp.text = string.Empty;

        //textComp = GetComponent<TextMeshProUGUI>();
        fadeAwayPerSecond = 1 / fadeTime;
        alphaValue = textComp.color.a;
    }
    void Update()
    {
         /*if (index == 4)
        {
            Array.Clear(lineFork, 0, lineFork.Length);
        }*/
        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }
        else if (start == true && waitTime < 0.0f) //alkulinet
        {
            //Debug.Log("active");
            PrintLine();
            start = false;
        }

        if (Input.GetMouseButtonDown(0) && start == false) //skippaa lukeminen /nextline
        {
            //Debug.Log("Linefork.Length: "+lineFork.Length+" Index: "+index);
            if (textComp.text == lines[index]/* && index <= lineFork.Length && index >= lineFork[0]*/)
            {
                NextLine();
            }
            else
            {
                //Debug.Log("else lpi");
                StopAllCoroutines();
                textComp.text = lines[index];
                if (fadeTime > 0) //odottaa implementointia
                {
                    alphaValue -= fadeAwayPerSecond * Time.deltaTime;
                    textComp.color = new Color(textComp.color.r, textComp.color.g, textComp.color.b, alphaValue);
                    fadeTime -= Time.deltaTime;
                }
            }
        }
    }
    void PrintLine() //Muuta indeksiä kun haluaa
    {
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine() //kirjota
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
        if (index < lines.Length - 1 && index <= 2)
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

/*
 *         /*if(Input.GetKeyDown(KeyCode.K))
        {
            index++;
            lines[2] = "KOIRA VIHELTÄÄ";
        } */
    

    /*void StartDialogue()
    {
        index = 0;
        //StartCoroutine(TypeLine());
    }*/