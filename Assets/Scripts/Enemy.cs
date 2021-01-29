using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    public float timer = 2f;
    [HideInInspector]
    public float speed;
    private GameObject spellEffect = null;

    public float startHealth = 100f;
    private float health;

    public int worth = 50;

    public GameObject deathEffect;


    [Header("Unity")]
    public Image healthBar;

    private bool isDead = false;
    void Start ()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage (float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if(health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow (float pct)
    {
        speed = startSpeed * (1f - pct);
    }


    void Die()
    {
        isDead = true;
        float bonusGold;
        if (PlayerPrefs.GetInt("AdditionalGold") == 1)
        {
            bonusGold = worth / 10;
            if (bonusGold < 1)
                bonusGold = 1;
        }
        else
        {
            bonusGold = 0;
        }

        
        PlayerStats.Money += (int)(worth + bonusGold);

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;
        if(spellEffect != null)
        {
            Destroy(spellEffect);
        }
        Destroy(gameObject);
    }
    public void SpellEffect(float dmg, GameObject spellEffect)
    {
        this.spellEffect = (GameObject)Instantiate(spellEffect, transform.position, transform.rotation);
        StartCoroutine(TakeSpellDamage(dmg, this.spellEffect));
    }

    IEnumerator TakeSpellDamage(float dmg, GameObject effect)
    {
        float smoothness = 0.05f;
        for (float i = timer; i > 0; i -= smoothness)
        {
            
            TakeDamage((dmg * startHealth) / (timer / smoothness));
            effect.transform.position = transform.position;       
            yield return new WaitForSeconds(smoothness);
        }
        Destroy(effect);
    }

}
