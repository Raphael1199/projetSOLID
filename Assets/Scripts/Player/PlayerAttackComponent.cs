using UnityEngine;

public class PlayerAttackComponent : MonoBehaviour
{
    [SerializeField]
    private PlayerCharacterController player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // if (Input.GetMouseButton(1))
        // {
        //     player.isAiming = true;
        //     player.AlignPlayerWithCamera();
        // }
        // else
        // {
        //     player.isAiming = false;
        // }

        // if (Input.GetMouseButtonDown(0))
        // {
        //     player.ShootRay();
        // }
    }
}
