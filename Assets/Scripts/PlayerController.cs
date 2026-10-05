using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 5f;
    [SerializeField] private float boostSpeed = 35f;
    [SerializeField] ParticleSystem snowEffect;

    SurfaceEffector2D surfaceEffector2D;
    float defaultSpeed;

    InputAction moveAction;
    Vector2 moveInput;
    Rigidbody2D rb;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
        defaultSpeed = surfaceEffector2D.speed; //stores the initial speed of the SurfaceEffector2D component
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerTorque();
        BoostPlayer();

    }
    
        /// <summary>
        /// Based on the horizontal input, apply torque to the Rigidbody2D to rotate the player
        /// </summary>
    void PlayerTorque()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        if (moveInput.x < 0)
        {
            rb.AddTorque(torqueAmount);
        }
        else if (moveInput.x > 0)
        {
            rb.AddTorque(-torqueAmount);
        }
    }

    void BoostPlayer()
    {
        // Increases player's speed when the arrow key is pressed, surface effector is increased to boostSpeed
        if (moveInput.y > 0)
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = defaultSpeed;
        }

    }

    void OnCollisionEnter2D(Collision2D collission)
    {
        int layerIndex= LayerMask.NameToLayer("Floor");
        if (collission.gameObject.layer == layerIndex)
        {
            snowEffect.Play();
        }
    }

      void OnCollisionExit2D(Collision2D collission)
    {
        int layerIndex= LayerMask.NameToLayer("Floor");
        if (collission.gameObject.layer == layerIndex)
        {
            snowEffect.Stop();
        }
    }
}
