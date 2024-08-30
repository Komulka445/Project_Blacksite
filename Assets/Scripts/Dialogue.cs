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
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        textComp.text = string.Empty;
        Debug.Log("inactive");
        //StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(vignette.intensity.value);
        if (vignette.intensity.value <= 0.26f)
        {
            Debug.Log("active");
            gameObject.SetActive(true);
            StartDialogue();
        }

        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(true);
            if(textComp.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComp.text = lines[index];
            }
        }
        /*if(Input.GetKeyDown(KeyCode.K))
        {
            index++;
            lines[2] = "KOIRA VIHELTÄÄ";
        } */
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        //tarkasta mika aapinen
        foreach (char c in lines[index].ToCharArray())
        {
            textComp.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }


    void NextLine()
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
