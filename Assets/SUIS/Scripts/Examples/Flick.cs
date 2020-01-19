using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Flick : MonoBehaviour {
    public TextMesh debugText;
    public Transform mainCamera;
    public Rigidbody rigidbody;
    public float initialAngle;
    public float flickForce = 10.0f;
    public void PerformActionStart() {
        initialAngle = mainCamera.eulerAngles.y;
    }
    public void PerformAction() {
        var currentTorque = Vector3.up * -(mainCamera.eulerAngles.y - initialAngle) * flickForce;
        string logMsg = string.Format("DEBUG: Flick Torque = {0}", currentTorque);
        if (debugText != null)
            debugText.text = logMsg;
        else
            Debug.Log(logMsg);
        rigidbody.AddTorque(currentTorque, ForceMode.Acceleration);
        initialAngle = mainCamera.eulerAngles.y;
    }
}
