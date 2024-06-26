using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    public Transform target;  // ü�¹ٰ� ����ٴ� ���� Transform
    public Vector3 offset;    // ü�¹� ��ġ ����

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = Camera.main.WorldToScreenPoint(target.position + offset);
            transform.position = targetPosition;
        }
    }
}
