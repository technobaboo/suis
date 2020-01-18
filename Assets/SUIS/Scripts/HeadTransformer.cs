using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS
{
    [RequireComponent(typeof(Rigidbody))]
    public class HeadTransformer : MonoBehaviour
    {

        private Camera mainCamera;
        private Vector3 startForward;
        private Vector3 startEulerAngles;
        private Vector3 startScale;

        void Start(){
            mainCamera = Camera.main;
            startForward = mainCamera.transform.forward;
            startEulerAngles = mainCamera.transform.eulerAngles;
            startScale = transform.lossyScale;
        }

        void FixedUpdate() {
            float scale = (transform.eulerAngles.x - startEulerAngles.x)/90;
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
