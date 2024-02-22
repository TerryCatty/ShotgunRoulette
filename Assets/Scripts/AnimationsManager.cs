using System.Collections.Generic;
using UnityEngine;

public class AnimationsManager : MonoBehaviour
{
   public bool AnimationsIsFinish { get; set; }
    public bool animationIsWork;
    [SerializeField] private List<Action_Animation> animations;
    private int index = 0;
    private bool animStarted = false;

    public bool GetAnimationsState()
    {
        return AnimationsIsFinish;
    }

    public void AddAnimation(Action_Animation anim)
    {
        if (animationIsWork) return;
        animations.Add(anim);
    }

    public void StartPlayAnimations()
    {/*
        List<Action_Animation> temp = animations;
        animations = new List<Action_Animation>();*/
        animationIsWork = true;
    }

    private void Update()
    {
        if (animations.Count <= 0)
        {
            animationIsWork = false;
            AnimationsIsFinish = true;
            animations.Clear();
        }

        if (animationIsWork)
        {
            if(animStarted == false)
            {
                animStarted = true;
                animations[index].StartAnimation();
            }

            if (animations[index].GetAnimationsFinish())
            {
                animations[index].AnimationIsFinish = false;
                animStarted = false;
                animations.Remove(animations[index]);
            }
        }
    }

   
}
