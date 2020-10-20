using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Quests
{

    [CreateAssetMenu(fileName = "New Quest", menuName = "Quest", order = 1)]
    public class Quest : ScriptableObject
    {

        [SerializeField]
        string[] objectives;


        public string[] GetObjectives()
        {
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

    }



}

