using UnityEngine;

public class NPCNameUI : MonoBehaviour
{
    public Transform npcTransform;           // ����ٴ� NPC ��ġ
    public GameObject fKeyPrompt;            // �Ʒ��� ��� [F] ��ư �ؽ�Ʈ
    public Vector3 offset = new Vector3(0, -1f, 0); // NPC �Ʒ� ������

    void Start()
    {
        fKeyPrompt.SetActive(false); // ó���� ����
    }

    void Update()
    {
        if (fKeyPrompt.activeSelf && npcTransform != null)
        {
            // World Space Canvas���, ���� world position ���
            fKeyPrompt.transform.position = npcTransform.position + offset;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            fKeyPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            fKeyPrompt.SetActive(false);
        }
    }
}
