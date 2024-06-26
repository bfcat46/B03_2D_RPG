using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    public Transform target;  // 체력바가 따라다닐 적의 Transform
    public Vector3 offset;    // 체력바 위치 조정

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = Camera.main.WorldToScreenPoint(target.position + offset);
            transform.position = targetPosition;
        }
    }
}
