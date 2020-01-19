using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flick : MonoBehaviour {
    public TextMesh debugText;
    public Transform mainCamera;
    public Rigidbody rigidbody;
    public float initialAngle = 0;
    void Update() {
        var currentTorque = Vector3.up * (mainCamera.eulerAngles.y - initialAngle) * 10;
        debugText.text = string.Format("DEBUG: Flick Torque = {0}", currentTorque);
        rigidbody.AddTorque(currentTorque);
        initialAngle = mainCamera.eulerAngles.y;
    }
}
