using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;

public class BlueSlime : MonoBehaviour
{
    public Animator animController;

    public TextMeshProUGUI statusText;

    public int health = 100;
    public TextMeshProUGUI healthText;

    public Image healthBar;

    public GameObject hitEffect;

    public GameObject heavyHitEffect;

    void Start()
    {
        healthText.text = "Enemy Health: " + health;
        healthBar.fillAmount = (float)health / 100;
    }

    void Update()
    {
        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            GetHurt();
        }

        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            GetHeavyHurt();
        }
    }

    public void GetHurt()
    {
        animController.SetTrigger("Hurt");
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        StartCoroutine(TakeDamage(10, 1f));
    }

    public void GetHeavyHurt()
    {
        animController.SetTrigger("HeavyHurt");
        Instantiate(heavyHitEffect, transform.position, Quaternion.identity);
        StartCoroutine(TakeDamage(30, 2f));
    }

    IEnumerator TakeDamage(int damage, float delay)
    {
        yield return new WaitForSeconds(delay);

        health -= damage;
        healthText.text = "Enemy Health: " + health;
        healthBar.fillAmount = (float)health / 100;

        if (health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        animController.SetBool("Death", true);
        statusText.text = "Blue Slime Fainted!\nEvil Wizard gained 30 exp.\nYOU WIN!";
    }

    public void DestroySlime()
    {
        Destroy(gameObject);
    }
}