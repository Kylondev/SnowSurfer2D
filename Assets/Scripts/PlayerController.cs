using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    InputAction moveAction;
    Vector2 moveInput;

    [SerializeField] private float torqueAmount = 5f;
    Rigidbody2D rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerTorque();

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
}
