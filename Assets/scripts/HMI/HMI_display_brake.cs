using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WSMGameStudio.RailroadSystem
{
    public class HMI_display_brake : MonoBehaviour
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
    
        private float deceleration;

        public Color myColor;
        public float r_color;
        public float g_color;
        public float b_color;
        public float a_color;

        public float acceleration;
        public float distancemoved=0;
        public float lastdistancemoved=0;
        public Vector3 last;



        // Start is called before the first frame update
        void Start()
        {
            // StartCoroutine(CalcSpeed());
            a_color = 1;
            // r_color = 5;
            myRenderer = gameObject.GetComponent<Renderer>();   
        }

        // Update is called once per frame
        void Update()
        {
            ILocomotive _shuttle = PseudoLocomotive.GetComponent<ILocomotive>();

            // GameObject Shuttle = GameObject.Find("Shuttle");
            // ILocomotive _shuttle = Shuttle.GetComponent<ILocomotive>();
            
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

             Debug.Log("acceleration: "+acceleration);
            if (acceleration > 0 ){
                r_color = 0;
                a_color = 0;
                myColor = new Color(r_color, g_color, b_color, a_color);
                myRenderer.material.color = myColor;
                // Debug.Log("acceleration >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> bigger 0");
            }
            if (acceleration == 0){
                r_color = 0;
                a_color = 0;
                myColor = new Color(r_color, g_color, b_color, a_color);
                myRenderer.material.color = myColor;
                // Debug.Log("acceleration ================================ equal 0");
        }
            if (acceleration < -70){
                r_color = 255;
                a_color = 255;
                myColor = new Color(r_color, g_color, b_color, a_color);
                myRenderer.material.color = myColor;
                // Debug.Log("acceleration <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< smaller 0");
            }
            


            
        }
    }
}