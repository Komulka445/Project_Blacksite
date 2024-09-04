using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComp;
    public string[] lines;
    public float textSpeed;
    private Vignette vignette;
    public float waitTime = 5.0f;
    public float changeRowTime = 2.0f;
    private int index;
    private bool start = true;
    private int maxIndex = 1;
    //textfeidaus
    public float fadeTime;
    public float alphaValue;
    public float fadeAwayPerSecond;
    void Start()
    {
        index = 0;
        textComp.text = string.Empty;

        textComp = GetComponent<TextMeshProUGUI>();
        fadeAwayPerSecond = 1 / fadeTime;
        alphaValue = textComp.color.a;
    }
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0.0f && start == true) //alkulinet
        {
            Debug.Log("active");
            gameObject.SetActive(true);
            PrintLine();
            start = false;
        }
        if (Input.GetMouseButtonDown(0) && start == false) //skippaa lukeminen /nextline
        {
            if (textComp.text == lines[index] && index <= maxIndex)
            {
                NextLine();
            }
            else
            {
                Debug.Log("else lpi");
                StopAllCoroutines();
                textComp.text = lines[index];
                if (fadeTime > 0)
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
        //tarkasta mika aapinen
        foreach (char c in lines[index].ToCharArray())
        {
            textComp.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine() //avaa seuraava
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComp.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
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