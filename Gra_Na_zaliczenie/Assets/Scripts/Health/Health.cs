using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //[Header("Dead Sound")] 
    //[SerializeField] private AudioClip deathSound;
    
    [SerializeField]
    private float startingHealth;
    public float currentHealth {get; private set;}
    private Animator animator;
    public bool dead { get; private set; }

    public void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if(currentHealth > 0)
        {
            animator.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                animator.SetTrigger("die");
                GetComponent<RubyController>().enabled = false;
                dead = true;
                FindObjectOfType<GameManager>().GameOver();
            }
        }
    }

    // public void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.E))
    //         TakeDamage(0.5f);
    // }
}
