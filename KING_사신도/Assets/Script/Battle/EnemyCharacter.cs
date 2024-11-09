using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCharacter : MonoBehaviour
{
    public string characterName = "Enemy"; // 적 캐릭터의 이름
    public int maxHealth = 100;
    public int currentHealth;
    public Slider enemyHPBar;            // HP 바 UI를 참조
    public TMP_Text battleLog;           // 전투 로그를 표시할 TextMeshPro 텍스트 오브젝트

    private void Start()
    {
        currentHealth = maxHealth;

        if (enemyHPBar != null)
        {
            enemyHPBar.maxValue = maxHealth;
            enemyHPBar.value = currentHealth;
        }
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("TakeDamage called with damage: " + damage);
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthUI();

        if (currentHealth == 0 && battleLog != null)
        {
            battleLog.text += $"\n{characterName}이(가) 패배했습니다!";
        }
    }

    private void UpdateHealthUI()
    {
        if (enemyHPBar != null)
        {
            enemyHPBar.value = currentHealth;
        }
        else
        {
            Debug.LogError("Enemy HP Bar is not assigned in the Inspector.");
        }
    }
}
