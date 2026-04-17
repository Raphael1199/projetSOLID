using UnityEngine;

public abstract class MovingObject : LivingObject
{

    [Header("MovingObject SETTINGS")]
    [Header("REFERENCES")]
    [SerializeField]
    private CharacterController characterController;

    [SerializeField]
    protected Transform target;

    [Header("MOVEMENTS SETTINGS")]
    [SerializeField]
    private float moveSpeed = 3f;

    [Header("GRAVITY SETTINGS")]
    [SerializeField]
    private bool useGravity = true;

    [SerializeField]
    private float gravity = -9.81f;

    private float ySpeed;
    protected int currentNodeIndex = -1;

    [SerializeField]
    Vector3 step;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void Update()
    {

        if (target != null)
        {
            Vector3 targetPos = target.position;

            Vector3 dir = targetPos - transform.position;
            dir.Normalize();

            Quaternion targetRot = Quaternion.LookRotation(dir);
            targetRot.x = 0;
            targetRot.z = 0;
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRot,
                100
            );

            step = transform.forward * (moveSpeed * Time.deltaTime);
        }
        else
        {
            step = Vector3.zero;
        }

        if (useGravity)
        {
            ySpeed += gravity * Time.deltaTime;
            step.y += ySpeed * Time.deltaTime;
        }

        if (useGravity && characterController.isGrounded)
        {
            ySpeed = 0;
        }

        characterController.Move(step);
    }

    void OnTriggerEnter(Collider other)
    {
        other.transform.TryGetComponent<PlayerCharacter>(out PlayerCharacter player);
        if (player != null)
        {
            target = player.transform;
        }
    }

}
