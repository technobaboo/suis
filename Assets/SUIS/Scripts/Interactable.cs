using System;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS {
    /// <summary>Class <c>Interactble</c> is an interface to provide
    /// trigger actions on gameObjects.
    ///
    public class Interactable : MonoBehaviour {
        public ActionType actionType;
        public InputType inputType;

        public Transform mainCamera;
        public Vector3 initialHeadVector;

        public TextMesh debugText;
        

        void Start() {
            Vector3 initialHeadVector = mainCamera.forward;
        }
        void Update() {
           if (actionType == ActionType.Flick) {
               if (inputType == Pointer) {
                   FlickByPointer();
               }
           }
        }

        void FlickByPointer() {
            Flick();
        }

        void Flick() {
            Rigidbody rigidGameObject = interact.gameObject.AddComponent<Rigidbody>();
            rigidGameObject.useGravity = false;

            float initialAngle = 0;
            var currentTorque = Vector3.up * (interact.transform.eulerAngles.y - initialAngle) * 10;

            //debugText.text = string.Format("DEBUG: Flick Torque = {0}", currentTorque);

            interact.gameObject.GetComponent<Rigidbody>().AddTorque(currentTorque);
            initialAngle = interact.mainCamera.eulerAngles.y;
        }

        void Scale() {
            Vector3 currentHeadVector = interact.mainCamera.forward;
            var cross = Vector3.Cross(interact.initialHeadVector, currentHeadVector);
            var currentAngle = Vector3.Angle(interact.initialHeadVector, currentHeadVector);
            float scale = currentAngle / 30;

            if (cross.y < -0.5) {
                interact.dataText.text = string.Format("DEBUG: Mostly Left| Angle = {0}", currentAngle);
            } else if (cross.y > 0.5) {
                //interact.dataText.text = string.Format("DEBUG: Mostly Right| Angle = {0}", currentAngle);
            }
            interact.transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
