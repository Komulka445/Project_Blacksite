using Slider = UnityEngine.UI.Slider;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HorrorIQ : MonoBehaviour
{
    public Slider sanityMeter;
    public GameObject sanityElement;
    public Light roomLight;
    public GameObject roomLightTrigger;
    private bool doNotRun = false;
    [SerializeField] private Volume volume;
    private Vignette vignette;

    // Start is called before the first frame update
    void Start()
    {
        sanityElement.gameObject.SetActive(false);
        roomLight.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("RoomLightTrigger").GetComponent<RetardCollider>().colliding == true && doNotRun == false)
        {
            sanityElement.gameObject.SetActive(true);
            //sammuu
            sanityMeter.value = sanityMeter.value + 10;
            Debug.Log("sammuu");
            roomLight.gameObject.SetActive(false);
            doNotRun = true;
        }
    }


}
