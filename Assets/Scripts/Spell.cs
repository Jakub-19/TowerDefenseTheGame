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

    [Header("Unity")]
    public Image countdownProgress;


    public void ActivateSpell()
    {
        Explode();
        countdown = cooldown;
        SpellItem.enabled = false;
    }

    void Start()
    {
        SpellItem.enabled = false;
        countdown = cooldown;
    }

    void Update()
    {
        if(PlayerPrefs.GetInt("MagicSpell") == 1)
        {
            if (countdown < 0)
            {
                SpellItem.enabled = true;
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
