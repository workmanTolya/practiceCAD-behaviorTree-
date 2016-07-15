using UnityEngine;
using System.Collections;

public class ITankBehavior : MonoBehaviour {

    public enum goDirection { up, down, left, right, stay };
    public goDirection direction;
    Quaternion initialRot;

    void Start()
    {
        initialRot = transform.rotation;
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        if (direction == goDirection.right)
        {
            transform.rotation = initialRot;
            transform.Rotate(new Vector3(0, 0, 0));
            GetComponent<Rigidbody2D>().AddForce(-transform.right * GetComponent<TankScript>().speed, ForceMode2D.Impulse);
        }
        else if (direction == goDirection.left)
        {
            transform.rotation = initialRot;
            transform.Rotate(new Vector3(0, 0, 180));
            GetComponent<Rigidbody2D>().AddForce(-transform.right * GetComponent<TankScript>().speed, ForceMode2D.Impulse);
        }
        else if (direction == goDirection.up)
        {
            transform.rotation = initialRot;
            transform.Rotate(new Vector3(0, 0, 90));
            GetComponent<Rigidbody2D>().AddForce(-transform.right * GetComponent<TankScript>().speed, ForceMode2D.Impulse);
        }
        else if (direction == goDirection.down)
        {
            transform.rotation = initialRot;
            transform.Rotate(new Vector3(0, 0, -90));
            GetComponent<Rigidbody2D>().AddForce(-transform.right * GetComponent<TankScript>().speed, ForceMode2D.Impulse);
        }
    }

    public void Shoot()
    {
        WeaponScript weapon = GetComponentInChildren<WeaponScript>();
        if (weapon != null)
        {
            weapon.Attack(false);
            SoundEffectsHelper.Instance.MakePlayerShotSound();
        }
    }
}
