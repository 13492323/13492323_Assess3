using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private Vector3 targetPosition; // 目标位置
    private float moveSpeed; // 移动速度
    private Vector3 direction;
    private Vector3 initialPosition; // 初始位置

    public void Start()
    {
        // 计算物体当前位置到目标位置的方向向量
        direction = (targetPosition - transform.position).normalized;
        initialPosition = transform.position; // 记录初始位置
    }

    public void SetTargetPosition(Vector3 target)
    {
        targetPosition = target;
    }

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

    private void Update()
    {
        // 移动物体
        transform.position += direction * moveSpeed * Time.deltaTime;

        // 计算物体当前位置与初始位置之间的距离
        float distance = Mathf.Abs(transform.position.x - initialPosition.x);

        // 检查距离是否超过60
        if (distance > 60f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WallLine"))
        {
            Destroy(gameObject);
        }
    }
}
