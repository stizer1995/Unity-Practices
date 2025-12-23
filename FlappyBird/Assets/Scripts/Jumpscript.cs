using UnityEngine;
using UnityEngine.InputSystem; 

public class Example : MonoBehaviour
{

    public InputActionAsset InputActions; 
     
    private InputAction jumpAction;

    private Rigidbody2D rb; 

    public float jumpForce = 10f;

    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {  
        InputActions.FindActionMap("Player").Disable();
    }

    private void Awake () { 
        
        jumpAction = InputActions.FindAction("Jump");
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
       if(jumpAction.WasCompletedThisFrame())
       {
            Jump();
        }
    }

    public void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        
    }
}
