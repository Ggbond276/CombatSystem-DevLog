using UnityEngine;

namespace Script
{
    public class PlayerInputController : MonoBehaviour
    {
        public float moveSpeed = 6f;
        public Rigidbody rb;

        public Vector3 moveInput;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");
            moveInput = new Vector3(moveX, 0, moveY).normalized;
        }
        
        void FixedUpdate()
        {
            rb.velocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, moveInput.z * moveSpeed);
        }
    }
}
