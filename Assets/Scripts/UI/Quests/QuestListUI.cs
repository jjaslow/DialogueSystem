using RPG.Quests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestListUI : MonoBehaviour
{
    [SerializeField]
    QuestItemUI questPrefab;


    void OnEnable()
    {
        transform.DetachChildren();

        QuestList questList = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestList>();

        foreach(QuestStatus status in questList.GetStatuses())
        {
            QuestItemUI questUI = Instantiate(questPrefab, this.transform);
            questUI.Setup(status);
        }
        
    }


}
