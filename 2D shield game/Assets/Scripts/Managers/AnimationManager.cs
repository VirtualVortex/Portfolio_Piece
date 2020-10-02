using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public AnimationState[] states;

    public static AnimationManager animManager;

    private void Awake() => animManager = this;

    public void Animation(string name, float value, bool action)
    {
        foreach (AnimationState state in states)
            if (state.stateName == name)
                state.anim.Play(name);
    }
}
