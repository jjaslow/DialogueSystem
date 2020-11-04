using GameDevTV.Saving;
using RPG.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;


namespace RPG.Quests
{
    public class QuestList : MonoBehaviour, ISaveable, IPredicateEvaluator
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

        public bool? Evaluate(string predicate, bool not, string[] parameters)
        {
            switch (predicate)
            {
                case "HasQuest":
                    return not ? !HasQuest(Quest.GetByName(parameters[0])) : HasQuest(Quest.GetByName(parameters[0]));
                case "CompletedQuest":
                    return not ? !QuestCompletedStatus(Quest.GetByName(parameters[0])) : QuestCompletedStatus(Quest.GetByName(parameters[0]));
            }

            return null;
        }

        private bool HasQuest(Quest quest)
        {
            foreach (var status in statuses)
            {
                if (quest.GetTitle() == status.GetQuestName())
                    return true;
            }
            return false;
        }

        private bool QuestCompletedStatus(Quest quest)
        {
            foreach (var status in statuses)
            {
                if (quest.GetTitle() == status.GetQuestName())
                    return status.GetCompletionStatus();
            }
            return false;
        }

    }



}
