using UnityEngine;

public class NPCInteractionTrigger : MonoBehaviour
{
    public GameObject infoUI;
    public Transform npcTransform; // ���⿡ MainSprite�� �Ҵ��� ��
    public Vector3 offset = new Vector3(0, -1f, 0);

    private RectTransform infoRect;

    private void Awake()
    {
        if (infoUI != null)
            infoRect = infoUI.GetComponent<RectTransform>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && infoUI != null && npcTransform != null)
        {
            infoUI.SetActive(true);

            // MainSprite �������� ��ġ ���
            Vector3 worldPos = npcTransform.position + offset;

            // ĵ������ ���� ��ǥ�� ��ȯ
            Vector3 localPos = infoUI.transform.parent.InverseTransformPoint(worldPos);

            // anchoredPosition���� ��ġ ����
            infoRect.anchoredPosition = new Vector2(localPos.x, localPos.y);

            // Z�� ���� �� ������ ����
            infoRect.localPosition = new Vector3(infoRect.localPosition.x, infoRect.localPosition.y, 0);
            infoRect.localScale = Vector3.one;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && infoUI != null)
        {
            infoUI.SetActive(false);
        }
    }
}
