using UnityEngine;

public class MovingObject : LivingObject
{
    
    [Header("MovingObject SETTINGS")]
    [Header("REFERENCES")]
    [SerializeField]
    private CharacterController characterController;

    [SerializeField]
    protected Transform target;

    [SerializeField]
    protected Transform finalTarget;

    [Header("MOVEMENTS SETTINGS")]
    [SerializeField]
    private float moveSpeed = 3f;

    [Header("GRAVITY SETTINGS")]
    [SerializeField]
    private bool useGravity = true;

    [SerializeField]
    private float gravity = 9.81f;

    private float Speed;
    protected int currentNodeIndex = -1;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
