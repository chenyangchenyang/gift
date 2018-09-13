using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//挂载在UI Text上
public class ShowWords : MonoBehaviour
{
    public string dialogStr = "我是一只小鸭子，嘎嘎嘎嘎嘎嘎.....";

    public float speed = 5.0f;

    private Text guiText;
    // Use this for initialization
    void Start()
    {
        guiText= GetComponent<Text>();

        ContentSizeFitter csf= gameObject.GetComponent<ContentSizeFitter>();

        if(null == csf)
        {
            csf = gameObject.AddComponent<ContentSizeFitter>();
        }

        csf.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        csf.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

        if(null != guiText)
        {
            StartCoroutine(ShowDialog());
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator ShowDialog()
    {
        float timeSum = 0.0f;
        while (guiText.text.Length < dialogStr.Length)
        {
            timeSum += speed * Time.deltaTime;
            guiText.text = dialogStr.Substring(0, System.Convert.ToInt32(timeSum));
            yield return null;
        }

        guiText.text = "";
    }
}
