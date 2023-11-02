using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public GameObject objectPrefab; 
    public float spawnInterval = 10f; 
    public float moveSpeed = 5f; 
    public Transform leftSpawnPoint; 
    public Transform rightSpawnPoint; 
    public float spawnRangeY = 5f; 

    private float timer = 0f; 

    private void Update()
    {
        timer += Time.deltaTime; 

        
        if (timer >= spawnInterval)
        {
            timer = 0f; 

            
            float randomX = Random.Range(0f, 1f);
            Vector3 spawnPosition = new Vector3();
            if (randomX < 0.5f)
            {
                spawnPosition = new Vector3(leftSpawnPoint.position.x, Random.Range(leftSpawnPoint.position.y - spawnRangeY, leftSpawnPoint.position.y + spawnRangeY), 0f); // 左侧位置
            }
            else
            {
                spawnPosition = new Vector3(rightSpawnPoint.position.x, Random.Range(rightSpawnPoint.position.y - spawnRangeY, rightSpawnPoint.position.y + spawnRangeY), 0f); // 右侧位置
            }

          
            GameObject spawnedObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

            
            Vector3 targetPosition = new Vector3(-spawnPosition.x, spawnPosition.y, spawnPosition.z);

            
            ObjectMovement objectMovement = spawnedObject.GetComponent<ObjectMovement>();
            if (objectMovement != null)
            {
                objectMovement.SetTargetPosition(targetPosition);
                objectMovement.SetMoveSpeed(moveSpeed);
            }
        }
    }
    
    
}
