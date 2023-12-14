using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCamera : MonoBehaviour
{
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.transform);
        transform.rotation *= Quaternion.FromToRotation(Vector3.up, Vector3.back);
        transform.rotation *= Quaternion.FromToRotation(Vector3.left, Vector3.right);
    }
}
