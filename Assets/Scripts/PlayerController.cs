using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 playerInput;
    Rigidbody rb;

    [SerializeField]
    private int speed = 7;



    GameObject model;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        model = GameObject.Find("PlayerModel");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(playerInput.x * speed, rb.linearVelocity.y, playerInput.y * speed);

    }
    void Update()
    {
        Vector3 movementDirection = new Vector3(playerInput.x, 0f, playerInput.y);
        if (movementDirection.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            model.transform.rotation = Quaternion.RotateTowards(
                model.transform.rotation,
                targetRotation,
                360f * Time.deltaTime
                );
        }
    }

    void OnMove(InputValue input)
    {
        playerInput = input.Get<Vector2>();
    }
}
