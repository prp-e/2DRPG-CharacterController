using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Rigidbody2D cameraRigidbody;

    // Target
    public Transform targetTransform;

    // Settings
    public Vector3 cameraPositionOffset;
    public float cameraSpeed;

    // Start is called before the first frame update
    void Start()
    {
        cameraRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move Camera
        cameraRigidbody.AddRelativeForce((targetTransform.position - transform.position) * cameraSpeed, ForceMode2D.Force);
    }
}
