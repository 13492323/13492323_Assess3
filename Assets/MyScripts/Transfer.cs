using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transfer : MonoBehaviour
{
   public GameObject MovePoint;
   public Transform PlayerTransform;
   public Transform PlayerMovePoint;

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         print(2);
         other.transform.position = PlayerTransform.position;
         MovePoint.transform.position = PlayerMovePoint.position;
      }
   }
}
