using GameDevTV.Saving;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;


namespace RPG.Quests
{
    public class QuestList : MonoBehaviour, ISaveable
    {
        [SerializeField]
        List<QuestStatus> statuses = new List<QuestStatus>();

        public event Action OnQuestListUpdated;

        public IEnumerable<QuestStatus> GetStatuses()
        {
            return statuses;
        }

        public void AddQuest(Quest quest)
        {
            QuestStatus qs = new QuestStatus(quest);
            statuses.Add(qs);
            OnQuestListUpdated?.Invoke();
        }

        public void RefreshQuestList()
        {
            OnQuestListUpdated?.Invoke();
        }




        public object CaptureState()
        {
            List<object> state = new List<object>();
            foreach (QuestStatus status in statuses)
            {
                state.Add(status.CaptureState());
            }
            return state;
        }

        public void RestoreState(object state)
        {
            List<object> stateList = state as List<object>;

            if (stateList == null)
                return;

            statuses.Clear();

            foreach (object objectState in stateList)
            {
                statuses.Add(new QuestStatus(objectState));
                
            }
        }


    }



}
