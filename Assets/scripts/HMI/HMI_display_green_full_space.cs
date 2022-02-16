using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WSMGameStudio.RailroadSystem
{
public class HMI_display_green_full_space : MonoBehaviour
{
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

    }

    // Update is called once per frame
    void Update()
    {
        GameObject Shuttle = GameObject.Find("Shuttle");
        ILocomotive _shuttle = Shuttle.GetComponent<ILocomotive>();
        
        _currentSpeed = _shuttle.Speed_MPS;
        _KPH = _shuttle.Speed_KPH;

        var acceleration = ((_currentSpeed - lastSpeed) / Time.deltaTime);
        lastSpeed = _currentSpeed;

        // calculate current speed in percentage
        var SpeedPercentage = (_currentSpeed - SpeedMin) / (SpeedMax - SpeedMin);
        // OffsetContinuousDisplay = SpeedPercentage * (OffsetMin-OffsetMax) + OffsetMax;
        // scale display size
        transform.localScale = new Vector3(1, SpeedPercentage, 1);
        // redefine offset of display
        // transform.localPosition = new Vector3(0, OffsetContinuousDisplay, 0);

    }
}
}