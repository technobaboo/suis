using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS {
    /// <summary>Class <c>Manager</c> determines which interactable
    /// should be used at any given frame based on "staring".</summary>
    ///
    public class Manager : MonoBehaviour {
        private Transform mainCamera;
        private Material initialMaterial;
        private Transform currentSelection;

        [SerializeField] public Material highlightMaterial;


        public float lockTime = 5.0f;
        public float runningTime = 0f;
        void Start() {
            Vector3 startCameraPosition = mainCamera.position;
        }

        void Update() {
            RaycastHit hit;

            if (currentSelection != null) {

            }

            if(
                Physics.Raycast(
                    mainCamera.position,
                    mainCamera.forward,
                    out hit,
                    500
                ) == true
            ) {
                runningTime += Time.deltaTime * 1;

                if (runningTime > lockTime) {
                    Select(hit.transform);
                    // perform action
                    Reset();
                }
            } else {
                Reset();
            }
        }

        void Select(Transform toSelect) {
            currentSelection = toSelect;
            var selectionRenderer = currentSelection.GetComponent<Renderer>();
            if (selectionRenderer != null) {
                selectionRenderer.material = highlightMaterial;
            }
        }

        void Reset() {
            currentSelection = null;
            var selectionRenderer = currentSelection.GetComponent<Renderer>();
            selectionRenderer.material = initialMaterial;
            runningTime = 0f;
        }

    }
}