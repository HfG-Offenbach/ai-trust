using UnityEngine;
using UnityEngine.Serialization;

namespace WSMGameStudio.RailroadSystem
{
public class HMI_display_brake_red : MonoBehaviour
{

    private float _currentSpeed;
    private float deceleration;
    private float _KPH;

    private float lastSpeed;
    // public float speed;

    public Color myColor;
    public float r_color;
    public float g_color;
    public float b_color;
    public float a_color;

    public float acceleration;
    public float distancemoved=0;
    public float lastdistancemoved=0;
    public Vector3 last;


    public Renderer myRenderer;

    // private static; 

    void Start(){
        // StartCoroutine(CalcSpeed());
        a_color = 1;
        // r_color = 5;
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    // IEnumerator CalcSpeed(){
    //     bool isPlaying = true;
    //     while (isPlaying){
    //         Vector3 prevPos = transform.position;
    //         yield return new WaitForFixedUpdate();
    //         speed = Mathf.RoundToInt(Vector3.Distance(transform.position, prevPos) / Time.fixedDeltaTime);
    //     }
    // }


    void Update ()
    {
        GameObject Shuttle = GameObject.Find("Shuttle");
        ILocomotive _shuttle = Shuttle.GetComponent<ILocomotive>();

        _currentSpeed = _shuttle.Speed_MPS;
        _KPH = _shuttle.Speed_KPH;

        var acceleration = ((_currentSpeed - lastSpeed) / Time.deltaTime);
        lastSpeed = _currentSpeed;


        // Debug.Log("speed --------------> " + _KPH);
        // Debug.Log("deceleration -----------------> " + acceleration);


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
          if (acceleration < -10){
            r_color = 200;
            a_color = 255;
            myColor = new Color(r_color, g_color, b_color, a_color);
            myRenderer.material.color = myColor;
            // Debug.Log("acceleration <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< smaller 0");
        }


        // Debug.Log("Speed: " + speed.ToString("F2"));
        // Debug.Log("acceleration: " + acceleration);
        
        // if (Input.GetKey(KeyCode.A)){
            // r_color = 1;
        // }
    }
}
}
