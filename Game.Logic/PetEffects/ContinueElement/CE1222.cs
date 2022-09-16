﻿using System;
using System.Collections.Generic;
using Game.Logic.Phy.Object;
using Bussiness;

namespace Game.Logic.PetEffects.ContinueElement
{
    public class CE1222 : BasePetEffect
    {
        private int m_type = 0;
        private int m_count = 0;
        private int m_probability = 0;
        private int m_delay = 0;
        private int m_coldDown = 0;
        private int m_currentId;
        private int m_added = 0;

        public CE1222(int count, int probability, int type, int skillId, int delay, string elementID)
            : base(ePetEffectType.CE1222, elementID)
        {
            m_count = count;
            m_coldDown = count;
            m_probability = probability == -1 ? 10000 : probability;
            m_type = type;
            m_delay = delay;
            m_currentId = skillId;
        }

        public override bool Start(Living living)
        {
            CE1222 effect = living.PetEffectList.GetOfType(ePetEffectType.CE1222) as CE1222;
            if (effect != null)
            {
                effect.m_probability = m_probability > effect.m_probability ? m_probability : effect.m_probability;
                return true;
            }
            else
            {
                return base.Start(living);
            }
        }

        protected override void OnAttachedToPlayer(Player player)
        {
            player.BeginSelfTurn += Player_BeginSelfTurn;
            player.SpeedMultX(0);
            //player.NoFly(true);
            player.Game.SendPlayerPicture(player, (int)BuffType.DoNotMove, false);
            player.PlayerClearBuffSkillPet += Player_PlayerClearBuffSkillPet;
        }

        private void Player_PlayerClearBuffSkillPet(Player player)
        {
            Stop();
        }

        protected override void OnRemovedFromPlayer(Player player)
        {
            player.SpeedMultX(3);
            //player.NoFly(false);
            player.Game.SendPetBuff(player, ElementInfo, false, 0);
            player.BeginSelfTurn -= Player_BeginSelfTurn;
            player.Game.SendPlayerPicture(player, (int)BuffType.DoNotMove, false);
        }
        private void Player_BeginSelfTurn(Living living)
        {
            m_count--;
            if (m_count < 0)
            {                
                Stop();
            }
        }
    }
}
