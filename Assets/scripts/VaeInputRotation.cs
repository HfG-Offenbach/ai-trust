using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaeInputRotation : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField] private Vector3 _rotation;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_rotation * Time.deltaTime);
        // transform.Rotate(0, 1 * Time.deltaTime,0);
    }
}
