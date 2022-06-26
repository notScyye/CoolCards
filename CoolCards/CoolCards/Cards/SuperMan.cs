using ModdingUtils.Extensions;
using ModdingUtils.MonoBehaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace CoolCards.Cards
{
    class SuperMan : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            gun.timeBetweenBullets = 0.01f;
            gun.ammo = 145;
            gun.bursts = (int) 30.0f;
            gun.ammoReg = 45f;
            gun.bulletDamageMultiplier = 0.02f;
            gun.smartBounce = 100;
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
            InAirJumpEffect jumpEffect = player.gameObject.GetOrAddComponent<InAirJumpEffect>();
            jumpEffect.SetJumpMult(0.1f);
            jumpEffect.AddJumps(100);
            jumpEffect.SetCostPerJump(5);
            jumpEffect.SetContinuousTrigger(true);
            jumpEffect.SetResetOnWallGrab(false);
            jumpEffect.SetInterval(0.03f);
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
        }

        protected override string GetTitle()
        {
            return "Superman";
        }
        protected override string GetDescription()
        {
            return "Is it a bird? Is it a plane? NO! its a damn ROUNDS character.";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Rare;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Laser Vision",
                    amount = "Basically Gives You",
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Flight",
                    amount = "Basically Gives You",
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Laser Vision Cooldown",
                    amount = "VERY LONG",
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Damage",
                    simepleAmount = CardInfoStat.SimpleAmount.aLotLower
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.DefensiveBlue;
        }
        public override string GetModName()
        {
            return "CoolCards";
        }
    }
}
