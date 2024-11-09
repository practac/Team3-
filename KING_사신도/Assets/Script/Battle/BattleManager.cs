using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleManager : MonoBehaviour
{
    public EnemyCharacter enemy;       // 적 캐릭터를 참조
    public TMP_Text battleLog;         // 전투 로그를 표시할 TextMeshPro 텍스트 오브젝트

    // 공격력 및 성공 확률 설정
    public int basicAttackPower = 10;
    public int strongAttackPower = 15;
    public int specialAttackPower = 20;
    public float basicAttackChance = 0.9f;
    public float strongAttackChance = 0.7f;
    public float specialAttackChance = 0.5f;

    private void Start()
    {
        // 필수 참조가 올바르게 설정되었는지 확인
        if (enemy == null)
        {
            Debug.LogError("Enemy reference is missing in BattleManager.");
        }
        if (battleLog == null)
        {
            Debug.LogError("Battle Log reference is missing in BattleManager.");
        }
    }

    public void OnBasicAttack()
    {
        if (enemy == null || battleLog == null) return;

        Debug.Log("Basic Attack button clicked.");

        if (Random.value < basicAttackChance)
        {
            int damage = Random.Range(basicAttackPower - 5, basicAttackPower + 5);
            enemy.TakeDamage(damage);
            battleLog.text = $"기본 공격 성공! {enemy.characterName}에게 {damage}의 데미지를 입혔습니다.";
        }
        else
        {
            battleLog.text = "기본 공격이 실패했습니다!";
        }
    }

    public void OnStrongAttack()
    {
        if (enemy == null || battleLog == null) return;

        Debug.Log("Strong Attack button clicked.");

        if (Random.value < strongAttackChance)
        {
            int damage = Random.Range(strongAttackPower - 10, strongAttackPower + 10);
            enemy.TakeDamage(damage);
            battleLog.text = $"강력한 공격 성공! {enemy.characterName}에게 {damage}의 데미지를 입혔습니다.";
        }
        else
        {
            battleLog.text = "강력한 공격이 실패했습니다!";
        }
    }

    public void OnSpecialAttack()
    {
        if (enemy == null || battleLog == null) return;

        Debug.Log("Special Attack button clicked.");

        if (Random.value < specialAttackChance)
        {
            int damage = Random.Range(specialAttackPower - 15, specialAttackPower + 15);
            enemy.TakeDamage(damage);
            battleLog.text = $"특수 공격 성공! {enemy.characterName}에게 {damage}의 데미지를 입혔습니다.";
        }
        else
        {
            battleLog.text = "특수 공격이 실패했습니다!";
        }
    }
}

