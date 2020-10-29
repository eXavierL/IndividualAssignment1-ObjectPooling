using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    public GameObject bullet;

    public int maxBullets;

    //TODO: create a structure to contain a collection of bullets
    Queue<GameObject> BulletQueue = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // TODO: add a series of bullets to the Bullet Pool

        //Call the private method 
        BuildBulletPool();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Build bullet pool, private method
    private void BuildBulletPool()
    {
        for (int i = 0; i < maxBullets; i++)
        {
            GameObject tempBullet = Instantiate(bullet, new Vector3(-5.0f, 0.0f, 0.0f), Quaternion.identity);
            tempBullet.SetActive(false);
            BulletQueue.Enqueue(tempBullet);
        }
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet()
    {
        GameObject tempBullet;
        //if Queue is not empty
        if (!QueueIsEmpty())
        {
            tempBullet = BulletQueue.Dequeue();
            tempBullet.SetActive(true);
        }
        else
        {
            tempBullet = MonoBehaviour.Instantiate(bullet, new Vector3(-5.0f, 0.0f, 0.0f), Quaternion.identity);
            maxBullets += 1;
        }
        return tempBullet;
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        //Move position back to pool
        bullet.transform.position = new Vector3(-5.0f, 0.0f, 0.0f);
        //Deactivate it since its back in pool
        bullet.SetActive(false);
        //Actually queue it back into the pool
        BulletQueue.Enqueue(bullet);
    }

    //function to return bullet pool size
    public int BulletPoolSize()
    {
        return BulletQueue.Count;
    }

    public bool QueueIsEmpty()
    {
        return BulletPoolSize() == 0;
    }
}
