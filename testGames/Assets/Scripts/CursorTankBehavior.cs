using UnityEngine;
using System.Collections;

public class CursorTankBehavior : MonoBehaviour {

    ITankBehavior controller;
    ITankBehavior.goDirection direction = ITankBehavior.goDirection.stay;

    void Start()
    {
        controller = GetComponent<ITankBehavior>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = ITankBehavior.goDirection.right;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = ITankBehavior.goDirection.left;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = ITankBehavior.goDirection.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = ITankBehavior.goDirection.down;
        }
        else
            direction = ITankBehavior.goDirection.stay;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.Shoot();
        }

        controller.direction = direction;
    }
}

