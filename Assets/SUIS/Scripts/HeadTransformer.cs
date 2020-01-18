using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTransformer : MonoBehaviour
{

  Camera m_MainCamera;
  ActionType actionType;

  void Start()
  {
    m_MainCamera = Camera.main;
    m_MainCamera.enabled = true;
  }

  void Update()
  {
    handleAction(actionType);
  }

  private void handleAction(ActionType actionType)
  {
    if (actionType == ActionType.Scale) {
      ActionTrigger.scaleByVelocity();
    }
  }
}
