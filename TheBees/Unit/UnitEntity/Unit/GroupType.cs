using System;

namespace TheBees.UnitData
{
    public enum PropertyType
    {

        TweakMotion = 10,
        Acceleration,
        SettingsFooterDamage,
        SupportGraphics,
        SupportGraphicsExt,
        ThrownOpponentSpec,
        AllCollision,
        Collision1,
        Collision2,
        ThrowCollision,
        CollisionThrown,
        AttackCollision,
        Collision3,
        AttackDetails,
        // additional property types
        MissileConfig,
        SAEffect,
        Pallet,
        EnemyCtrl,

        None

    }

    public enum ActionType
    {
        NormalOperation = 0,    // 0
        ClientBehavior1,        // 1
        ClientBehavior2,        // 2
        Throws,                 // 3
        ClientBehavior3,        // 4
        Tricks,                 // 5
        Mortals,                // 6
        LandingBehavior,        // 7
        SubroutineMortal,       // 8
        VictoryPose,            // 9
        None,
    }

    public static class GroupType
    {
        public const int PropertyStart = 10;
        public const int ActionStart = 0;

        public const int PropertyCount = 13;
        public const int ActionCount = 10;

    }
}
