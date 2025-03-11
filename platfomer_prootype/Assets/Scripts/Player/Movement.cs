using Collectable;
using UnityEngine;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        private static readonly int IsRunning = Animator.StringToHash("isRunning");
        private static readonly int IsJumping = Animator.StringToHash("isJumping");
        private static readonly int IsFalling = Animator.StringToHash("isFalling");

        [Header("Movement")]
        [Min(1)] [SerializeField] private float moveSpeed = 5f;

        [Header("Jump")]
        [Min(1)] [SerializeField] private float jumpForce = 7f;
        [Min(1)] [SerializeField] private float fallMultiplier = 2f;
        [Space(10)]
        [SerializeField] private Transform groundCheckTransform;
        [SerializeField] private LayerMask groundLayer;
        [Min(0)] [SerializeField] private float raycastDistance = 0.2f;

        private Vector2 _moveValue;
        private PlayerState _playerState = PlayerState.Grounded;

        private PlayerControls _controls;
        private Rigidbody2D _rb;
        private Animator _animator;

        void Awake()
        {
            _controls = new PlayerControls();
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();

            _controls.Movement.Move.performed += ctx => SetMovementValue(ctx.ReadValue<Vector2>());
            _controls.Movement.Move.canceled += _ => SetMovementValue(Vector2.zero);
            _controls.Movement.Jump.performed += _ => Jump();
        }

        private void OnEnable() => _controls.Enable();
        private void OnDisable() => _controls.Disable();

        void FixedUpdate()
        {
            Move();
            ApplyGravity(); 
            UpdateState();
        }

        private void SetMovementValue(Vector2 inputValue)
        {
            _moveValue = inputValue;
            
            _animator.SetBool(IsRunning, _moveValue.x != 0);
        }

        private void Move()
        {
            _rb.linearVelocity = new Vector2(_moveValue.x * moveSpeed, _rb.linearVelocity.y);

            if (_moveValue.x != 0)
                transform.localScale = new Vector3(Mathf.Sign(_moveValue.x), 1, 1);
        }

        private void Jump()
        {
            if (_playerState != PlayerState.Grounded) return;

            _rb.linearVelocity = new(_rb.linearVelocity.x, jumpForce);
            
            SetState(PlayerState.Jumping);
        }

        /// <summary>
        /// Used for faster falling
        /// </summary>
        private void ApplyGravity()
        {
            if (_rb.linearVelocity.y > 0) return; 
         
            _rb.linearVelocity += Vector2.up * (Physics2D.gravity.y * fallMultiplier * Time.fixedDeltaTime);
        }

        /// <summary>
        /// Updating the states
        /// </summary>
        private void UpdateState()
        {
            //if we are on the ground and the state is "not grounded", then set it to grounded
            if (IsGrounded())
            {
                if (_playerState != PlayerState.Grounded)
                    SetState(PlayerState.Grounded);
            }
            else
            {
                //otherwise check if we are falling or jumping
                SetState(_rb.linearVelocity.y < 0 ? PlayerState.Falling : PlayerState.Jumping);
            }
        }

        /// <summary>
        /// Sets the player state
        /// </summary>
        /// <param name="newState">State to set to</param>
        private void SetState(PlayerState newState)
        {
            if (_playerState == newState) return; 
            
            _playerState = newState;

            _animator.SetBool(IsJumping, newState == PlayerState.Jumping);
            _animator.SetBool(IsFalling, newState == PlayerState.Falling);
        }

        /// <summary>
        /// Checks if the player is on the ground
        /// </summary>
        /// <returns>True if is on the ground, false otherwise</returns>
        private bool IsGrounded()
        {
            return Physics2D.Raycast(groundCheckTransform.position, Vector2.down, raycastDistance, groundLayer);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // if we collided with any collectable, collect it
            if (other.TryGetComponent(out ICollectable collectable))
            {
                collectable.Collect();
            }
        }
    }
}
