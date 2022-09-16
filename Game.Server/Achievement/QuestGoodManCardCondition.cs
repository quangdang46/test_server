using Game.Server.Quests;

namespace Game.Server.Achievement
{
    internal class QuestGoodManCardCondition : BaseUserRecord
    {
        public QuestGoodManCardCondition(GamePlayer player, int type)
			: base(player, type)
        {
			AddTrigger(player);
        }

        public override void AddTrigger(GamePlayer player)
        {
			player.PlayerQuestFinish += player_PlayerQuestFinish;
        }

        private void player_PlayerQuestFinish(BaseQuest baseQuest)
        {
			if (baseQuest.Info.ID == 86)
			{
				m_player.AchievementInventory.UpdateUserAchievement(m_type, 1);
			}
        }

        public override void RemoveTrigger(GamePlayer player)
        {
			player.PlayerQuestFinish -= player_PlayerQuestFinish;
        }
    }
}
