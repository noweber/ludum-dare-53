using UnityEngine;

public class Rigidbody2dTargetChaser : Rigidbody2dMover
{
    [SerializeField] protected GameObject Target;

    [SerializeField] protected bool ShouldFollowTarget = true;

    public virtual Rigidbody2dTargetChaser Initialize(GameObject target, bool shouldFollowTarget = true)
    {
        SetFollowTargetState(shouldFollowTarget);
        SetTarget(target);
        return this;
    }

    public void SetTarget(GameObject target)
    {
        Target = target;
        Direction = GetDirection();
    }

    public void SetFollowTargetState(bool state)
    {
        ShouldFollowTarget = state;
    }

    protected override void FixedUpdate()
    {
        if (ShouldFollowTarget)
        {
            Direction = GetDirection();
        }
        base.FixedUpdate();
    }

    protected virtual Vector3 GetDirection()
    {
        if (Target == null)
        {
            return Vector3.zero;
        }
        else
        {
            return Target.transform.position - gameObject.transform.position;
        }
    }
}