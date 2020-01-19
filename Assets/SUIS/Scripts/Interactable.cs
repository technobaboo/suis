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
            //
        }
        static void FlickByNonSpatial() {
            //
        }
        static void FlickByPointer() {
            //
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
            //
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
