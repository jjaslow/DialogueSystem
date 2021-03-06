﻿using RPG.Quests;
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
    TMP_Text rewardText;
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

        rewardText.text = "";
        foreach(var reward in status.GetQuest().GetRewards())
        {
            rewardText.text += reward.number + "x " + reward.item.name + "\n";
        }
        if (rewardText.text == "")
            rewardText.text = "No Reward.";
    }

}
