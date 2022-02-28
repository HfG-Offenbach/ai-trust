using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WSMGameStudio.RailroadSystem
{
public class HMI_display_speed : MonoBehaviour
{

    public GameObject PseudoLocomotive;
    
    private float OffsetContinuousDisplay;
    private float SpeedMin = 0;
    private float SpeedMax = 30;
    // private float OffsetMin = 2.94f;
    // private float OffsetMax = 2.94f;
    
    private float _currentSpeed;
    private float _KPH;
    private float lastSpeed;
    
    public Renderer myRenderer;


    // Start is called before the first frame update
    void Start()
    {
        myRenderer = gameObject.GetComponent<Renderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        ILocomotive _shuttle = PseudoLocomotive.GetComponent<ILocomotive>();

        _currentSpeed = PseudoLocomotive.GetComponent<SplineBasedLocomotive>().Speed_MPS;
        _KPH = PseudoLocomotive.GetComponent<SplineBasedLocomotive>().Speed_KPH;

        var acceleration = ((_currentSpeed - lastSpeed) / Time.deltaTime);
        lastSpeed = _currentSpeed;

        // calculate current speed in percentage
        var SpeedPercentage = (_currentSpeed - SpeedMin) / (SpeedMax - SpeedMin);
        // scale display size
        transform.localScale = new Vector3(1, SpeedPercentage, 1);
        // redefine offset of display


    }
}
}