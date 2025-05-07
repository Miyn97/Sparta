using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private float speed = 6;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private readonly int isMoveHash = Animator.StringToHash("IsMove");
    private SpriteRenderer spriteRenderer;
    private bool isFlip;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();    
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        isFlip = moveX == -1 ? true : false ;
        if (moveX != 0)
        spriteRenderer.flipX = isFlip;

        Vector2 move = new Vector2(moveX, moveY).normalized;
        animator.SetBool(isMoveHash, move != Vector2.zero);
        rigidBody.velocity = move * speed;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC") && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("MiniGameScene");
        }
    }
}
