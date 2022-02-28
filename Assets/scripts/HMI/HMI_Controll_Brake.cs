using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WSMGameStudio.RailroadSystem
{
public class HMI_Controll_Brake : MonoBehaviour
{

    public GameObject PseudoLocomotive;
    public GameObject Car;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Car.GetComponent<SplineBasedLocomotive>().EnginesOn){
            PseudoLocomotive.GetComponent<SplineBasedLocomotive>().BrakingDecelerationRate = 30f;
        } else {
            PseudoLocomotive.GetComponent<SplineBasedLocomotive>().BrakingDecelerationRate = 6f;

        }
        
    }
}
}
