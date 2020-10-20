using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveItemUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text title;
    [SerializeField] Image checkImage;

    public void Setup(string text, bool isComplete)
    {
        title.text = text;
        checkImage.enabled = isComplete;
    }

}
