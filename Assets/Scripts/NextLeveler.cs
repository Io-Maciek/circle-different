using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLeveler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent != null)
        {
            var trigger = other.transform.parent.GetComponentInParent<PlayerCheckpoints>();
            if (trigger != null)
            {
                Action();
            }
        }
    }

    public void Action()
    {
        SaveNumber.UpdateToNextScene((uint)(SceneManager.GetActiveScene().buildIndex + 1), shouldLoadScene: true);
    }
}
