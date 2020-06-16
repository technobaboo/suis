using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

namespace SUIS {
    public class HandInput : InputMethod {
        private void Awake() { type = InputType.Hand; }

        protected Hand hand = null;

        public override float distanceToField(Field field) {
            float minDist = float.PositiveInfinity;

            if (hand != null) {
                List<Bone> handBones = new List<Bone>();

                foreach (Finger finger in hand.Fingers)
                    handBones.AddRange(finger.bones);
                foreach (Bone bone in handBones) {
                    float distance = field.distance(bone.Center.ToVector3());
                    minDist = Mathf.Min(minDist, distance);
                }
            }

            return minDist;
        }
    }
}