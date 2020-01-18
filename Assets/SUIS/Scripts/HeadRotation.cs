using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMesh dataText;
    Vector3 initialVector;

    void Start()
    {
        initialVector = Camera.main.transform.forward;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("Initial vector capture");
            initialVector = Camera.main.transform.forward;
        } else {
            Debug.Log("Current vector capture");

            Vector3 currentHeadVector = Camera.main.transform.forward;
            var cross = Vector3.Cross(initialVector, currentHeadVector);
            var vectorAngle = Vector3.Angle(initialVector, currentHeadVector);
            if (cross.y < -0.5) {
                Debug.Log("Mostly left");
                dataText.text = string.Format("Mostly Left| Angle = {0}", vectorAngle);
            } else if (cross.y > 0.5) {
                dataText.text = string.Format("Mostly Right| Angle = {0}", vectorAngle);
            }
            float scale = vectorAngle / 30;
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
