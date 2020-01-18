// Detect an action on the object

public abstract class ActionTrigger : MonoBehaviour {
  public static ActionType actionType;
  public event ActionTriggerEvent Ev;

  void Startup () {
    //
  }

  pure isPerformingAction() {
    return true;
  }
}
