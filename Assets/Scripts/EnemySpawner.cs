using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float maxY;
    [SerializeField] float minY;

    [SerializeField] float y;
    [SerializeField] List<GameObject> enemyList;

    int enemyType;

    [SerializeField] float createMax = 8f;
    [SerializeField] float createMin = 3f;
    [SerializeField] float createFactor;

    [SerializeField] float waitSecond = 2.5f;

    [SerializeField] bool stop = true;



    // Update is called once per frame
    IEnumerator Start()
    {
        CreateReset();
        while (true)
        {
            if (stop == false)
            {
                if (Random.Range(0, 2) == 0)
                {
                    Create();
                }
                else
                {
                    Create2();
                }

                yield return new WaitForSeconds(waitSecond);
            }
            else
            {
                yield return new WaitForSeconds(waitSecond);
            }

        }

    }

    void Update()
    {
    }




    void Create()
    {
        enemyType = Random.Range(0, enemyList.Count);
        y = Random.Range(minY, maxY);
        var newEnemy = Instantiate(enemyList[enemyType], new Vector3(9f, y, 0), Quaternion.identity);

        createFactor -= 1;
        if (createFactor <= 0)
        {
            CreateReset();
            if (Random.Range(0, 2) == 0)
            {
                Create();
            }
            else
            {
                Create2();
            }
        }

    }

    void Create2()
    {
        enemyType = Random.Range(0, enemyList.Count);
        y = Random.Range(minY, maxY);
        var newEnemy = Instantiate(enemyList[enemyType], new Vector3(-9f, y, 0), Quaternion.identity);
        createFactor -= 1;
        if (createFactor <= 0)
        {
            CreateReset();
            if (Random.Range(0, 2) == 0)
            {
                Create();
            }
            else
            {
                Create2();
            }
        }

    }

    void CreateReset()
    {
        createFactor = Random.Range(createMin, createMax) + 1;
    }

    public void SpeedUp()
    {
        if (waitSecond > 0.5f)
        {
            waitSecond -= 0.15f;
            if (waitSecond <= 0.4f)
            {
                waitSecond = 0.5f;
            }
        }

    }

    public void Stop()
    {
        stop = true;
    }

    public void ReStart()
    {
        stop = false;
    }

}
