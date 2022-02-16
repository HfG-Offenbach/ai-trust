using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WSMGameStudio.RailroadSystem
{
public class SceneControl : MonoBehaviour
{
//     public bool _engineOn;
//     public float _maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Shuttle = GameObject.Find("Shuttle");
        Shuttle.GetComponent<SplineBasedLocomotive>().enabled = false;
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        // yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(6);

        GameObject Shuttle = GameObject.Find("Shuttle");
        Shuttle.GetComponent<SplineBasedLocomotive>().enabled = true;
        if (GameObject.Find("OnBoarding")){
            GameObject OnBoarding_display = GameObject.Find("OnBoarding");
            OnBoarding_display.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        // activate / deactivate GREEN DISPLAY
        if (Input.GetKeyUp(KeyCode.Alpha1)){
            GameObject GreenDisplay = GameObject.Find("screen_green");
            if(GreenDisplay.GetComponent<MeshRenderer>().enabled == false){
                GreenDisplay.GetComponent<MeshRenderer>().enabled = true;
            }else{
                GreenDisplay.GetComponent<MeshRenderer>().enabled = false;
            }
        }

        // activate / deactivate RED DISPLAY
        if (Input.GetKeyUp(KeyCode.Alpha2)){
            GameObject RedDisplay = GameObject.Find("screen_red");
            if(RedDisplay.GetComponent<MeshRenderer>().enabled == false){
                RedDisplay.GetComponent<MeshRenderer>().enabled = true;
            }else{
                RedDisplay.GetComponent<MeshRenderer>().enabled = false;
            }
        }

    }
}
}