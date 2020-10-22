using GameDevTV.Inventories;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RPG.Quests
{

    [CreateAssetMenu(fileName = "New Quest", menuName = "Quest", order = 1)]
    public class Quest : ScriptableObject
    {
        [SerializeField] Objective[] objectives;
        [SerializeField] List<Reward> rewards = new List<Reward>();
        



        //if a sub class is private, public members are only visible in the parent class
        [System.Serializable]
        class Reward
        {
            public int number;
            public InventoryItem item;
        }

        [System.Serializable]
        public class Objective
        {
            public string reference;
            public string description;
        }


        public Objective[] GetObjectives()
        {
            //string[] result = new string[objectives.Length];

            //for(int x=0; x<objectives.Length; x++)
            //{
            //    result[x] = objectives[x].description;
            //}

            //return result;
            return objectives;
        }

        public string GetTitle()
        {
            return name;
        }

        public int GetObjectiveCount()
        {
            return objectives.Length;
        }





        public static Quest GetByName(string questName)
        {
            foreach(Quest quest in Resources.LoadAll<Quest>(""))
            {
                if (quest.name == questName)
                    return quest;
            }
            return null;
        }

    }



}

