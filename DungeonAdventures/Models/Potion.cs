using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventures.Models
{
    internal class Potion : Item
    {
        public PotionType Type { get; private set; }
        public int EffectAmount { get; set; }

        public Potion(PotionType type, int effectAmount, int buy, int sell)
        {
            Type = type;
            EffectAmount = effectAmount;
            ItemType = ItemType.Potion;
            Buy = buy;
            Sell = sell;
            SetNameAndDescription();
        }

        private void SetNameAndDescription()
        {
            if (Type == PotionType.Health)
            {
                Name = "Health Potion";
                Description = $"Heals {EffectAmount} hp";
            }
            else
            {
                Name = "Mana Potion";
                Description = $"Recovers {EffectAmount} manna";
            }
        }

        public void ApplyEffect(Player player)
        {
            //applied effect to player
            if (Type ==PotionType.Health)
            {
                player.Health += EffectAmount;
            }
            else
            {
                player.Mana += EffectAmount;
            }
        }

        public override bool Equals(object obj)
        {
            var potion = obj as Potion;
            if (potion == null)
            {
                return false;
            }
            else
            {
                return potion.Type == Type && potion.EffectAmount == EffectAmount;
            }
        }
    }
}
