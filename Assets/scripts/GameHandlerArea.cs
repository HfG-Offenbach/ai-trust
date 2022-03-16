using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WSMGameStudio.RailroadSystem
{
    public class GameHandlerArea : MonoBehaviour
    {
        public GameObject BlackBoxForRouteSwitches;
        public GameObject PseudoLocomotive;
        public GameObject TrainSpawner;
        public GameObject RouteManager;

        // public Color myColor;


        // public bool firstTimeTriggerOn = true;
        // private bool triggerOn = false;
        
        // private float timeFreeze;

        // Start is called before the first frame update
        void Start(){
        }

        // Update is called once per frame
        async void Update(){
        }
        
        void OnTriggerEnter(Collider other){
            if (other.CompareTag("StartTransitionToNextRoute")){
                    // Debug.Log("routes 1: " + RouteManager.GetComponent<RouteManager>().Routes[1].routeIndex);
                    // Debug.Log("routes 1: " + TrainSpawner.GetComponent<TrainSpawner>().targetRails[2]);

                // foreach(List go in  RouteManager.GetComponent<RouteManager>().Routes){
                //     // go.name = "Player";
                
                //     Debug.Log("routes array: " + go.name);
                // }

                StartCoroutine(sceneFadeIn(3));
                // PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn = true;
            }
        }

        void OnTriggerExit(Collider other){
            // check if Object with tag "StartTransitionToNextRoute" exits Collider
            if (other.CompareTag("StartTransitionToNextRoute")){
                // turn off engine
                PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn = false;
                // fade in BlackBox around Shuttle to create transition to next route
                StartCoroutine(sceneFadeOut(3));
                // StartCoroutine(placeShuttleOnNextRoute(4));
            }

        }

        IEnumerator sceneFadeOut(float duration){
            float counter = 0;
            //Get current color
            Color spriteColor = BlackBoxForRouteSwitches.GetComponent<Renderer>().material.color;
            while (counter < duration){
                counter += Time.deltaTime;
                //Fade from 0 to 1
                float alpha = Mathf.Lerp(0, 1, counter / duration);
                Debug.Log(alpha);
                //Change alpha only
                BlackBoxForRouteSwitches.GetComponent<Renderer>().material.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
                //Wait for a frame
                yield return null;
            }
            // PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn = false;
            // yield return new WaitForSeconds(3);


        }
        IEnumerator sceneFadeIn(float duration){
            Color spriteColor = BlackBoxForRouteSwitches.GetComponent<Renderer>().material.color;
            BlackBoxForRouteSwitches.GetComponent<Renderer>().material.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, 1);

            yield return new WaitForSeconds(4);

            float counter = 0;
            //Get current color
            while (counter < duration){
                counter += Time.deltaTime;
                //Fade from 0 to 1
                float alpha = Mathf.Lerp(1, 0, counter / duration);
                Debug.Log(alpha);
                //Change alpha only
                BlackBoxForRouteSwitches.GetComponent<Renderer>().material.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
                //Wait for a frame
                yield return null;
            }
            

            PseudoLocomotive.GetComponent<SplineBasedLocomotive>().EnginesOn = true;

        }
        // IEnumerator placeShuttleOnNextRoute(float waitForNextRoute){
        //     yield return new WaitForSeconds(waitForNextRoute);
        //     // TrainSpawner.GetComponent<TrainSpawner>().PositionAlongRails = 0f;
        //     Debug.Log("start next Route");
        // }
    }
}


// coder on the dance floor