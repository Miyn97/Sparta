using UnityEngine;

public class NPCInteractionTrigger : MonoBehaviour
{
    public GameObject infoUI;
    public Transform npcTransform; // 여기에 MainSprite를 할당할 것
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

            // MainSprite 기준으로 위치 계산
            Vector3 worldPos = npcTransform.position + offset;

            // 캔버스의 로컬 좌표로 변환
            Vector3 localPos = infoUI.transform.parent.InverseTransformPoint(worldPos);

            // anchoredPosition으로 위치 지정
            infoRect.anchoredPosition = new Vector2(localPos.x, localPos.y);

            // Z값 보정 및 스케일 고정
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
