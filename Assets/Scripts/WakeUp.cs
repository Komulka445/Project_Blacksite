using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WakeUp : MonoBehaviour
{
    private  Animator animator;
    [SerializeField] private  Volume volume;
    private  Vignette vignette;
    private  float duration = 5.0f;
    private  float elapsedTime = 0f;
    private  float startValue = 1.0f;
    private  float endValue = 0.25f;
    public  float waitTime = 5.0f;
    private  bool isAnimating = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Wake_up");
        
        if (volume.profile.TryGet(out vignette))
        {
            vignette.intensity.value = startValue;
        }
    }

    void Update()
    {
        if (isAnimating && vignette != null)
        {
            //animaatio
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            vignette.intensity.value = Mathf.Lerp(startValue, endValue, t);
            if (t >= 1.0f)
            {
                isAnimating = false;
            }
        }
    }
}
