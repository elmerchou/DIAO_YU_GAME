using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{

    private float alpha = 0;

    [SerializeField] CanvasGroup m_canvasGroup;
    [SerializeField] CanvasGroup v_canvasGroup;

    [SerializeField] CanvasGroup r_canvasGroup;
    // Use this for initialization
    void Start()
    {
        r_canvasGroup.alpha = 0;
        r_canvasGroup.interactable = false;
        r_canvasGroup.blocksRaycasts = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (m_canvasGroup.alpha < 1)
        {
            alpha += 0.01f;
            m_canvasGroup.alpha = alpha;
            v_canvasGroup.alpha = alpha;
        }



    }

    public void ReturnOn()
    {

        r_canvasGroup.interactable = true;
        r_canvasGroup.blocksRaycasts = true;
        r_canvasGroup.alpha = 1;

        v_canvasGroup.alpha = 0;
        v_canvasGroup.interactable = false;
        v_canvasGroup.blocksRaycasts = false;


    }

    public void ReturnOff()
    {
        r_canvasGroup.alpha = 0;
        r_canvasGroup.interactable = false;
        r_canvasGroup.blocksRaycasts = false;

        v_canvasGroup.interactable = true;
        v_canvasGroup.blocksRaycasts = true;
        v_canvasGroup.alpha = 1;
    }


}
