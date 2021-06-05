using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public bool isDead = false;
    [HideInInspector]
    public bool flip;
    [HideInInspector]
    public bool roll;
    [HideInInspector]
    public bool left;
    [HideInInspector]
    public bool right;
    [HideInInspector]
    public bool isBoss;

    public float health = 100;
    Slider healthBar;

    public ParticleSystem attackFX;
    UIManager UI;

    public ParticleSystem hitFx;

    bool otherPlatform;

    GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();
        UI = FindObjectOfType<UIManager>();
        healthBar = GetComponentInChildren<Slider>();
    }

    void Update()
    {
        healthBar.value = health;
        if (health <=  0 || transform.position.y < -1)
        {
            gm.GameOver();
        }
            
        if (!isDead && !isBoss) {
            if (left)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            }
            else if (right)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            }
            else
            {
             transform.Translate(Vector3.forward *speed* Time.deltaTime,Space.World);
            }
        }
        else
        {
            anim.SetBool("Run",false);
        }
    }

    public void Flip()
    {
        flip = true;
        roll = false;
    }

    public void Roll()
    {
        roll = true;
        flip = false;
    }


    public void TakeDamage(float damage)
    {
        health -= damage;
        hitFx.Play();
    }

    public void Attack()
    {
        attackFX.Play();
    }

    public IEnumerator AnimationFalseCorutine(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        anim.SetBool("Flip",false);
        anim.SetBool("Rolling",false);
    }



    public IEnumerator DelayDeath()
    {
        yield return new WaitForSecondsRealtime(0.4f);
        isDead = true;
        anim.SetBool("Death", true);
        yield return new WaitForSecondsRealtime(1f);
        UI.reloadeMenu.SetActive(true);
        UI.gameCotroller.SetActive(false);
    }
}
