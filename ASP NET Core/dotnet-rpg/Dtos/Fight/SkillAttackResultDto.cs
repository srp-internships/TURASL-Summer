﻿namespace dotnet_rpg.Dtos.Fight
{
    public class SkillAttackResultDto
    {
        public string Attacker { get; set; } = string.Empty;
        public string Opponent { get; set; } = string.Empty;
        public int AttackerHP { get; set; }
        public int OpponentHP { get; set; }
        public int DamageDealt { get; set; }
    }
}
