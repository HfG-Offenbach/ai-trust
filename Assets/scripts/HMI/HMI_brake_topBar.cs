using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace WSMGameStudio.RailroadSystem
{
    public class HMI_brake_topBar : MonoBehaviour
    {

        public GameObject HmiTopBar;
        // private bool HMI_topBar_status =false;

        // Start is called before the first frame update
        void Start()
        {
           HmiTopBar.GetComponent<MeshRenderer>().enabled = false;
            
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnTriggerEnter(Collider other){
                ILocomotive locomotive = other.GetComponent<ILocomotive>();

                if (locomotive != null)
                {
                    // HMI_topBar_status = true;
                    // HmiTopBar.GetComponent<MeshRenderer>().enabled = true;

                    //acitvate predictive braking signal
                    // Debug.Log("trigger on");
                    StartCoroutine(activatePredictiveBrakingSignal());
                    // if (_customEvents != null)
                    //     _customEvents.Invoke();
                }
            }

        IEnumerator activatePredictiveBrakingSignal(){
            // yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(3);
            // HmiTopBar.GetComponent<MeshRenderer>().enabled = false;

            Debug.Log("trigger on...");
        }


    }
}








// namespace WSMGameStudio.RailroadSystem
// {
//     public class CustomEventZone : MonoBehaviour
//     {
//         [FormerlySerializedAs("customEvents")]
//         [SerializeField] private UnityEvent _customEvents;

//         public UnityEvent CustomEvents
//         {
//             get { return _customEvents; }
//             set { _customEvents = value; }
//         }

//         // private void OnTriggerEnter(Collider other)
//         // {
//         //     ILocomotive locomotive = other.GetComponent<ILocomotive>();

//         //     if (locomotive != null)
//         //     {
//         //         if (_customEvents != null)
//         //             _customEvents.Invoke();
//         //     }
//         // }
//     } 
// }
