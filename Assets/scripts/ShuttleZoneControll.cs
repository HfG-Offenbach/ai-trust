using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WSMGameStudio.RailroadSystem
{
    public class ShuttleZoneControll : MonoBehaviour
    {

        public Renderer myRenderer;
        public GameObject PseudoLocomotive;


        public GameObject SmallZone;
        public GameObject MediumZone;
        public GameObject BigZone;


        public float SmallZone_MinSize = 8;
        public float SmallZone_MaxSize = 8;

        public float MediumZone_MinSize = 8;
        public float MediumZone_MaxSize = 18;
        
        public float BigZone_MinSize = 8;
        public float BigZone_MaxSize = 30;

        private float SpeedMin = 0;
        private float SpeedMax = 30;
        private float _currentSpeed;


        // Start is called before the first frame update
        void Start()
        {
            myRenderer = gameObject.GetComponent<Renderer>();   

        }

        // Update is called once per frame
        void Update()
        {
            ILocomotive _shuttle = PseudoLocomotive.GetComponent<ILocomotive>();
            _currentSpeed = _shuttle.Speed_MPS;

            // calculate current speed in percentage
            var SpeedPercentage = (_currentSpeed - SpeedMin) / (SpeedMax - SpeedMin);



             
            // scale big zone
            var BigZone_Size = BigZone_MinSize + ((BigZone_MaxSize-BigZone_MinSize) * SpeedPercentage);
            BigZone.transform.localScale = new Vector3(BigZone_Size, 8, BigZone_Size);

            // scale medium zone
            var MediumZone_Size = MediumZone_MinSize + ((MediumZone_MaxSize-MediumZone_MinSize) * SpeedPercentage);
            // MediumZone.transform.localScale = new Vector3(MediumZone_Size, 8, MediumZone_Size);




            // transform.localScale = new Vector3(1, SpeedPercentage, 1);
        }
    }
}
