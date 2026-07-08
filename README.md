# STS2 Balance Mod

A Slay the Spire 2 balance modification mod that adjusts enemy stats for a more balanced experience, especially in multiplayer.

## Changes

### Multiplayer HP Scaling

| Act | Scaling Multiplier |
|-----|-------------------|
| Act 1 | 1.0x |
| Act 2 | 1.1x |
| Act 3 | 1.2x |

### Monster Adjustments — Act 1

| Monster | Change |
|---------|--------|
| **Nibbit** | Butt damage: 12(13) → 9(10), Slice damage: 6(7) → 5(6) |
| **Shrinker Beetle** | HP: 38-40 (40-42) → 34-36 (36-38) |
| **Cubex Construct** | Repeater Blast strength gain: 2 → 1 |
| **Flyconid** | Frail Spores damage: 8(9) → 7(8), Smash damage: 11(12) → 10(11) |
| **Fogmog** | Swipe damage: 8(9) → 7(8), Headbutt damage: 14(16) → 13(15) |
| **Eye with Teeth** | HP: 6 → 5 |
| **Bygone Effigy** | HP: 130 (130) → 125 (130) |
| **Byrdonis** | Swoop damage: 18(20) → 16(18) |
| **Calcified Cultist** | Dark Strike damage: 10(11) → 8(10) |
| **Ceremonial Beast** | Plow damage: 19(21) → 17(19), Stomp: 16(18) → 14(16), Crush: 18(20) → 16(18), Crush Strength: 3 |
| **Fossil Stalker** | Tackle damage: 9(11) → 7(9) |
| **Gas Bomb** | HP: 6 (6) → 5 (6), Explode damage: 10(11) → 9(10) |
| **Gremlin Merc** | Double Smash: 6(7) → 5(6), Hehe: 7(8) → 6(7) |
| **Kin Follower** | HP: 54-55 (58-59) → lower |
| **Lagavulin Matriarch** | Slash: 20(22) → 18(20), Slash 2 damage/block: 13(15) → 11(13) |
| **Living Fog** | Advanced Gas: 7(8) → 6(7) |
| **Phantasmal Gardener** | HP: 28(30) → 26(28-29) |
| **Phrog Parasite** | HP: 56-59 (61-63) → lower |
| **Punch Construct** | Fast Punch: 5(6) → 4(5) |
| **Seapunk** | Bubble block: 6(7) → 5(6) |
| **Sewer Clam** | Jet damage: 7(8) → 6(7), Pressurize grants 6 Strength |
| **Skulking Colony** | Inertia Strength gain: 3(4) → 2(3), Piercing Stabs: 7(8) → 6(7) |
| **Slithering Strangler** | Thwack: 6(7) → 5(6), Lash: 11(12) → 10(11), Thwack blocks 4 |
| **Sludge Spinner** | Rage grants 3 Strength |
| **Soul Fysh** | HP: 216 (216) → 206 (216), Scream: 13(15) → 11(13), Gaze: 6(7) → 5(6) |
| **Terror Eel** | Crash: 17(19) → 15(17) |
| **Toadpole** | HP: 20-24 (20-24) → 19-23, Whirl: 7(8) → 6(7) |
| **Two-Tailed Rat** | HP: 18-21 → 17-20 |
| **Vantom** | HP: 168-168 (178-178) → 168 (178), Inky Lance: 6(7) → 5(6) |
| **Vine Shambler** | Chomp: 17(19) → 15(17) |
| **Waterfall Giant** | Stomp: 10(11) → 9(10), Ram: 15(16) → 14(15), Pressure Up: 12(13) → 11(12), Pressure Gun base: 18(20) → 15(18) |
| **Wriggler** | HP: 16-19 (17-20) → lower, Bite: 6(7) → 5(6) |

> Values in parentheses are Ascension levels (Deadly Enemies / Tough Enemies).

## Requirements

- Slay the Spire 2 (v0.107.0+)
- [BaseLib](https://github.com/STS2Modding/BaseLib) v3.3.2+

## Installation

1. Install [BaseLib](https://github.com/STS2Modding/BaseLib) mod
2. Place the `balance` folder into your `STS2_Data/Mods/` directory
3. Enable the mod in the in-game mod manager

## Build

```shell
dotnet build -c ExportRelease
```

The built mod will be output to `bin/ExportRelease/net9.0/`.
