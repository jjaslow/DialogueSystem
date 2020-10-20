using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;


namespace RPG.Quests
{
    public class QuestList : MonoBehaviour
    {
        [SerializeField]
        QuestStatus[] statuses;

        public IEnumerable<QuestStatus> GetStatuses()
        {
            return statuses;
        }

    }



}
