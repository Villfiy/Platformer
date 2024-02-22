using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Character : MonoBehaviour
{
    public static Vector2 storona;
    public float move;
    public static float speed = 6f;
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    private Animator anim;
    private bool moveAnim;
    public float setJumpForce = 0.5f;
    private float jumpForce;
    public bool isGround;
    public float rayDistance = 0.6f;
    public static int Energy = 0;
    public Text EnergyScore;
    public Image barSkillRun;
    public GameObject dontHaveEnerg;
    public GameObject skillfull;
    public GameObject theskillnotUprgaded;
    public Text txtInfiSkillovRun;
    public float debugSpeed;
    public static int txtInfoOfRun = 0;
    [SerializeField]
    private float health;

    public float maxHealth = 100f;

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    private void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    //бег в лево
    public void OnLeft()
    {
        move = -1.0f;
    }
    //бег в право
    public void OnRight()
    {
        move = 1.0f;
    }
    //прижек
    public void OnJump()
    {
        if (isGround)
        {
            jumpForce = setJumpForce;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

    }
    //стоп движения
    public void Stop()
    {
        move = 0f;
    }
    public void StopJump()
    {
        jumpForce = 0f;
    }
    private void FixedUpdate()
    {
        txtInfiSkillovRun.text = txtInfoOfRun.ToString() + "/10";
        debugSpeed = speed;
        if (anim.GetBool("move") == true && isGround)
        {
            anim.SetBool("move", true);
            anim.SetBool("touch", false);
        }
        else if (anim.GetBool("move") == true && !isGround)
        {
            anim.SetBool("move", false);
            anim.SetBool("touch", true);
        }
        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, rayDistance, LayerMask.GetMask("Ground"));
        if (hit.collider != null)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }

        if (move == 1.0f || move == -1.0f)
        {
            moveAnim = true;
        }
        else
        {
            moveAnim = false;
        }
        //передвижение
        if (isGround)
        {
            rb.velocity = new Vector2(move * speed, rb.velocity.y);
        }
        if (!isGround)
        {
            anim.SetBool("touch", true);
        }
        else if (isGround)
        {
            if (anim.GetBool("touch") == true)
            {
                anim.SetBool("touch", false);
            }
        }

        if (move > 0 && !isFacingRight)
            Flip();
        else if (move < 0 && isFacingRight)
            Flip();
        //анимации
        anim.SetBool("move", moveAnim);

        storona = gameObject.transform.position;

        EnergyScore.text = Energy.ToString();
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private Vector2 rayDir;

    public void onClickRunplac()
    {
        if (Character.Energy >= 1 && barSkillRun.fillAmount < 1f)
        {
            barSkillRun.fillAmount += 0.1f;
            Character.Energy -= 1;
            speed += 0.5f;
            txtInfoOfRun += 1;
        }
        else if (Character.Energy < 1)
        {
            dontHaveEnerg.SetActive(true);
        }
        else if (barSkillRun.fillAmount == 1)
        {
            skillfull.SetActive(true);
        }
     }
    public void ReceiveDamage(float damage)
    {
        health -= damage;
    }

}
