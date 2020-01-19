using UnityEngine;
using UnityEngine.XR;

public class NegateTracking : MonoBehaviour {
    void Update() {
        transform.localPosition = -InputTracking.GetLocalPosition(XRNode.CenterEye);
        transform.localRotation = Quaternion.Inverse(InputTracking.GetLocalRotation(XRNode.CenterEye));
    }
}
