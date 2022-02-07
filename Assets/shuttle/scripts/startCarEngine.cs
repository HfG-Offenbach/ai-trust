// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

using UnityEngine;
using UnityEngine.Serialization;

namespace WSMGameStudio.RailroadSystem
{
public class startCarEngine : MonoBehaviour
{

    private bool _engine;

    
    // Start is called before the first frame update
    void Start()
    {
        // myRenderer = gameObject.GetComponent<Renderer>();
        GameObject CAR = GameObject.Find("CAR");
        ILocomotive _car = CAR.GetComponent<ILocomotive>();
        _engine = _car.EnginesOn;

        _engine = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}