using UnityEngine;

public class Rigidbody2dMover : MonoBehaviour
{
    [Min(0)]
    [SerializeField] protected float Speed = 5f;

    [SerializeField] protected Vector2 Direction = Vector2.zero;

    [Min(0)]
    [SerializeField] private float RandomSpeedMagnitude = 2f;

    [Range(0, 1)]
    [SerializeField] private float RandomDeltaSpeedFactor = 0.8f;

    [SerializeField] private bool ShouldRandomizeSpeed = true;

    [SerializeField] private bool MoveAlongYAxis = true;

    protected Rigidbody2D Rigidbody;

    private void Awake()
    {
        if (ShouldRandomizeSpeed)
        {
            Speed = Random.Range(Speed - RandomSpeedMagnitude, Speed + RandomSpeedMagnitude);
        }
        if (Speed < 0)
        {
            Speed = 0;
        }
    }

    protected virtual void Start() => Rigidbody = GetComponent<Rigidbody2D>();

    protected Rigidbody2dMover Initialize(Vector2 direction, float? speed = null)
    {
        Direction = direction;
        if (speed != null && speed.HasValue)
        {
            Speed = speed.Value;
        }
        return this;
    }

    protected virtual void FixedUpdate()
    {
        if (Direction == Vector2.zero)
        {
            Destroy(gameObject); return;
        }

        MoveRigidbody();
    }

    protected virtual Vector2 GetMovementDirection()
    {
        var direction = Direction.normalized;
        if (!MoveAlongYAxis)
        {
            direction.y = 0;
        }
        return direction;
    }

    protected virtual float GetDeltaSpeed()
    {
        return Random.Range(RandomDeltaSpeedFactor * Speed, Speed);
    }

    protected virtual void MoveRigidbody()
    {
        if (Rigidbody != null && Direction != null)
        {
            if (MoveAlongYAxis)
            {
                Rigidbody.velocity = GetMovementDirection() * GetDeltaSpeed();
            }
            else
            {
                Rigidbody.velocity = new Vector2(GetMovementDirection().x * GetDeltaSpeed() - Rigidbody.velocity.x, Rigidbody.velocity.y);
            }
        }
    }
}
