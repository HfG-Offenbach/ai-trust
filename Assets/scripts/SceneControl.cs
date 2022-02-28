using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WSMGameStudio.RailroadSystem
{
public class SceneControl : MonoBehaviour
{
    public GameObject PseudoLocomotive;
    public GameObject OnBoarding;
    public GameObject HMI_speed;
    public GameObject HMI_brake;
    public bool ShowOnBoaring = true;

    // Start is called before the first frame update
    void Start()
    {
        // define PseudoLocomotive default characteristics 
        PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn = false;
        // GameObject OnBoarding = GameObject.Find("OnBoarding");
        // GreenDisplay.GetComponent<SplineBasedLocomotive>().MaxSpeed =  40f;
        // PseudoLocomotive.GetComponent<SplineBasedLocomotive>().MaxSpeed =  40f;
        PseudoLocomotive.GetComponent<SplineBasedLocomotive>().AccelerationRate = 6f;
        PseudoLocomotive.GetComponent<SplineBasedLocomotive>().BrakingDecelerationRate = 6f;
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        if(ShowOnBoaring){
            // yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(6);
            Debug.Log("onboarding...");
            startShuttle();
        } else {
            Debug.Log(" NO onboarding...");
            startShuttle();
        }
    }
    void startShuttle(){
        if (OnBoarding){ 
            OnBoarding.SetActive(false);    // hide onBoarding displays
        }
        PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn = true;     // turn engines on
    }



    // Update is called once per frame
    void Update()
    {    
        
        // read rotation of PseudoLocomotive
        float angle = PseudoLocomotive.transform.rotation.eulerAngles.y;
        // ============================================================== define curve behavior
        if (((angle/90) % 1) != 0){      // if rotation is not 90 or 180 or 270 and so on > reduce speed 
            PseudoLocomotive.GetComponent<SplineBasedLocomotive>().MaxSpeed = 20f;       // Change velocity
            // Debug.Log("reduce speed");
        }
        if (((angle/90) % 1) == 0){     // if rotation is 90, 180, 270, 360,  and so on > max speed
            PseudoLocomotive.GetComponent<SplineBasedLocomotive>().MaxSpeed = 30f;  
            // Debug.Log("max speed");
        }
        if(!PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn){
            PseudoLocomotive.GetComponent<SplineBasedLocomotive>().BrakingDecelerationRate = 40f;
            // PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn = true;
        }else{
            PseudoLocomotive.GetComponent<SplineBasedLocomotive>().BrakingDecelerationRate = 6f;
        }












        // ============================================================== hot keys --> 1 --> HMI_speed (on/off)
        if (Input.GetKeyUp(KeyCode.Alpha1)){
            if(HMI_speed.GetComponent<MeshRenderer>().enabled == false){
                HMI_speed.GetComponent<MeshRenderer>().enabled = true;
            }else{
                HMI_speed.GetComponent<MeshRenderer>().enabled = false;
            }
        }
        // ============================================================== hot keys --> 2 --> HMI_brake (on/off)
        if (Input.GetKeyUp(KeyCode.Alpha2)){
            if(HMI_brake.GetComponent<MeshRenderer>().enabled == false){
                HMI_brake.GetComponent<MeshRenderer>().enabled = true;
            }else{
                HMI_brake.GetComponent<MeshRenderer>().enabled = false;
            }
        }
        // ============================================================== hot keys --> S --> engine (on/off) start and stop
        if (Input.GetKeyUp(KeyCode.S)){ 
            if(PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn == false){
                PseudoLocomotive.GetComponent<SplineBasedLocomotive>().BrakingDecelerationRate = 40f;
                PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn = false;
            } else {
                PseudoLocomotive.GetComponent<SplineBasedLocomotive>().BrakingDecelerationRate = 6f;
                PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn = true;
            }
        }



    }
}
}