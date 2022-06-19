using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] CanvasGroup obj;

    public void Highlight()
    {
        obj.alpha = 1;
    }
    public void Downlight()
    {
        obj.alpha = 0;
    }

}
