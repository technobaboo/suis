using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Flick : MonoBehaviour {
    public TextMesh debugText;
    public Transform mainCamera;
    public Rigidbody rigidbody;
    public float currentAngle;
    public float flickForce = 10.0f;

    public void PerformActionStart() {
        currentAngle = mainCamera.eulerAngles.y;
    }
    public void PerformAction() {
        var currentTorque = Vector3.up * -(mainCamera.eulerAngles.y - currentAngle) * flickForce;
        string logMessage = string.Format("DEBUG: Flick Torque = {0}", currentTorque);
        SetLog(logMessage);
        rigidbody.AddTorque(currentTorque, ForceMode.Acceleration);
        currentAngle = mainCamera.eulerAngles.y;
    }

    private void SetLog(string logMessage) {
        if (debugText != null) {
            debugText.text = logMessage;
        } else {
            Debug.Log(logMessage);
        }
    }
}
