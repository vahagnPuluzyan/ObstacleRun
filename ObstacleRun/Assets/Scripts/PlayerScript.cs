using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    PlayerMovement playerMovement;
    UIManager UI;

    Vector3 scaleVector = new Vector3(0.05f, 0.05f, 0.05f);

    EnemyScript enemy;

    private void Start()
    {
        enemy = FindObjectOfType<EnemyScript>();
        UI = FindObjectOfType<UIManager>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rotate")
        {
            UI.gameCotroller.SetActive(false);
            UI.swipeImage.SetActive(true);
            playerMovement.speed -= 1;
            playerMovement.anim.speed -= 0.5f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //mtanq bossi dasht
        if (other.tag == "BossPlatform")
        {
            if (enemy.health > 0 ) {
                enemy.agent.SetDestination(gameObject.transform.position);
                StartCoroutine(enemy.RunAndDamage());
                UI.tapImage.SetActive(true);
                UI.gameCotroller.SetActive(false);
            }
            else
            {
                StopCoroutine(enemy.RunAndDamage());
                playerMovement.anim.SetBool("FinishAttack", true);
                StartCoroutine(enemy.EnemyDeath());
            }

            playerMovement.isBoss = true;
            playerMovement.anim.SetBool("Idle",true);
        }
      
        //verevi pat
        if (other.tag == "WallTop") {
            playerMovement.anim.SetBool("Flip", playerMovement.flip);
            playerMovement.anim.SetBool("Rolling", playerMovement.roll);
            playerMovement.StartCoroutine(playerMovement.AnimationFalseCorutine(1f));
            if(!playerMovement.roll)
            {
                playerMovement.TakeDamage(0.1f);
            }
        }

        //nerqevi pat
        if (other.tag == "WallDown")
        {
            playerMovement.anim.SetBool("Flip", playerMovement.flip);
            playerMovement.anim.SetBool("Rolling", playerMovement.roll);
            playerMovement.StartCoroutine(playerMovement.AnimationFalseCorutine(1f));
            if(!playerMovement.flip)
            {
                playerMovement.TakeDamage(0.1f);
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Rotate")
        {
            UI.gameCotroller.SetActive(true);
            UI.swipeImage.SetActive(false);
            playerMovement.speed += 1;
            playerMovement.anim.speed += 0.5f;
        }
    }
}
