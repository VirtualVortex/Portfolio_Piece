using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "States/Animation", order = 1)]
public class AnimationState : States
{
    public string paramaterName;
    public Animator anim;

    public void PlayAnimation(bool play)
    {
        anim.SetBool(paramaterName, play);
    }
}
