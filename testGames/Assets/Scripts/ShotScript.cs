using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class ShotScript : MonoBehaviour {
    public int damage = 1;
    public bool isEnemyShot = false;

    void Start() {
        Destroy(gameObject, 20);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "wall" || other.tag == "Block")
            Destroy(gameObject);
        if (other.tag == "Block")
        {
            Destroy(other.gameObject);
        }
    }
}
