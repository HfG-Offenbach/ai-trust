using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuttleZoneDetectCar : MonoBehaviour
{
    public bool TriggerEnter = false;

    // Start is called before the first frame update
    void Start(){
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Car")){
            TriggerEnter = true;
        }
    }
}
