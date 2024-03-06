using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectController : MonoBehaviour
{
    public GameObject Circle;
    public GameObject Square;

    [System.NonSerialized]
    public Animator animator;

    private void Start()
    {
        Circle.SetActive(true);
        Square.SetActive(false);
        Square.transform.localScale = Vector3.zero;

        animator = GetComponent<Animator>();
    }
}
