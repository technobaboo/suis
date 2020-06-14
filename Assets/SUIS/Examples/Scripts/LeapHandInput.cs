using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

namespace SUIS {
    public class LeapHandInput : HandInput {
        public LeapProvider leapProvider;
        public bool isLeft;

        void FixedUpdate() {
            List<Hand> hands = leapProvider.CurrentFixedFrame.Hands;
            hand = null;
            foreach(Hand hand in hands) {
                if(hand.IsLeft == isLeft) {
                    this.hand = hand;
                    break;
                }
            }
            isTracked = hand != null;
        }
    }
}