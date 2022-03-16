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
    public GameObject CarStopShuttleCollider;
    public bool ShowOnBoaring = true;


    private bool shuttleDrivingStraight = true;

    private bool shuttleFirstTimeInCurve = true;
    private bool shuttleFirstTimeStanding = true;

    private float timeFreeze;

    // Start is called before the first frame update
    void Start()
    {
        // define PseudoLocomotive default characteristics 
        // PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn = false;
        // GameObject OnBoarding = GameObject.Find("OnBoarding");
        // GreenDisplay.GetComponent<SplineBasedLocomotive>().MaxSpeed =  40f;
        // PseudoLocomotive.GetComponent<SplineBasedLocomotive>().MaxSpeed =  40f;
        PseudoLocomotive.GetComponent<SplineBasedLocomotive>().AccelerationRate = 0f;
        PseudoLocomotive.GetComponent<SplineBasedLocomotive>().BrakingDecelerationRate = 6f;
        StartCoroutine(waiter());
        timeFreeze = Time.time;
        Debug.Log("starting Time: " + timeFreeze);
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
        // PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn = true;     // turn engines on
    }

    // void updateAcceleration(){
    //     var t = Time.deltaTime;
    //     Debug.Log("time: " + t);

    //     if(PseudoLocomotive.GetComponent<SplineBasedLocomotive>().Speed_KPH < 30){
    //         timeLimit = t + 2;
    //         PseudoLocomotive.GetComponent<SplineBasedLocomotive>().AccelerationRate = (-(Time.deltaTime - timeLimit) * (Time.deltaTime - timeLimit) )+ 6; 
    //     }
        
    //     // if (x < 2){
    //     //     PseudoLocomotive.GetComponent<SplineBasedLocomotive>().AccelerationRate = -(x-2)*(x-2) + 6; 
    //     // } else {
    //     //     PseudoLocomotive.GetComponent<SplineBasedLocomotive>().AccelerationRate = 0; 
    //     // }

    //     // if(speed == 30){
    //     //     nothing
    //     // }
    //     // if(speed == 0){
    //     //     start dynamic acceleration
    //     // }
    //     // if(curve start){
    //     //     deaccelerate
    //     // }
    //     // if(curve end){
    //     //     dynamic accelerate
    //     // }
    // }


    // Update is called once per frame
    void Update()
    {    
        
        // read rotation of PseudoLocomotive
        float angle = PseudoLocomotive.transform.rotation.eulerAngles.y;
        // ============================================================== define curve behavior
        if (((angle/90) % 1) != 0){      // if rotation is not 90 or 180 or 270 and so on > reduce speed
            if (shuttleFirstTimeInCurve){
                shuttleDrivingStraight = false; 
                timeFreeze = Time.time;
                Debug.Log("time freeze: " + timeFreeze);
            } 
            shuttleFirstTimeInCurve = false;

            // define acceleration at curve start
            var timeLimit = timeFreeze + 2;
            if(Time.time < timeLimit){
                PseudoLocomotive.GetComponent<SplineBasedLocomotive>().MaxSpeed = 20f;       // Change velocity
                PseudoLocomotive.GetComponent<SplineBasedLocomotive>().BrakingDecelerationRate = ( (-6.0f/(4.0f)) * (Time.time - timeLimit) * (Time.time - timeLimit) )+ 6 ; 
                // Debug.Log("BrakingDecelerationRate: " +  PseudoLocomotive.GetComponent<SplineBasedLocomotive>().BrakingDecelerationRate);
            }
            // define acceleration at curve end
            var secondTimeLimit = timeFreeze + 4;
            if(Time.time < secondTimeLimit && Time.time > timeLimit){
                Debug.Log("out of curve");
                PseudoLocomotive.GetComponent<SplineBasedLocomotive>().MaxSpeed = 30f;  
                PseudoLocomotive.GetComponent<SplineBasedLocomotive>().AccelerationRate = ( (-6.0f/(4.0f)) * (Time.time - secondTimeLimit) * (Time.time - secondTimeLimit) )+ 6 ; 
                // Debug.Log("BrakingDecelerationRate: " +  PseudoLocomotive.GetComponent<SplineBasedLocomotive>().BrakingDecelerationRate);
            }
        }
        if (((angle/90) % 1) == 0){     // if rotation is 90, 180, 270, 360,  and so on > max speed
            shuttleFirstTimeInCurve = true;
            shuttleDrivingStraight = true;
            // PseudoLocomotive.GetComponent<SplineBasedLocomotive>().MaxSpeed = 30f;  
        }
        // if(!PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn){
        //     PseudoLocomotive.GetComponent<SplineBasedLocomotive>().BrakingDecelerationRate = 40f;
        //     // PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn = true;
        // }else{
        //     PseudoLocomotive.GetComponent<SplineBasedLocomotive>().BrakingDecelerationRate = 6f;
        // }



        if(CarStopShuttleCollider.GetComponent<CarStopShuttle>().shuttleReadyToStart){
            if(shuttleFirstTimeStanding){
                timeFreeze = Time.time;
                PseudoLocomotive.GetComponent<SplineBasedLocomotive>().AccelerationRate = 0;
            }
            shuttleFirstTimeStanding = false;

            var timeLimit = timeFreeze + 6;
            if(Time.time < timeLimit){
                PseudoLocomotive.GetComponent<SplineBasedLocomotive>().AccelerationRate = ( (-6.0f/(6f*6f)) * (Time.time - timeLimit) * (Time.time - timeLimit) )+ 6; 
                // Debug.Log("accelerationRate: " +  PseudoLocomotive.GetComponent<SplineBasedLocomotive>().AccelerationRate);
            } else if (Time.time > timeLimit) {
                shuttleFirstTimeStanding = true;
                // PseudoLocomotive.GetComponent<SplineBasedLocomotive>().AccelerationRate = 0;
                CarStopShuttleCollider.GetComponent<CarStopShuttle>().shuttleReadyToStart = false;
            }
        }

        // transform acceleration to normal distribution when shuttle starts to drive
        // if(shuttleDrivingStraight && PseudoLocomotive.GetComponent<SplineBasedLocomotive>().Speed_KPH < 30){
        //     if(shuttleFirstTimeStanding){
        //         timeFreeze = Time.time;
        //     }
        //     shuttleFirstTimeStanding = false;

        //     var timeLimit = timeFreeze + 6;
        //     if(Time.time < timeLimit){
        //         PseudoLocomotive.GetComponent<SplineBasedLocomotive>().AccelerationRate = ( (-6.0f/(timeLimit*timeLimit)) * (Time.time - timeLimit) * (Time.time - timeLimit) )+ 6; 
        //         Debug.Log("accelerationRate: " +  PseudoLocomotive.GetComponent<SplineBasedLocomotive>().AccelerationRate);
        //     }
        //     if(PseudoLocomotive.GetComponent<SplineBasedLocomotive>().AccelerationRate == 5.9f){
        //         shuttleFirstTimeStanding = true;

        //     }
        // }



        // if(shuttleDrivingStraight && PseudoLocomotive.GetComponent<SplineBasedLocomotive>().Speed_KPH == 0){
        //     shuttleFirstTimeStanding = true;
        //     // PseudoLocomotive.GetComponent<SplineBasedLocomotive>().AccelerationRate = 0;
        // }

        // Debug.Log("shuttleFirstTimeStanding: " + shuttleFirstTimeStanding);
        // Debug.Log("speed: " + PseudoLocomotive.GetComponent<SplineBasedLocomotive>().Speed_KPH);






        // // ============================================================== hot keys --> 1 --> HMI_speed (on/off)
        // if (Input.GetKeyUp(KeyCode.Alpha1)){
        //     if(HMI_speed.GetComponent<MeshRenderer>().enabled == false){
        //         HMI_speed.GetComponent<MeshRenderer>().enabled = true;
        //     }else{
        //         HMI_speed.GetComponent<MeshRenderer>().enabled = false;
        //     }
        // }
        // // ============================================================== hot keys --> 2 --> HMI_brake (on/off)
        // if (Input.GetKeyUp(KeyCode.Alpha2)){
        //     if(HMI_brake.GetComponent<MeshRenderer>().enabled == false){
        //         HMI_brake.GetComponent<MeshRenderer>().enabled = true;
        //     }else{
        //         HMI_brake.GetComponent<MeshRenderer>().enabled = false;
        //     }
        // }
        // // ============================================================== hot keys --> S --> engine (on/off) start and stop
        // if (Input.GetKeyUp(KeyCode.S)){ 
        //     if(PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn == false){
        //         PseudoLocomotive.GetComponent<SplineBasedLocomotive>().BrakingDecelerationRate = 40f;
        //         PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn = false;
        //     } else {
        //         PseudoLocomotive.GetComponent<SplineBasedLocomotive>().BrakingDecelerationRate = 6f;
        //         PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn = true;
        //     }
        // }



    }
}
}