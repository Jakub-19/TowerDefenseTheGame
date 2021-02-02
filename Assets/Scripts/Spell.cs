using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spell : MonoBehaviour
{
    public float explosionRadius = 0f;
    public float cooldown = 180f;
    public Button SpellItem;
    public GameObject impactEffect;
    public float dmgPercentage = 50;
    private float countdown = 0f;

    public Text Bought;
    public Text NotBought;

    [Header("Unity")]
    public Image countdownProgress;


    public void ActivateSpell()
    {
        Explode();
        countdown = cooldown;
        SpellItem.interactable = false;
    }

    void Start()
    {
        SpellItem.interactable = false;
        countdown = cooldown;
        if (PlayerPrefs.GetInt("MagicSpell") == 1)
        {
            NotBought.enabled = false;
            Bought.enabled = true;
        }
        else
        {
            NotBought.enabled = true;
            Bought.enabled = false;
        }
    }

    void Update()
    {
        if(PlayerPrefs.GetInt("MagicSpell") == 1)
        {
            if (countdown < 0)
            {
                SpellItem.interactable = true;
            }
            else
            {
                countdown -= Time.deltaTime;
                countdownProgress.fillAmount = countdown / cooldown;
            }
        }
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.SpellEffect(dmgPercentage/100, impactEffect);
        }
    }

}
