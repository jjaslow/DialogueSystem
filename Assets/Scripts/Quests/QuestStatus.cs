using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.Quests
{
    public class QuestStatus
    {
        Quest quest;
        List<string> completedObjectives;

        public QuestStatus(Quest quest)
        {
            this.quest = quest;
            completedObjectives = new List<string>();
        }

        public Quest GetQuest()
        {
            return quest;

        }

        public IEnumerable<string> GetCompletedObjectives()
        {
            return completedObjectives;
        }
           

    }





}
