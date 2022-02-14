using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

namespace WSMGameStudio.RailroadSystem
{
public class ReadSpeed : MonoBehaviour
{
    private float _currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        //Wait for 6 seconds
        yield return new WaitForSeconds(6);

        Debug.Log("waiting is over");
    }

    // Update is called once per frame
    void Update()
    {
        ILocomotive locomotive = GetComponent<ILocomotive>();

        _currentSpeed = locomotive.Speed_KPH;

        // Debug.Log("CurrentSpeed:" + _currentSpeed);


    }
  
}
}