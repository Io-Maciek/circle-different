using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMagnetic : MonoBehaviour
{
    public BecomeSquareAbility player_ability;
    public GameObject player;

    public float DistanceToStartMagnetic = 5.0f;
    public float forceFactor = 5.0f;

    Rigidbody2D rb;
    AudioSource _audio;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _audio = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        try
        {
            if (Vector2.Distance(player.transform.position, transform.position) <= DistanceToStartMagnetic && !player_ability.IsCircle)
            {
                if(!_audio.isPlaying)
                    _audio.Play();
                rb.AddForce((player.transform.position - transform.position) * forceFactor);
            }
            else if (rb.velocity != Vector2.zero)
            {
                _audio.Stop();
                rb.velocity = Vector2.zero;
            }
        }
        catch (MissingReferenceException)
        {
            if (rb.velocity != Vector2.zero)
            {
                _audio.Stop();
                rb.velocity = Vector2.zero;
            }
        }
    }
}
