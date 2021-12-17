using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
   private void OnCollisionEnter(Collision otherCollider)
    {
        if (gameObject.CompareTag("obstacle") && otherCollider.gameObject.CompareTag("player"))
        {
            Debug.Log($"HAS PERDIDO :(");
            Time.timeScale = 0;
        }
        if (gameObject.CompareTag("obstacle") && otherCollider.gameObject.CompareTag("proyectil"))
        {
            Destroy(otherCollider.gameObject);
            Destroy(gameObject);
        }
    }
}
