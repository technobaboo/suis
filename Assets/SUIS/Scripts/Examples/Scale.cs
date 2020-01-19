using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public TextMesh dataText;
    Vector3 initialHeadVector;

    void Start() {
        initialHeadVector = Camera.main.transform.forward;
    }

    void Update() {
        // TODO: Replace key press with stare to reset the initial vector
        if (Input.GetKeyDown(KeyCode.R)) {
            initialHeadVector = Camera.main.transform.forward;
        } else {
            Vector3 currentHeadVector = Camera.main.transform.forward;
            var cross = Vector3.Cross(initialHeadVector, currentHeadVector);
            var currentAngle = Vector3.Angle(initialHeadVector, currentHeadVector);
            float scale = currentAngle / 30;

            if (cross.y < -0.5) {
                dataText.text = string.Format("DEBUG: Mostly Left| Angle = {0}", currentAngle);
            } else if (cross.y > 0.5) {
                dataText.text = string.Format("DEBUG: Mostly Right| Angle = {0}", currentAngle);
            }

            transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
