using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardForce = 500f;
    public float lateralForce = 15f;
    public float targetSpeed = 100f;
    public float maxLateralPos = 3f; 

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
       ForwardMovement();

       LateralMovement();
    }

    void ForwardMovement()
    {
         // Calculate the current forward speed
        float currentSpeed = rb.linearVelocity.z;

        if(currentSpeed < targetSpeed)
        { 
            rb.AddForce(Vector3.forward * 1000f * Time.fixedDeltaTime, ForceMode.Force);
        }
        else if(currentSpeed > targetSpeed)
        {
            // Clamp forward speed to target speed
            Vector3 clampedVelocity = rb.linearVelocity;

            clampedVelocity.z = targetSpeed;

            rb.linearVelocity = clampedVelocity;
        }
    }

    void LateralMovement()
    {
        float direction = Input.GetAxis("Horizontal");

        Vector3 lateralVelocity = rb.linearVelocity;
        lateralVelocity.x = direction * lateralForce;
        rb.linearVelocity = lateralVelocity;

        // Clamp the player's x position within bounds
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -maxLateralPos, maxLateralPos);
        transform.position = clampedPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            GameStateManager.instance.ChangeState(GameState.GameOver);
        }
        
      }
}
