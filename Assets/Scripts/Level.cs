using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{


    [SerializeField] float delayInSeconds = 2f;
    // Start is called before the first frame update




    public void LoadOP()
    {



        SceneManager.LoadScene(1);

    }
    public void LoadStart()
    {

        FindObjectOfType<Session>().Reset();
        SceneManager.LoadScene(1);

    }

    public void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadOver()
    {

        StartCoroutine(WaitNLoad("EDD"));
    }

    public void LoadOver2()
    {
        StartCoroutine(WaitNLoad("ED_2"));
    }

    public void LoadOver3()
    {
        StartCoroutine(WaitNLoad("ED_3"));

    }

    public void LoadOver4()
    {
        StartCoroutine(WaitNLoad("ED_4"));

    }

    public void Quit()
    {
        Application.Quit();

    }

    IEnumerator WaitNLoad(string s)
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(s);


    }


}