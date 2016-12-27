using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 6f;

    private Vector3 movement;
    private Animator animator;
    private Rigidbody playerRigidbody;
    private float camRayLength = 100f;

    void Awake()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float v = CrossPlatformInputManager.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized*Speed*Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        var camRay = Camera.main.ScreenPointToRay(CrossPlatformInputManager.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, camRayLength))
        {
            Vector3 playerToMouse = Vector3.forward;

            var newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);

        }
    }

    void Animating(float h, float v)
    {
        var walking = h != 0f || v != 0f;
        animator.SetBool("IsWalking", walking);
    }

}
