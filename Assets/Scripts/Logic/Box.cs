using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public enum EBox
    {
        Solid,
        NonSolid
    }

    public EBox worksAs;

    public bool inmutable = false;

    private Animator animator;

    private EBox initialWorkAs;
    private EBox OpositeInitialWorkAs => initialWorkAs == EBox.Solid ? EBox.NonSolid : EBox.Solid;

    private void Awake()
    {
        initialWorkAs = worksAs;        
        animator = GetComponent<Animator>();
    }

    public void ChangeHowItIsSeen()
    {
        worksAs = inmutable || !GlitterManager.Instance.glitterIsBad ? initialWorkAs : OpositeInitialWorkAs;
        animator.SetBool("glow", GlitterManager.Instance.glitterIsBad && worksAs != EBox.Solid || !GlitterManager.Instance.glitterIsBad && worksAs == EBox.Solid);
        gameObject.layer = worksAs == EBox.Solid ? 8 : 10;
    }
}