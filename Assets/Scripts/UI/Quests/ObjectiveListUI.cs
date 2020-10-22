using RPG.Quests;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ObjectiveListUI : MonoBehaviour
{
    [SerializeField]
    Transform parent;
    [SerializeField]
    TMP_Text title;
    [SerializeField]
    ObjectiveItemUI objectiveUIButton;


    public void Setup(QuestStatus status)
    {
        this.title.text = status.GetQuest().GetTitle();

        parent.DetachChildren();

        foreach (var obj in status.GetQuest().GetObjectives())
        {
            ObjectiveItemUI item = Instantiate(objectiveUIButton, parent);

            bool isComplete = false;
            if (status.GetCompletedObjectives().Contains(obj.reference))
                isComplete = true;

            item.Setup(obj.description, isComplete);
        }
    }

}
