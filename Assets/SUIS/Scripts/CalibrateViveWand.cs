using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CalibrateViveWand : MonoBehaviour {
    public Transform virtualWand;
    public Transform calibrationWand;

    private void Update() {
        if(SteamVR_Input.GetStateDown("recalibrate", SteamVR_Input_Sources.Any)) {
            Vector3 delta = transform.GetChild(0).position - virtualWand.position;
            virtualWand.parent.position = delta / 1;
        }
    }
}
