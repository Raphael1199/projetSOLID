using UnityEngine;
using StarterAssets;

public class PlayerCharacterController : ThirdPersonController
{
    //////////////////////////////////////////////////////
    //A changer pour mettre la range des armes
    public int ___range = 6942;
    [SerializeField]
    private PlayerCharacter playerCharacter;
    private bool isAiming = false;
    [SerializeField]
    private LayerMask ShootingMask;


    protected override void Move()
    {
        // set target speed based on move speed, sprint speed and if sprint is pressed
        float targetSpeed = _input.sprint ? SprintSpeed : MoveSpeed;

        // a simplistic acceleration and deceleration designed to be easy to remove, replace, or iterate upon

        // note: Vector2's == operator uses approximation so is not floating point error prone, and is cheaper than magnitude
        // if there is no input, set the target speed to 0
        if (_input.move == Vector2.zero) targetSpeed = 0.0f;

        // a reference to the players current horizontal velocity
        float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;

        float speedOffset = 0.1f;
        float inputMagnitude = _input.analogMovement ? _input.move.magnitude : 1f;

        // accelerate or decelerate to target speed
        if (currentHorizontalSpeed < targetSpeed - speedOffset ||
            currentHorizontalSpeed > targetSpeed + speedOffset)
        {
            // creates curved result rather than a linear one giving a more organic speed change
            // note T in Lerp is clamped, so we don't need to clamp our speed
            _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude,
                Time.deltaTime * SpeedChangeRate);

            // round speed to 3 decimal places
            _speed = Mathf.Round(_speed * 1000f) / 1000f;
        }
        else
        {
            _speed = targetSpeed;
        }

        _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * SpeedChangeRate);
        if (_animationBlend < 0.01f) _animationBlend = 0f;

        // normalise input direction
        Vector3 inputDirection = new Vector3(_input.move.x, 0.0f, _input.move.y).normalized;

        // note: Vector2's != operator uses approximation so is not floating point error prone, and is cheaper than magnitude
        // if there is a move input rotate player when the player is moving
        if (_input.move != Vector2.zero)
        {
            _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg +
                              _mainCamera.transform.eulerAngles.y;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
                RotationSmoothTime);

            // rotate to face input direction relative to camera position
            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        }

        Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;


        // move the player
        _controller.Move(targetDirection.normalized * (_speed * Time.deltaTime) +
                         new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);

        // update animator if using character
        if (_hasAnimator)
        {
            _animator.SetFloat(_animIDSpeed, _animationBlend);
            _animator.SetFloat(_animIDMotionSpeed, inputMagnitude);
        }
    }

    public void SetIsAiming(bool value)
    {
        isAiming = value;
    }

    protected override void Update()
    {
        // 1. On appelle l'Update de base pour garder les mouvements
        base.Update();

        // 2. Détecter si on maintient le clic droit (bouton 1)
        if (Input.GetMouseButton(1))
        {
            isAiming = true;
            AlignPlayerWithCamera();
        }
        else
        {
            isAiming = false;
        }

        //3
        if (Input.GetMouseButtonDown(0))
        {
            // playerCharacter.getEquipements().GetWeapon().Attack();
            if (playerCharacter.getEquipements().GetWeapon() != null)
            {
                ShootRay(playerCharacter.getEquipements().GetWeapon().getRange());
            }


        }
    }

    public void AlignPlayerWithCamera()
    {
        // On récupère la rotation de la caméra sur l'axe Y (Y seulement pour éviter que le perso penche)
        float yawCamera = Camera.main.transform.eulerAngles.y;

        // On applique cette rotation au personnage
        transform.rotation = Quaternion.Euler(0f, yawCamera, 0f);

        // ASTUCE : Pour empêcher le script de base de surcharger la rotation,
        // on force la rotation cible interne à celle de la caméra.
        // Comme nous héritons de ThirdPersonController, nous pouvons modifier ses variables protégées.
        // Note: Selon la version, il faudra peut-être ajuster "_targetRotation"
    }

    public void ShootRay(int range)
    {
        // 1. Définir le rayon partant du centre de l'écran
        // Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        float raycastLength = transform.position.x - _mainCamera.transform.position.x;

        // 2. Lancer le rayon vers là ou on regarde
        if (Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.forward, out hit, (int)raycastLength + range, ShootingMask))
        {
            Debug.Log("Objet touché : " + hit.collider.name);

            // Optionnel : Dessiner une ligne dans l'éditeur pour déboguer
            Debug.DrawLine(_mainCamera.transform.position, hit.point, Color.red, 2.0f);

            hit.transform.TryGetComponent<IAttackable>(out IAttackable target);

            if (target != null)
            {
                playerCharacter.getEquipements().GetWeapon().Attack(target);
                target.PlayhitFx(playerCharacter.getEquipements().GetWeapon().getHitFX(), hit.point);
            }

        }
        else
        {
            Debug.DrawRay(_mainCamera.transform.position, transform.TransformDirection(_mainCamera.transform.forward) * ((int)raycastLength + range), Color.white);
        }
    }
}
