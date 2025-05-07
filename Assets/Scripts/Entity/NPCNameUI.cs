using UnityEngine;

public class NPCNameUI : MonoBehaviour
{
    public Transform npcTransform;           // 따라다닐 NPC 위치
    public GameObject fKeyPrompt;            // 아래에 띄울 [F] 버튼 텍스트
    public Vector3 offset = new Vector3(0, -1f, 0); // NPC 아래 오프셋

    void Start()
    {
        fKeyPrompt.SetActive(false); // 처음엔 숨김
    }

    void Update()
    {
        if (fKeyPrompt.activeSelf && npcTransform != null)
        {
            // World Space Canvas라면, 실제 world position 사용
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
