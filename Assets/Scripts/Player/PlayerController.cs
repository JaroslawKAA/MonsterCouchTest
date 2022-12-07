using UnityEngine;
using UnityEngine.Assertions;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        // @formatter:off
        [SerializeField]
        private float movementSpeed = 5f;
        
        [SerializeField]
        private Rigidbody2D _rigidbody2D;
        // @formatter:on

        private Vector3 movement;

        private void Awake()
        {
            Assert.IsNotNull(_rigidbody2D);
        }

        private void Update()
        {
            movement = Vector2.zero;
            
            if (Input.GetKey(KeyCode.W)
                || Input.GetKey(KeyCode.UpArrow))
            {
                movement += new Vector3(0, 1);
            }
            
            if (Input.GetKey(KeyCode.S)
                || Input.GetKey(KeyCode.DownArrow))
            {
                movement += new Vector3(0, -1);
            }
            
            if (Input.GetKey(KeyCode.A)
                || Input.GetKey(KeyCode.LeftArrow))
            {
                movement += new Vector3(-1, 0);
            }
            
            if (Input.GetKey(KeyCode.D)
                || Input.GetKey(KeyCode.RightArrow))
            {
                movement += new Vector3(1, 0);
            }
        }

        private void FixedUpdate()
        {
            _rigidbody2D.MovePosition(transform.position 
                                      + movement.normalized * (movementSpeed * Time.deltaTime));
        }
    }
}
