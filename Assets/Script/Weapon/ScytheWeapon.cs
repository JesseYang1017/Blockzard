using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheWeapon : Weapon
{
    [SerializeField] private AudioClip damageSoundClip;
    public const string ANIM_PARM_ISATTACK = "IsAttack";
    private Animator anim;
    public int atkValue = 50;

    private void Start(){
        anim = GetComponent<Animator>();

    }

    //private void Update(){
        //if(Input.GetKeyDown(KeyCode.Space)){
            //Attack();
        //}
    //}
    public override void Attack(){
        anim.SetTrigger(ANIM_PARM_ISATTACK);
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == Tag.ENEMY){
            AudioSource.PlayClipAtPoint(damageSoundClip, transform.position, 1f);
            other.GetComponent<Enemy>().TakeDamage(atkValue);
        }
    }
}
