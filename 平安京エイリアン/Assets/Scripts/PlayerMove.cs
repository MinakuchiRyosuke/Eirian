using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 2.0f;
    [SerializeField] private float rotSpeed = 2.5f;
    Rigidbody rb;
    Vector2 inputVec;
    Vector3 movVec;
    


    private void OnMove(InputValue value)
    {
       inputVec = value.Get<Vector2>();
    }
    private void Start()
    {

    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float magnitude = inputVec.magnitude;
        float moveSpeed = walkSpeed * magnitude;

        float angle = Mathf.Atan2(inputVec.x, inputVec.y) * Mathf.Rad2Deg;
        Quaternion newQua = Quaternion.Euler(0, angle, 0);
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation,
                                                            newQua, 
                                                            rotSpeed);
        movVec = Vector3.Scale(transform.forward, new Vector3(1, 0, 1));
        movVec = new Vector3(movVec.x * moveSpeed, movVec.y + rb.linearVelocity.y, movVec.z * moveSpeed);
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = movVec;
    }
}
