﻿using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private int attackCount = 1;
    private float nextAttackTime = 0f; 
    private bool canAttack = true; 
    private static readonly int AttackIndex = Animator.StringToHash("AttackIndex");
    private static readonly int Attack = Animator.StringToHash("Attack");

    void Start() => animator = GetComponent<Animator>();

    void Update()
    {
        if (canAttack && Input.GetKeyDown(KeyCode.J) && Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + 0.75f; 

            if (Time.time - nextAttackTime > 0.5f)
                attackCount = 1;
            else
                attackCount++;

            if (attackCount > 3)
            {
                attackCount = 1;
                canAttack = false; 
                Invoke(nameof(ResetAttack), 1.0f);
            }

            animator.SetFloat(AttackIndex, attackCount);
            animator.SetTrigger(Attack);
        }

        if (Time.time - nextAttackTime > 1.0f)
            animator.SetFloat(AttackIndex, 1);
    }

    void ResetAttack()
    {
        canAttack = true; 
        nextAttackTime = Time.time; 
    }
}
