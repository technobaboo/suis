using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyRotation : MonoBehaviour {
    public Transform target;
    public Rigidbody rigidbody;
    public float oldAngle = 0;
    void Update() {
        rigidbody.AddTorque(Vector3.up * (target.eulerAngles.y - oldAngle) * 10);
        oldAngle = target.eulerAngles.y;
    }
}
