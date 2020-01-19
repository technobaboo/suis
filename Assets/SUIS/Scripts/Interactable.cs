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

        private TextMesh debugText;

        Dictionary<InputType, Action> FlickMap = new Dictionary<InputType, Action>() {
            { InputType.Controller, () => FlickByController() },
            { InputType.Hand, () => FlickByHand() },
            { InputType.NonSpatial, () => FlickByNonSpatial() },
            { InputType.Pointer, () => FlickByPointer() }
        };

        Dictionary<InputType, Action> ScaleMap = new Dictionary<InputType, Action>() {
            { InputType.Controller, () => ScaleByController() },
            { InputType.Hand, () => ScaleByHand() },
            { InputType.NonSpatial, () => ScaleByNonSpatial() },
            { InputType.Pointer, () => ScaleByPointer() }
        };

        Dictionary<InputType, Action> TranslateMap = new Dictionary<InputType, Action>() {
            { InputType.Controller, () => TranslateByController() },
            { InputType.Hand, () => TranslateByHand() },
            { InputType.NonSpatial, () => TranslateByNonSpatial() },
            { InputType.Pointer, () => TranslateByPointer() }
        };

        void Start() {
        }
        void Update() {
            if (actionType == ActionType.Flick) {
                // TODO: Check if input type is available
                // if not, use the fallback
                FlickMap[inputType]();
            } else if (actionType == ActionType.Scale) {
                ScaleMap[inputType]();
            } else if (actionType == ActionType.Translate) {
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
