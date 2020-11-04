using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    [System.Serializable]
    public class Condition
    {

        [SerializeReference]
        string predicate;
        [SerializeField]
        bool not = false;
        [SerializeField]
        string[] parameters;


        public bool Check(IEnumerable<IPredicateEvaluator> evaluators)
        {
            foreach (var evalator in evaluators)
            {
                bool? result = evalator.Evaluate(predicate, not, parameters);

                if (result == null)
                    continue;

                if (result == false)
                    return false;
            }

            return true;
        }

    }





}