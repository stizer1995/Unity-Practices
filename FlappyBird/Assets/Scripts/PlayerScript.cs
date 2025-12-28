using UnityEngine;
using UnityEngine.InputSystem; 

public class Example : MonoBehaviour
{

    public InputActionAsset InputActions; 
     
    private InputAction jumpAction;

    private Rigidbody2D rb; 

    public float jumpForce = 10f;

    private LogicScript logic;


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
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    private void Update()
    {
        if (!logic.birdIsAlive) return;

        if (jumpAction.WasCompletedThisFrame()){
            Jump();
        }
    }



    public void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        AudioManager.instance.PlaySFX(AudioManager.instance.jump, 0.5f);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            rb.angularVelocity = 300f;
            rb.gravityScale = 4f;
            logic.gameOver();
         
        }
    }
}
