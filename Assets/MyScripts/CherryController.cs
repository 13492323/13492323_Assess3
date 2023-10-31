using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public GameObject objectPrefab; // 要生成的物体预制体
    public float spawnInterval = 10f; // 生成间隔
    public float moveSpeed = 5f; // 移动速度
    public Transform leftSpawnPoint; // 左侧生成点的位置
    public Transform rightSpawnPoint; // 右侧生成点的位置
    public float spawnRangeY = 5f; // 生成点的y轴范围

    private float timer = 0f; // 计时器

    private void Update()
    {
        timer += Time.deltaTime; // 更新计时器

        // 检查是否达到生成间隔
        if (timer >= spawnInterval)
        {
            timer = 0f; // 重置计时器

            // 随机选择生成的位置（左侧或右侧）
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

            // 生成物体
            GameObject spawnedObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

            // 计算目标位置（另一侧位置）
            Vector3 targetPosition = new Vector3(-spawnPosition.x, spawnPosition.y, spawnPosition.z);

            // 设置物体的移动目标和速度
            ObjectMovement objectMovement = spawnedObject.GetComponent<ObjectMovement>();
            if (objectMovement != null)
            {
                objectMovement.SetTargetPosition(targetPosition);
                objectMovement.SetMoveSpeed(moveSpeed);
            }
        }
    }
    
    
}
