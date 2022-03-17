using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    
    public bool mouseControl;
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;


    public float speedH = 2.0f;
    public float speedV = 2.0f;
    private float yaw = 180.0f;
    private float pitch = 0.0f;

    void Update()
    {
        // Read Mouse Event and translate to yaw and pitch
        if(mouseControl == true){
        Cursor.visible = false;
         yaw += speedH * Input.GetAxis("Mouse X");
         pitch += speedV * -Input.GetAxis("Mouse Y");
         transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }

        // ============================================================== hot keys --> C --> Camera Mouse Controll (on/off)
        if (Input.GetKeyUp(KeyCode.C)){ 
            if(mouseControl == false){
                mouseControl = true;
            }else{
                mouseControl = false;
            }
        }

    }

    void LateUpdate(){
        // transform.position = target.position + offset;
        // transform.rotation = target.rotation;
    }
}
