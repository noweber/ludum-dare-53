using UnityEngine;

public class SimultaneousKeyPressTrigger : MonoBehaviour
{
    [SerializeField] private KeyCode[] keyCodesToWaitFor;  // An array of key codes to wait for
    [SerializeField] private GameObject[] gameObjectsToActivate;  // The game object to deactivate
    [SerializeField] private GameObject[] gameObjectsToDectivate;  // The game object to activate

    private void Update()
    {
        if (AllKeysPressedSimultaneously())
        {
            HandleTriggerConditionMet();
        }
    }

    private bool AllKeysPressedSimultaneously()
    {
        foreach (KeyCode keyCode in keyCodesToWaitFor)
        {
            if (!Input.GetKey(keyCode))
            {
                return false;
            }
        }

        return true;
    }

    protected virtual void HandleTriggerConditionMet()
    {
        if (gameObjectsToActivate != null)
        {
            foreach (GameObject toActivate in gameObjectsToActivate)
            {
                toActivate.SetActive(true);
            }
        }
        if (gameObjectsToActivate != null)
        {
            foreach (GameObject toDeactivate in gameObjectsToDectivate)
            {
                toDeactivate.SetActive(false);
            }
        }
    }
}