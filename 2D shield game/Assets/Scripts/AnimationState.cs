using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "States/Animation", order = 1)]
public class AnimationState : States
{
    public string paramaterName;
    public bool paramaterBool;
    public float paramaterValue;
    public Animator anim;
}
