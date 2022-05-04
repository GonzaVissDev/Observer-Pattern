using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour , IPlayerAction
{

    bool in_range;
    float atk_range = 2.5f;
    [SerializeField] private int exp = 0;
    [SerializeField] private int level = 1;
    [SerializeField] int nextlvl = 1000;
    [SerializeField] private float EnemyLenght = 0.20f;
    [SerializeField] private LayerMask EnemyLayer;
    [SerializeField] private GameObject Thunder;
    [SerializeField] private GameObject Text;
    private Animator anim;

    public event Action<int> ExpUpdated;
    public event Action<int> LvlUpdated;

    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }
 
    void Update()
    {
        in_range = Physics2D.Raycast(transform.position, Vector2.right, EnemyLenght, EnemyLayer);
        
       if (in_range)
        {
            anim.SetTrigger("Atq");
            Attack();
        }

    }

    public void Attack()
    {
       Collider2D[] HitEnemy = Physics2D.OverlapCircleAll(this.transform.position, atk_range, EnemyLayer);

        foreach (Collider2D enemy in HitEnemy)
            {
                if (enemy.tag == "Enemy")
                {

                Enemy monster = enemy.GetComponent<Enemy>();

                if (!monster.IsDead)
                {
                    /*------------------[OBSERVER PATTERN]----------------------------*/
                    ExpUpdate(monster);
                    enemy.GetComponent<Enemy>().IsDead = true;
                }
              

                }
            }
        
    }

    /*------------------[OBSERVER PATTERN - Notify]----------------------------*/
    public void UpdateExp(int xp)
    {
       exp+=xp;

       //NOTIFICO A LOS OBSERVER (UI) QUE la experiencia cambio
       ExpUpdated?.Invoke(exp);
        
        if (exp >= nextlvl)
        {

            //Particula de Leveleo
            
            level++;
            LvlUpdated?.Invoke(level);
            Instantiate(Thunder, new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z), Quaternion.identity);
            exp = 0;
            ExpUpdated?.Invoke(exp);
            nextlvl = nextlvl * 2;
        }


        Instantiate(Text, new Vector3(transform.position.x,transform.position.y-0.5f,transform.position.z), Quaternion.identity);
       
       
    }

   /*------------------[OBSERVER PATTERN]----------------------------*/
    public void ExpUpdate(IEnemyExp enemy)
    {
        enemy.EnemyExp += UpdateExp;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position, transform.position + Vector3.right * EnemyLenght);
       
    }

}
