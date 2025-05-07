using UnityEngine;

public class PlayerNameUI : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2f, 0);

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
            transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward); // �׻� ī�޶� �ٶ󺸰�
        }
    }
}
