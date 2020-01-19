using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroPosition : MonoBehaviour
{
    private void Update() {
        transform.localPosition = Vector3.zero;
    }
}
