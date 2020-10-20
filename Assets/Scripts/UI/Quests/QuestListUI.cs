using RPG.Quests;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestListUI : MonoBehaviour
{
    [SerializeField]
    QuestItemUI questPrefab;

    QuestList questList;

    private void Awake()
    {
        questList = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestList>();
        questList.OnQuestListUpdated += UpdateQuestList;
    }

    void OnEnable()
    {
        transform.DetachChildren();

        

        foreach(QuestStatus status in questList.GetStatuses())
        {
            QuestItemUI questUI = Instantiate(questPrefab, this.transform);
            questUI.Setup(status);
        }
        
    }

    void UpdateQuestList()
    {
        OnEnable();
    }


}
