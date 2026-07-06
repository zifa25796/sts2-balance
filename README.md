# STS2 Balance Mod

A Slay the Spire 2 balance modification mod that adjusts enemy stats for a more balanced experience, especially in multiplayer.

## Changes

### Multiplayer HP Scaling

| Act | Scaling Multiplier |
|-----|-------------------|
| Act 1 | 1.0x |
| Act 2 | 1.1x |
| Act 3 | 1.2x |

### Monster Adjustments

| Monster | Change |
|---------|--------|
| **Nibbit** | Butt damage: 12(13) → 9(10), Slice damage: 6(7) → 5(6) |
| **Shrinker Beetle** | HP: 38-40 (40-42) → 34-36 (36-38) |
| **Cubex Construct** | Repeater Blast strength gain: 2 → 1 |
| **Flyconid** | Frail Spores damage: 8(9) → 7(8), Smash damage: 11(12) → 10(11) |
| **Fogmog** | Swipe damage: 8(9) → 7(8), Headbutt damage: 14(16) → 13(15) |
| **Eye with Teeth** | HP: 6 → 5 |

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
