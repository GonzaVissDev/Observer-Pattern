using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Enemy : MonoBehaviour,IEnemyExp
{
    [SerializeField] private float Speed;
    [SerializeField] private int exp = 100;
    bool IsAttackig;
    public bool IsDead = false;
    public event Action<int> EnemyExp;

    GameObject Player;
    Rigidbody2D rb2d;
    Animator anim;
   
    void Start()
    {
        //Se Obtiene Los componentes del Enemigo.
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        

        //Componente via Tag para detectar al jugador.
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        anim.SetBool("IsDead", IsDead);

        Vector3 Target = Player.transform.position;

        float Distance = DistancePlayer(V1: Target, V2: transform.position);

            if (IsDead != true)
            {
                rb2d.transform.Translate(Vector3.left * Speed * Time.deltaTime);
            }
    }

    public static float DistancePlayer(Vector3 V1, Vector3 V2)
    {
        float Distance = Vector3.Distance(V1, V2);

        Vector3 Dir = (V1 - V2).normalized;

        return Distance;
    }

    /*------------------[OBSERVER PATTERN - Notify]----------------------------*/
    private void Death() {

        //les avsiso a los observer que me mori  Y les envio la experiencia.
        EnemyExp?.Invoke(exp);
        Destroy(this.gameObject);
    }

    
}


