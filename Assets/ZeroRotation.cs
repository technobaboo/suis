using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroRotation : MonoBehaviour
{
    private void LateUpdate() {
        transform.localRotation = Quaternion.identity;
    }
}
