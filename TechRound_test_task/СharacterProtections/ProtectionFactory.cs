using System;

namespace TechRound_test_task
{
    public static class ProtectionFactory
    {
        public static Protection GetProtection(ProtectionEnum protection)
        {
            return protection switch
            {
                ProtectionEnum.BanditHelmet => new BanditHelmet(),
                ProtectionEnum.FalconClaw => new FalconClaw(),
                ProtectionEnum.LeatherArmor => new LeatherArmor(),
                ProtectionEnum.BagSeaSalt => new BagSeaSalt(),
                ProtectionEnum.HeavyArmor => new HeavyArmor(),
                ProtectionEnum.LathHelmet => new LathHelmet(),
                ProtectionEnum.MagicAmulet => new MagicAmulet(),
                ProtectionEnum.MagicArmor => new MagicArmor(),
                ProtectionEnum.MagicCap => new MagicСap(),
                _ => throw new ArgumentOutOfRangeException(nameof(protection), protection, null)
            };
        }
    }
}