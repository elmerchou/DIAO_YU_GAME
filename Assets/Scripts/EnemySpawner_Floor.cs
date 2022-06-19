using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_Floor : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] List<GameObject> enemyList;

    int enemyType;

    [SerializeField] int createMax;
    [SerializeField] int createMin;
    [SerializeField] bool stop = true;



    // Update is called once per frame
    IEnumerator Start()
    {
        while (true)
        {
            if (stop == false)
            {
                yield return new WaitForSeconds(Random.Range(createMin, createMax));
                Create();

            }
            else
            {
                yield return new WaitForSeconds(1);
            }



        }

    }

    void Create()
    {
        enemyType = Random.Range(0, enemyList.Count);
        if (enemyType == 0)
        {
            var newEnemy = Instantiate(enemyList[enemyType], new Vector3(10.5f, -2.6f, 0), Quaternion.identity);
        }
        else if (enemyType == 1)
        {
            var newEnemy = Instantiate(enemyList[enemyType], new Vector3(12f, -3.7f, 0), Quaternion.identity);
        }

    }

    public void SpeedUp()
    {

        if (createMin >= 5)
        {
            createMax--;

            createMin--;
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
