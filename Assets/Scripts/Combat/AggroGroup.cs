using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

namespace RPG.Combat
{
    public class AggroGroup : MonoBehaviour
    {
        [SerializeField]
        Fighter[] fighters;

        [SerializeField]
        bool activateOnStart = false;

        private void Start()
        {
            Activate(activateOnStart);
        }

        public void Activate(bool shouldActivate)
        {
            foreach (Fighter f in fighters)
            {
                f.enabled = shouldActivate;

                CombatTarget target = f.GetComponent<CombatTarget>();
                if(target != null)
                    target.enabled = shouldActivate;
            }
                
        }

    }
}





