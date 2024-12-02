using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player_movement : MonoBehaviour
{
    private const int V = 0;

    // Start is called before the first frame update
    Rigidbody2D rgb;
    Vector3 velocity;
    public Animator animator;
    public TextMeshProUGUI playerScoreText;

    public int score;

    float speedAmount = 12f;
    float jumpAmount = 12f;
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        score = V;
    }

    // Update is called once per frame
    void Update()
    {
        playerScoreText.text = score.ToString();
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;
        animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetButtonDown("Jump") && Mathf.Approximately(rgb.velocity.y, 0))
        {
            rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
        }

        if (animator.GetBool("IsJumping") && Mathf.Approximately(rgb.velocity.y, 0))
        {
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
