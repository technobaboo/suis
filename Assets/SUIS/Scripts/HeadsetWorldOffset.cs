using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadsetWorldOffset : MonoBehaviour {
    public Vector3 startHeadPoint = Vector3.zero;

    void Start() {
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart() {
        yield return new WaitForSecondsRealtime(0.5f);
        Transform headset = transform.GetChild(0);
        transform.position = startHeadPoint - headset.position;
    }
}
