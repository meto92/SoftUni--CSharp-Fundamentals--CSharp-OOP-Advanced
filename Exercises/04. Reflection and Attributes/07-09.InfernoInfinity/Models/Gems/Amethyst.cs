﻿public class Amethyst : Gem
{
    private const int AmethystStrength = 2;
    private const int AmethystAgility = 8;
    private const int AmethystVitality = 4;

    public Amethyst(GemClarityStatsBonus gemClarityStatsBonus)
        : base(AmethystStrength, AmethystAgility, AmethystVitality, gemClarityStatsBonus)
    { }
}