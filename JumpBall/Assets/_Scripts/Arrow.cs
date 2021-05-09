using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public static Arrow S;
    private Transform thisTransform;
    private Animation thisAnimation;

    private void Awake()
    {
        if (S == null) S = this;

        thisTransform = GetComponent<Transform>();
        thisAnimation = GetComponent<Animation>();
    }

    public void ShoingArrows()
    {
        thisTransform.localScale = new Vector3(1f, thisTransform.localScale.y * -1f, 1f);
        thisAnimation.Play();
    }
}
