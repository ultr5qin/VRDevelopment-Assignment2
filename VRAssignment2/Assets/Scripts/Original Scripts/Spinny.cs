using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinny : MonoBehaviour
{
    public Animator Anime;


    // Start is called before the first frame update
    void Start()
    {
        Anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void spin()
    {
        Anime.Play("NewSpin");
    }
}
