using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public string enemyName = "Enemy";                  // Enemy �̸�
    public Slider enemyHpBar;                           // Enemy HP Bar (Slider)
    public TextMeshProUGUI battleLog;                   // Battle Log TextMeshPro
    public Button throwButton;                          // ������ ��ư
    public Button kickButton;                           // �������� ��ư
    public Button punchButton;                          // ������ ��ư

    public GameObject throwEffect;                      // ������ ȿ�� ������Ʈ (Hierarchy�� ����)
    public GameObject kickEffect;                       // �������� ȿ�� ������Ʈ (Hierarchy�� ����)
    public GameObject punchEffect;                      // ������ ȿ�� ������Ʈ (Hierarchy�� ����)

    private int enemyMaxHp = 100;                       // Enemy�� �ִ� HP
    private int enemyCurrentHp;

    void Start()
    {
        enemyCurrentHp = enemyMaxHp;
        enemyHpBar.maxValue = enemyMaxHp;
        enemyHpBar.value = enemyCurrentHp;

        battleLog.text = $"{enemyName}��(��) ��ų�� ����� �����Ͻÿ�.";

        throwButton.onClick.AddListener(() => Attack("������", throwEffect));
        kickButton.onClick.AddListener(() => Attack("��������", kickEffect));
        punchButton.onClick.AddListener(() => Attack("������", punchEffect));
    }

    // ���� �޼ҵ�
    void Attack(string attackType, GameObject effectObject)
    {
        int damage = CalculateDamage(attackType);
        bool isSuccessful = Random.Range(0, 100) < 75; // ���� ���� Ȯ�� 75%

        if (isSuccessful)
        {
            enemyCurrentHp -= damage;
            enemyCurrentHp = Mathf.Clamp(enemyCurrentHp, 0, enemyMaxHp); // HP 0 ���Ϸ� ���� �ʰ� ����
            enemyHpBar.value = enemyCurrentHp;
            battleLog.text = $"{attackType} ���� ����!\n {enemyName}���� {damage} ���ظ� �������ϴ�.";
            StartCoroutine(ShowEffect(effectObject)); // ȿ�� ����
        }
        else
        {
            battleLog.text = $"{attackType} ���� ����!\n {enemyName}���� ���ظ� ������ ���߽��ϴ�.";
        }

        // Enemy�� HP�� 0�� �Ǹ� ���� �¸� �޽��� ǥ��
        if (enemyCurrentHp <= 0)
        {
            battleLog.text = $"{enemyName}�� óġ�߽��ϴ�!";
            throwButton.interactable = false;
            kickButton.interactable = false;
            punchButton.interactable = false;
        }
    }

    // ȿ���� ��� Ȱ��ȭ�ϴ� �ڷ�ƾ
    IEnumerator ShowEffect(GameObject effectObject)
    {
        effectObject.SetActive(true); // ȿ�� ������Ʈ Ȱ��ȭ
        yield return new WaitForSeconds(1.5f); // 1.5�� ���� ���� (�ʿ信 ���� ���� ����)
        effectObject.SetActive(false); // ȿ�� ������Ʈ ��Ȱ��ȭ
    }

    // ���� ������ ���� ���� ���
    int CalculateDamage(string attackType)
    {
        int damage = 0;
        switch (attackType)
        {
            case "������":
                damage = Random.Range(5, 15); // ������: 5~15 ����
                break;
            case "��������":
                damage = Random.Range(10, 20); // ��������: 10~20 ����
                break;
            case "������":
                damage = Random.Range(15, 25); // ������: 15~25 ����
                break;
        }
        return damage;
    }
}