using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    private int nextMove;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public int love;
    public int currentLove;
    public int fillLove = 1;

    public GameObject loveBarBackground;
    public Image loveBarFilled;
    GameObject player;
    float playerSpeed;
    Animator playerAnim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Think());

        player = GameObject.Find("Player");
        playerSpeed = player.GetComponent<MoveToClick>().speed;
        playerAnim = player.GetComponent<Animator>();

        loveBarFilled.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(nextMove, rb.velocity.y);
    }

    IEnumerator Think()
    {
        while(true)
        {
            nextMove = Random.Range(-1, 2);
            animator.SetInteger("walkSpeed", nextMove);
            if(nextMove != 0)
            {
                spriteRenderer.flipX = nextMove == 1;
            }

            float time = Random.Range(2f, 5f);
            yield return new WaitForSeconds(time);
        }
        
    }

    private void OnMouseDown()
    {
        if(Vector3.Distance(player.transform.position, transform.position) < 10f)
        {
            playerSpeed = 0f;
            nextMove = 0;
            playerAnim.SetBool("isRunning", false);
            playerAnim.SetBool("isTempting", true);
            currentLove += fillLove;
            loveBarFilled.fillAmount = (float)currentLove / love;
            loveBarBackground.SetActive(true);
        }
    }
}
