using System;
using Player;
using UnityEngine;
using UnityEngine.Assertions;

namespace Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        // @formatter:off
        [SerializeField]
        private float movementSpeed = 4f;
        
        [SerializeField]
        private SpriteRenderer _sprite;
        
        [SerializeField]
        private Collider2D _collider2D;
        
        [SerializeField]
        private Collider2D _playerDetectorTrigger;
        
        [SerializeField]
        private Rigidbody2D _rigidbody2D;
        // @formatter:on

        private bool isActive = true;

        private Transform detectedPlayer;

        private void Awake()
        {
            Assert.IsNotNull(_sprite);
            Assert.IsNotNull(_collider2D);
            Assert.IsNotNull(_rigidbody2D);
            Assert.IsNotNull(_playerDetectorTrigger);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
                DisableEnemy();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                detectedPlayer = col.GetComponent<Transform>();
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                detectedPlayer = null;
            }
        }

        private void Update()
        {
            if (detectedPlayer != null) 
                RunAway();
        }

        private void RunAway()
        {
            Vector3 fromPlayerVector = transform.position - detectedPlayer.position;
            _rigidbody2D.MovePosition(transform.position
                                      + fromPlayerVector * (movementSpeed * Time.deltaTime));
        }

        private void DisableEnemy()
        {
            isActive = false;
            _sprite.color = new Color(1, 1, 1, .4f);
            _collider2D.enabled = false;
            _playerDetectorTrigger.enabled = false;
        }
    }
}