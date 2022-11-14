using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float Smoothing;

    private Vector3 Offset;

    void Start()
    {
        Offset = transform.position - Target.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newCameraPosition = Target.position + Offset;
        transform.position = newCameraPosition;
        //transform.position = Vector3.Lerp(transform.position, newCameraPosition, Smoothing * Time.deltaTime);
    }
}
