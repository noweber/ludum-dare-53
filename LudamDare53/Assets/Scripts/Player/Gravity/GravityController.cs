using UnityEngine;

public class GravityController : MonoBehaviour
{
    private IGravityHandler gravityHandler;

    [SerializeField] private float baseGravity = 9.81f;
    [SerializeField] private float gravityMultiplier = 2.0f;
    [SerializeField] private float gravityBaselineHeight = -2.0f;

    private void Start()
    {
        gravityHandler = new Rigidbody2DGravityHandler(gameObject, baseGravity, gravityMultiplier, gravityBaselineHeight);
    }

    private void FixedUpdate()
    {
        try
        {
            gravityHandler.SetGravity(transform.position.y);
        }
        catch (System.NullReferenceException e)
        {
            Debug.LogError($"Failed to set gravity: {e.Message}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Unhandled exception occurred: {e.Message}");
        }
    }
}