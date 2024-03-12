using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockageScript : MonoBehaviour
{
    protected bool _is_open = false;

    public bool DefaultActionToOpen = true;


    private void Start()
    {
        if (!DefaultActionToOpen)
        {
            _is_open = true;
            Close();
        }
    }

    public virtual void Open()
    {
        if (!_is_open)
        {
            _is_open = true;

            if (DefaultActionToOpen){
                GetComponent<BoxCollider2D>().enabled = false;
                var _temp = GetComponent<SpriteRenderer>().color;
                _temp.a = 0.01176470588f;
                GetComponent<SpriteRenderer>().color = _temp;
            }
            else
            {
                GetComponent<BoxCollider2D>().enabled = true;
                var _temp = GetComponent<SpriteRenderer>().color;
                _temp.a = 1.0f;
                GetComponent<SpriteRenderer>().color = _temp;
            }


        }
    }

    public virtual void Close()
    {
        if (_is_open)
        {
            _is_open = false;

            if (DefaultActionToOpen)
            {
                GetComponent<BoxCollider2D>().enabled = true;
                var _temp = GetComponent<SpriteRenderer>().color;
                _temp.a = 1.0f;
                GetComponent<SpriteRenderer>().color = _temp;
            }
            else
            {
                GetComponent<BoxCollider2D>().enabled = false;
                var _temp = GetComponent<SpriteRenderer>().color;
                _temp.a = 0.01176470588f;
                GetComponent<SpriteRenderer>().color = _temp;
            }



        }
    }
}
