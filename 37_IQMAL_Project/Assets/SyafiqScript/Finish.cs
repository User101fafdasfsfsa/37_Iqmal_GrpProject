using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private AudioSource WinFX;
    [SerializeField] private AudioSource ErrorFX;

    // Start is called before the first frame update
    private void Start()
    {
        WinFX = GetComponent<AudioSource>();
        ErrorFX = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            WinFX.Play();
            WInUI();
        }

    }
    //Put the WIN UI Below this comment.
    private void WInUI()
    {

    }

}
