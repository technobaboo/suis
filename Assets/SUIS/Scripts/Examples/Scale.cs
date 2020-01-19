using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour {
    public TextMesh debugText;
    public Transform mainCamera;
    public Vector3 initialHeadVector;

    public void PerformActionStart() {
        initialHeadVector = mainCamera.forward;
    }
    public void PerformAction() {
        if (Input.GetKeyDown(KeyCode.R)) {
            initialHeadVector = mainCamera.forward;
        } else {
            Vector3 currentHeadVector = mainCamera.forward;
            var cross = Vector3.Cross(initialHeadVector, currentHeadVector);
            var currentAngle = Vector3.Angle(initialHeadVector, currentHeadVector);
            float scale = currentAngle / 30;

            if (cross.y < -0.5) {
                string logMessage = string.Format("DEBUG: Mostly Left| Angle = {0}", currentAngle);
                SetLog(logMessage);
            } else if (cross.y > 0.5) {
                string logMessage = string.Format("DEBUG: Mostly Right| Angle = {0}", currentAngle);
                SetLog(logMessage);
            }
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    private void SetLog(string logMessage) {
        if (debugText != null) {
            debugText.text = logMessage;
        } else {
            Debug.Log(logMessage);
        }
    }
}
