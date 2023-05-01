using UnityEngine;
using UnityEngine.UIElements;

public class Rigidbody2DGravityHandler : IGravityHandler
{
    private Rigidbody2D rb;
    private float baseGravity;
    private float gravityMultiplier;
    private float baselineGravityHeight;

    public Rigidbody2DGravityHandler(GameObject obj, float baseGravity, float gravityMultiplier, float baselineHeight)
    {
        this.rb = obj.GetComponent<Rigidbody2D>();
        this.baseGravity = baseGravity;
        this.gravityMultiplier = gravityMultiplier;
        this.baselineGravityHeight = baselineHeight;
    }

    public void SetGravity(float yPosition)
    {
        if (rb != null)
        {
            if (yPosition <= baselineGravityHeight)
            {
                rb.gravityScale = 0.0f;
            }
            else
            {
                float newGravity = baseGravity * Mathf.Pow(gravityMultiplier, yPosition);
                rb.gravityScale = newGravity;
            }
        }
    }
}