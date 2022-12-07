using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        // @formatter:off
        [SerializeField]
        private GameObject enemyPrefab;
        
        [SerializeField]
        private int enemyToSpawnCount = 100;
        // @formatter:on

        private int spawningMarginPixels = 20;

        private Camera mainCameraCache;

        private void Awake()
        {
            Assert.IsNotNull(enemyPrefab);
            mainCameraCache = Camera.main;
        }

        private void Start()
        {
            // Spawn Enemies
            for (int i = 0; i < enemyToSpawnCount; i++)
            {
                // get rando positions on screen
                float xPos = Random.Range(spawningMarginPixels, Screen.width - spawningMarginPixels);
                float yPos = Random.Range(spawningMarginPixels, Screen.height - spawningMarginPixels);
                
                // screen position to world position
                Vector3 enemyRandomPosition = mainCameraCache.ScreenToWorldPoint(new Vector3(xPos, yPos, 0));
                
                // clamp Z value
                enemyRandomPosition = new Vector3(enemyRandomPosition.x, enemyRandomPosition.y, 0);
                
                Instantiate(enemyPrefab, enemyRandomPosition, quaternion.identity);
            }
        }
    }
}