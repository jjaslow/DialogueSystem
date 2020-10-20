﻿using GameDevTV.Core.UI.Tooltips;
using RPG.Quests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.UI.Quests
{
    public class QuestToolTipSpawner : TooltipSpawner
    {
        public override bool CanCreateTooltip()
        {
            return true;
        }

        public override void UpdateTooltip(GameObject tooltip)
        {
            tooltip.GetComponent<ObjectiveListUI>().Setup(status);

        }

        QuestStatus status;

        public void Setup(QuestStatus status)
        {
            this.status = status;
        }

    }



}