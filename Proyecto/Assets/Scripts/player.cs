using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    public Transform cam;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        // Check for vertical movement
        if (Input.GetKey(KeyCode.Q)) // Move up
        {
            controller.Move(Vector3.up * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E)) // Move down
        {
            controller.Move(Vector3.down * speed * Time.deltaTime);
        }
    }
}









/*using UnityEngine;

public class player : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    public Transform cam;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direccion = new Vector3(horizontal, 0f, vertical).normalized;

        if (direccion.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            
            Vector3 movDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            transform.rotation = Quaternion.Euler(0f,targetAngle,0f);

            controller.Move(movDir.normalized * speed * Time.deltaTime);

        }
    }
}*/
