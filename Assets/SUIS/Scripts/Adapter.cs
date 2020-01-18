using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adapter : MonoBehaviour {

  public InputType inputType;
  public ActionType actionType;

  void Start() {
    m_MainCamera = Camera.main;
    m_MainCamera.enabled = true;
  }

  void Update() {
    if (inputType == InputType.Head)
    {
      HeadTransformer.handleAction(actionType);
    }
  }
}
