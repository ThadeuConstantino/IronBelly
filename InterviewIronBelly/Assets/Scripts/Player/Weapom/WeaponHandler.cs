using IronBelly.Utils;
using UnityEngine;

public class WeaponHandler : MonoBehaviour {

    private Animator anim;

    [SerializeField]
    private GameObject goFlash;

    void Awake() 
    {
        anim = GetComponent<Animator>();
    }

    public void ShootAnimation() 
    {
        anim.SetTrigger(AnimationTags.SHOOT_TRIGGER);
    }

    public void Aim(bool canAim) 
    {
        anim.SetBool(AnimationTags.AIM, canAim);
    }

    void Turn_On_MuzzleFlash() 
    {
        goFlash.SetActive(true);
    }

    void Turn_Off_MuzzleFlash() 
    {
        goFlash.SetActive(false);
    }

}





































