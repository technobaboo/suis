using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionTrigger : MonoBehaviour {
  public static ActionType actionType;
  public event ActionTriggerEvent Ev;

  void Startup () {
    //
  }

  bool isPerformingAction() {
    return true;
  }
}
