using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WSMGameStudio.RailroadSystem
{
public class EndZoneTrigger : MonoBehaviour
{
    public GameObject BlackBoxForRouteSwitches;
    public GameObject PseudoLocomotive;

    public Color myColor;
    public float r_color = 0;
    public float g_color = 0;
    public float b_color = 50;
    public float a_color = 0;


    public bool firstTimeTriggerOn = true;
    private bool triggerOn = false;
    

    private float timeFreeze;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    async void Update()
    {
    }
    

    void OnTriggerExit(Collider other){
                    PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn = false;

        if (other.CompareTag("StartTransitionToNextRoute" ) ){
            // triggerOn = true;
            if (firstTimeTriggerOn){
                firstTimeTriggerOn = false;
                StartCoroutine(fadeIn(5));
                // timeFreeze = Time.time;
                Debug.Log("start co-routine" + firstTimeTriggerOn);
            } 
                firstTimeTriggerOn = false;
        }

    }

    IEnumerator fadeIn(float duration){
        float counter = 0;
        //Get current color
        Color spriteColor = BlackBoxForRouteSwitches.GetComponent<Renderer>().material.color;

        while (counter < duration)
        {
            // if(counter==1){
            //     CancleOtherTriggerEvents = true;
            // }
            counter += Time.deltaTime;
            
            //Fade from 0 to 1
            float alpha = Mathf.Lerp(0, 1, counter / duration);
            Debug.Log(alpha);

            //Change alpha only
            BlackBoxForRouteSwitches.GetComponent<Renderer>().material.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
            //Wait for a frame
            yield return null;
        }
        
        
    }

}
}


// coder on the dance floor