using System;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS {
    /// <summary>Class <c>Interable</c> is an interface to provide
    /// trigger actions on gameObjects.
    ///
    public class Interactable : MonoBehaviour {
        public ActionType actionType;
        public InputType inputType;
        // public FallbackType fallback;

        public Transform mainCamera;
        public Vector3 initialHeadVector;

        public TextMesh debugText;
        

        void Start() {
            Vector3 initialHeadVector = mainCamera.forward;
        }
        //void Update() {
        //    if (actionType == ActionType.Flick) {
        //        // TODO: Check if input type is available
        //        // if not, use the fallback
        //        FlickMap[inputType]();
        //    } else if (actionType == ActionType.Scale) {
        //        ScaleMap[inputType]();
        //    } else if (actionType == ActionType.Translate) {
        //        TranslateMap[inputType]();
        //    }
        //}

        static void FlickByController(Interactable interact) {
            //
        }
        static void FlickByHand(Interactable interact) {
            
        }
        static void FlickByNonSpatial(Interactable interact) {
            //
        }
        static void FlickByPointer(Interactable interact) {
            Flick(interact);
        }

        static void Flick(Interactable interact) {
            Rigidbody rigidGameObject = interact.gameObject.AddComponent<Rigidbody>();
            rigidGameObject.useGravity = false;

            float initialAngle = 0;
            var currentTorque = Vector3.up * (interact.transform.eulerAngles.y - initialAngle) * 10;

            //debugText.text = string.Format("DEBUG: Flick Torque = {0}", currentTorque);

            interact.gameObject.GetComponent<Rigidbody>().AddTorque(currentTorque);
            initialAngle = interact.mainCamera.eulerAngles.y;
        }

        static void ScaleByController(Transform inputTransform) {
            //
        }
        static void ScaleByHand(Transform inputTransform) {
            //
        }
        static void ScaleByNonSpatial(Interactable interact) {
            //
        }
        static void ScaleByPointer(Interactable interact) {
            Scale(interact);
        }

        static void Scale(Interactable interact) {
            Vector3 currentHeadVector = interact.mainCamera.forward;
            var cross = Vector3.Cross(interact.initialHeadVector, currentHeadVector);
            var currentAngle = Vector3.Angle(interact.initialHeadVector, currentHeadVector);
            float scale = currentAngle / 30;

            if (cross.y < -0.5) {
                //interact.dataText.text = string.Format("DEBUG: Mostly Left| Angle = {0}", currentAngle);
            } else if (cross.y > 0.5) {
                //interact.dataText.text = string.Format("DEBUG: Mostly Right| Angle = {0}", currentAngle);
            }
            interact.transform.localScale = new Vector3(scale, scale, scale);
        }

        static void TranslateByController(Interactable interact) {
            //
        }
        static void TranslateByHand(Interactable interact) {
            //
        }
        static void TranslateByNonSpatial(Interactable interact) {
            //
        }
        static void TranslateByPointer(Interactable interact) {
            //
        }
    }
}
