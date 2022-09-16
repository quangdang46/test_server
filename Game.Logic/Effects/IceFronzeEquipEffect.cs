using Bussiness;
using Bussiness.Managers;
using Game.Logic.Actions;
using Game.Logic.Phy.Object;
using Game.Logic.Spells;

namespace Game.Logic.Effects
{
    public class IceFronzeEquipEffect : BasePlayerEffect
    {
        private int m_count = 0;

        private int m_probability = 0;

        public IceFronzeEquipEffect(int count, int probability)
			: base(eEffectType.IceFronzeEquipEffect)
        {
			m_count = count;
			m_probability = probability;
        }

        public override bool Start(Living living)
        {
			IceFronzeEquipEffect effect = living.EffectList.GetOfType(eEffectType.IceFronzeEquipEffect) as IceFronzeEquipEffect;
			if (effect != null)
			{
				effect.m_probability = ((m_probability > effect.m_probability) ? m_probability : effect.m_probability);
				return true;
			}
			return base.Start(living);
        }

        protected override void OnAttachedToPlayer(Player player)
        {
			player.PlayerShoot += ChangeProperty;
        }

        protected override void OnRemovedFromPlayer(Player player)
        {
			player.PlayerShoot -= ChangeProperty;
        }

        private void ChangeProperty(Player player)
        {
			if (!player.CurrentBall.IsSpecial() && rand.Next(100) < m_probability && player.AttackGemLimit == 0)
			{
				player.AttackGemLimit = 4;
				SpellMgr.ExecuteSpell(player.Game, player, ItemMgr.FindItemTemplate(10015));
				player.Game.SendEquipEffect(player, LanguageMgr.GetTranslation("AttackEffect.Success"));
				player.Game.AddAction(new LivingSayAction(player, LanguageMgr.GetTranslation("IceFronzeEquipEffect.msg"), 9, 0, 1000));
			}
        }
    }
}
