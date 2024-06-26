using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Image healthBar;  // UI 이미지 참조
    public GameObject itemPrefab;
    public Transform dropPosition;
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }
    }

    void Die()
    {
        // 적 사망 처리
        Debug.Log("Enemy Died");
        StartCoroutine(DeathCoroutine());
    }
    IEnumerator DeathCoroutine()
    {
        // 3초 대기
        yield return new WaitForSeconds(0f);

        // 아이템 드랍
        DropItem();

        // 적 오브젝트 파괴
        Destroy(gameObject);
    }
    void DropItem()
    {
        if (itemPrefab != null)
        {
            Vector3 dropPos = transform.position;
            if (dropPosition != null)
            {
                dropPos = dropPosition.position;
            }
            Instantiate(itemPrefab, dropPos, Quaternion.identity);
        }
    }
}
