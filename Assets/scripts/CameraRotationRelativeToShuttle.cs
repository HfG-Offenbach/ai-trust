using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WSMGameStudio.RailroadSystem
{
public class CameraRotationRelativeToShuttle : MonoBehaviour
{
    public GameObject Shuttle;
    public GameObject GameHandlerArea;

    private int Counter = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Counter = GameHandlerArea.GetComponent<GameHandlerArea>().RouteCounter;
    }

    // Update is called once per frame
    void Update()
    {

        if(GameHandlerArea.GetComponent<GameHandlerArea>().RouteCounter == Counter){
            // Counter = GameHandlerArea.GetComponent<GameHandlerArea>().RouteCounter;
            Debug.Log("shuttle rotation: " + Shuttle.transform.rotation.eulerAngles);
            // Debug.Log("Counter RouteCount: " + GameHandlerArea.GetComponent<GameHandlerArea>().RouteCounter);
            // Debug.Log("Counter: " + Counter);
            // transform.rotation = Shuttle.transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(Shuttle.transform.rotation.eulerAngles.x, Shuttle.transform.rotation.eulerAngles.y, Shuttle.transform.rotation.eulerAngles.z);
            Counter += 1;
        }

        
    }
}
}