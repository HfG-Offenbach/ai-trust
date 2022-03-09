using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WSMGameStudio.RailroadSystem
{
    public class CarStopShuttle : MonoBehaviour
    {

        public Renderer myRenderer;

        public GameObject PseudoLocomotive;
        public GameObject BrakeNotificaitonBar;
        public GameObject BrakeLights;
        public bool shuttleReadyToStart = true;

        private bool shuttleFirstBraking = true;

        public float timingOfNotification = 1.0f;

        // Start is called before the first frame update
        void Start()
        {
            myRenderer = gameObject.GetComponent<Renderer>();  
        }

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(activateNotificationSignal());
            StartCoroutine(activeBrake());
            StartCoroutine(activateEngine());
        }

        IEnumerator activateNotificationSignal(){      
            // change color of car
            var myColor = new Color(255, 0, 0, 0.1f);
            myRenderer.material.color = myColor;

            yield return new WaitForSeconds(timingOfNotification);
            if(shuttleFirstBraking){
                BrakeNotificaitonBar.GetComponent<MeshRenderer>().enabled = true;
            }
            shuttleFirstBraking = false;

            // BrakeNotificaitonBar.GetComponent<MeshRenderer>().enabled = true;
            Debug.Log("notifictation signal: " + Time.time);
            // yield return new WaitForSeconds(0.5f);
            // BrakeNotificaitonBar.GetComponent<MeshRenderer>().enabled = false;


            

        }
        IEnumerator activeBrake(){
            yield return new WaitForSeconds(1f);
            BrakeNotificaitonBar.GetComponent<MeshRenderer>().enabled = false;
            BrakeLights.GetComponent<MeshRenderer>().enabled = true;
            Debug.Log("activate brake: " + Time.time);
            PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn = false;
            PseudoLocomotive.GetComponent<SplineBasedLocomotive>().BrakingDecelerationRate = 40f;
        }
        IEnumerator activateEngine(){
            // yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(3);
            BrakeLights.GetComponent<MeshRenderer>().enabled = false;

            Debug.Log("start engine: " + Time.time);
            shuttleReadyToStart = true;
            Debug.Log("ready to go? :" + shuttleReadyToStart);
            PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn = true;
            PseudoLocomotive.GetComponent<SplineBasedLocomotive>().BrakingDecelerationRate = 6f;

            shuttleFirstBraking = true;
        }

        // Update is called once per frame
        void Update()
        {
            // ============================================================== hot keys --> 1 --> 
            if (Input.GetKeyUp(KeyCode.Alpha1)){
                timingOfNotification = 1.0f;
            }
            // ============================================================== hot keys --> 5 --> 
            if (Input.GetKeyUp(KeyCode.Alpha5)){
                timingOfNotification = 0.5f;
            }
            // ============================================================== hot keys --> 0 --> 
            if (Input.GetKeyUp(KeyCode.Alpha0)){
                timingOfNotification = 0.0f;
            }

        }
    }
}