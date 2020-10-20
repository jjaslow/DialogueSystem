using RPG.Quests;
using RPG.UI.Quests;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class QuestItemUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text title;
    [SerializeField]
    TMP_Text progress;



    public void Setup(QuestStatus status)
    {
        title.text = status.GetQuest().GetTitle();

        int completed = status.GetCompletedObjectives().Count();
        progress.text = completed + "/" + status.GetQuest().GetObjectiveCount().ToString();
        GetComponent<QuestToolTipSpawner>().Setup(status);
    }


}
