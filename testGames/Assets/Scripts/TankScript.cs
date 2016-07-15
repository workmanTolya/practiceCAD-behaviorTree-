using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TankScript : MonoBehaviour {

    public float speed;
    public int hp = 2;
    public bool isEnemy = true;

    public void Damage(int damageCount)
    {
        hp -= damageCount;
        if (hp <= 0)
        {
            SpecialEffectsHelper.Instance.Explosion(transform.position);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ShotScript shot = other.gameObject.GetComponent<ShotScript>();
        if (shot.isEnemyShot != isEnemy)
        {
             Damage(shot.damage);
             Destroy(shot.gameObject);
        }
    }

    void OnDestroy()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            bool res = true;
            GameObject[] end = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in end)
            {
                res = res && !enemy;
            }
            if (res == true)
                SceneManager.LoadScene("Finish");
        }
        else transform.parent.gameObject.AddComponent<GameOverScript>();
    }
}
