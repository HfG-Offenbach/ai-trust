using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WSMGameStudio.RailroadSystem
{
public class SceneControl : MonoBehaviour
{
    public GameObject PseudoLocomotive;
    public GameObject OnBoarding;
    public bool ShowOnBoaring = true;

    // Start is called before the first frame update
    void Start()
    {
        // define PseudoLocomotive default characteristics 
        PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn = false;
        // GameObject GreenDisplay = GameObject.Find("Shuttle");
        // GreenDisplay.GetComponent<SplineBasedLocomotive>().MaxSpeed =  40f;
        // PseudoLocomotive.GetComponent<SplineBasedLocomotive>().MaxSpeed =  40f;
        PseudoLocomotive.GetComponent<SplineBasedLocomotive>().AccelerationRate = 6f;
        PseudoLocomotive.GetComponent<SplineBasedLocomotive>().BrakingDecelerationRate = 6f;
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        if(ShowOnBoaring){
            yield return new WaitForSeconds(6);     // yield on a new YieldInstruction that waits for 5 seconds.
            if (OnBoarding){
                OnBoarding.SetActive(false);    // hide onBoarding displays
            }
            PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn = true;     // turn engines on
        } else {
            if (OnBoarding){ 
                OnBoarding.SetActive(false);    // hide onBoarding displays
            }
            PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn = true;     // turn engines on
        }
    }

    // Update is called once per frame
    void Update()
    {    
        
        // read rotation of PseudoLocomotive
        float angle = PseudoLocomotive.transform.rotation.eulerAngles.y;
        // define curve behavior
        if (((angle/90) % 1) != 0){      // if rotation is not 90 or 180 or 270 and so on > reduce speed 
            PseudoLocomotive.GetComponent<SplineBasedLocomotive>().MaxSpeed = 20f;       // Change velocity
            Debug.Log("reduce speed");
        }
        if (((angle/90) % 1) == 0){     // if rotation is 90, 180, 270, 360,  and so on > max speed
            PseudoLocomotive.GetComponent<SplineBasedLocomotive>().MaxSpeed = 30f;  
            Debug.Log("max speed");
        }
        if(!PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn){
            PseudoLocomotive.GetComponent<SplineBasedLocomotive>().BrakingDecelerationRate = 40f;
            // PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn = true;
        }else{
            PseudoLocomotive.GetComponent<SplineBasedLocomotive>().BrakingDecelerationRate = 6f;
        }


        // activate / deactivate GREEN DISPLAY
        if (Input.GetKeyUp(KeyCode.Alpha1)){
            // // Change velocity
            PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn = true;

            // // activate HMI style 1
            // GameObject GreenDisplay = GameObject.Find("screen_green");
            // if(GreenDisplay.GetComponent<MeshRenderer>().enabled == false){
            //     GreenDisplay.GetComponent<MeshRenderer>().enabled = true;
            // }else{
            //     GreenDisplay.GetComponent<MeshRenderer>().enabled = false;
            // }
        }

        // activate / deactivate RED DISPLAY
        if (Input.GetKeyUp(KeyCode.Alpha2)){
            // // ermergency brake test
            PseudoLocomotive.GetComponent<SplineBasedLocomotive>().BrakingDecelerationRate = 20f;
            PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EmergencyBrakes = true;

            // GameObject RedDisplay = GameObject.Find("screen_red");
            // if(RedDisplay.GetComponent<MeshRenderer>().enabled == false){
            //     RedDisplay.GetComponent<MeshRenderer>().enabled = true;
            // }else{
            //     RedDisplay.GetComponent<MeshRenderer>().enabled = false;
            // }
        }

                
        if (Input.GetKeyUp(KeyCode.Alpha3)){  
            
        }

    }
}
}