using System.Collections;
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

        private Transform mainCamera;
        private Transform initialHeadVector;

        private TextMesh debugText;

        var FlickMap = new Dictionary<InputType, Action>() {
            { Controller, () => FlickByController() },
            { Hand, () => FlickByHand() },
            { NonSpatial, () => FlickByNonSpatial() },
            { Pointer, () => FlickByPointer() }
        };

        var ScaleMap = new Dictionary<InputType, Action>() {
            { Controller, () => ScaleByController() },
            { Hand, () => ScaleByHand() },
            { NonSpatial, () => ScaleByNonSpatial() },
            { Pointer, () => ScaleByPointer() }
        };

        var TranslateMap = new Dictionary<InputType, Action>() {
            { Controller, () => TranslateByController() },
            { Hand, () => TranslateByHand() },
            { NonSpatial, () => TranslateByNonSpatial() },
            { Pointer, () => TranslateByPointer() }
        };

        void Start() {
            Vector3 initialHeadVector = mainCamera.forward;
        }
        void Update() {
            if (actionType == Flick) {
                // TODO: Check if input type is available
                // if not, use the fallback
                FlickMap[inputType]();
            } else if (actionType == Scale) {
                ScaleMap[inputType]();
            } else if (actionType == Translate) {
                TranslateMap[inputType]();
            }
        }

        static void FlickByController() {
            //
        }
        static void FlickByHand() {
            
        }
        static void FlickByNonSpatial() {
            //
        }
        static void FlickByPointer() {
            Flick(mainCamera);
        }

        static void Flick(Transform inputTransform) {
            RigidBody rigidGameObject = gameObject.AddComponent<RigidBody>();
            rigidGameObject.useGravity = false;

            float initialAngle = 0;
            var currentTorque = Vector3.up * (inputTransform.eulerAngles.y - initialAngle) * 10;

            debugText.text = string.Format("DEBUG: Flick Torque = {0}", currentTorque);

            rigidbody.AddTorque(currentTorque);
            initialAngle = mainCamera.eulerAngles.y;
        }

        static void ScaleByController() {
            //
        }
        static void ScaleByHand() {
            //
        }
        static void ScaleByNonSpatial() {
            //
        }
        static void ScaleByPointer() {
            Scale();
        }

        static void Scale() {
            Vector3 currentHeadVector = mainCamera.forward;
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

        static void TranslateByController() {
            //
        }
        static void TranslateByHand() {
            //
        }
        static void TranslateByNonSpatial() {
            //
        }
        static void TranslateByPointer() {
            //
        }
    }
}
