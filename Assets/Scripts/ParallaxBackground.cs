using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float parallaxMultiplier = 0.3f;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        float parallaxMultiplier = 0.5f;
        transform.position += deltaMovement * parallaxMultiplier;
        lastCameraPosition = cameraTransform.position;
    }
}
