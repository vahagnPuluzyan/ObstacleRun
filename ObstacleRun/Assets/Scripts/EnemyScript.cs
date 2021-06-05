using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    PlayerMovement playerMovement;
    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public ParticleSystem fire;
    [HideInInspector]
    public NavMeshAgent agent;
    public float health;
    public Slider healthBar;
    public ParticleSystem hit;
    UIManager UI;

    GameManager gm;
    float dissolveAmount = 0f;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        UI = FindObjectOfType<UIManager>();
        anim = GetComponentInChildren<Animator>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        fire = GetComponentInChildren<ParticleSystem>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        healthBar.value = health / 20;
    }

    public void TakeDamage(float damage)
    {
        playerMovement.Attack();
        health -= damage;
    }

    public IEnumerator RunAndDamage()
    {
        anim.SetBool("Running", true);
        yield return new WaitForSecondsRealtime(3f);
        if (!playerMovement.isDead) {
            UI.attackButton.SetActive(true);
            anim.SetBool("Boxing", true);
            playerMovement.TakeDamage(0.015f);
        }
    }

    public IEnumerator EnemyDeath()
    {
        yield return new WaitForSecondsRealtime(2f);
        dissolveAmount += 0.002f;
        DissolveSphere.mat.SetFloat("_DissolveAmount", dissolveAmount);
        anim.SetBool("Death", true);
        fire.Play();
        UI.tapImage.SetActive(false);
        StartCoroutine(gm.GameWin());
    }
}
