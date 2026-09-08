# Horde Protocol — GDD one-pager

> **Teaching vehicle** · Unity 3/4 · weeks **6–17** · pair remote `…-horde-protocol`
> Not a commercial pitch. Not the yearly Skyro project. Skin (art, names, juice) is free — **pillars and scope are not**.

**Logline:** Last operator in a failing containment protocol. Waves escalate. Data drives enemies. You die. Retry.

---

## Fantasy

You are in the protocol arena. Entities push in from outside. Between waves you sell salvage for loadout. The protocol remembers nothing — a run is self-contained. You improve, not a save file.

One sentence for the player: *I survive one more wave, buy one thing, die, and try it cleaner.*

---

## Core loop

```
Start run → wave → loot/salvage → 3-card upgrade → harder wave → HP 0 → Game Over → retry from wave 1
```

No persistent meta tree. No open world. One arena.

---

## Pillars (3)

1. **Readable pressure.** You can say why you died. Waves are parseable, not visual noise.
2. **Data is content.** A new wave / enemy / loot item is a ScriptableObject, not a `Wave7Special` script.
3. **Density without melting the frame.** 200 enemies is a problem to solve (pool → profile → Jobs), not a reason to spawn 8.

---

## Locked (this *is* the game)

| | Decision |
|--|----------|
| View | **2D top-down**, orthographic camera, URP |
| Platform | Local Windows Player Build (lab PCs) |
| Players | **1** (co-op is Deep Run) |
| Input | Input System: move, aim, fire, pause. Dash = extra mile |
| Space | One bounded arena. Biome packs (w17) change look/enemy set, not a map campaign |
| Combat | Pooled projectiles + HP. Hitscan is extra mile, not instead of the pool |
| Enemy (slice) | At least **2 types** from data (fodder + something else: tank / shooter) |
| Waves | Numbered, budget from SO. Spawn from points in the arena |
| Between waves | Short shop: **1 of 3** upgrades from a loot table (SO) |
| Loss | HP 0 → Game Over state → retry |
| Win (slice) | Survive **3 data-driven waves** |
| Win (full Horde) | Protocol holds = wave **10** (further is extra mile, not required) |
| UI | HP, wave number, pause, game-over + retry, 3-card shop |

---

## Not this game

- Multiplayer, lobby, netcode
- 3D FPS / chase cam (that was year 2)
- Campaign, dialogue, quest log, persistent meta unlocks
- Open world, streaming maps, RPG inventory
- ECS / DOTS (week 30 = Deep Run side sample)
- A custom engine feature because you “want a shader / IK / voice”

A pair **must not** pull Deep Run systems into Horde (procgen dungeon, NGO, REST). Extra mile = juice, more SO types, clearer feedback — not a new genre.

---

## Ship bar

**Week 14 — vertical slice (graded):** start a run, pause, **3 waves from data**, **2 enemy types**, 1 upgrade between waves, death, retry. Demo ~3 min on a projector. PR merged on the pair `main`.

**Weeks 15–17 — harden, not a new genre:** perf disaster → Jobs/Burst on the hot loop → Addressable group (enemy or biome pack). The slice stays playable.

---

## What the year adds to the game (not the syllabus)

| Wk | Lands in the game |
|----|-------------------|
| 6 | Modules + asmdef + ADR — empty, but correct |
| 7 | Ability/enemy via AI charter (spec → review → PR) |
| 8 | State: run / pause / game-over; Command on input |
| 9 | Enemy + VFX pool; VContainer LifetimeScope |
| 10 | Wave / enemy / loot **ScriptableObjects** |
| 11 | Validator or spawn painter |
| 12 | Edit Mode + 1 Play Mode smoke (damage / wave budget) |
| 13 | CI multi-target build of the slice |
| 14 | Peer review + demo slice |
| 15–16 | Profile + Jobs until 200 enemies do not break the frame |
| 17 | Content pack as an Addressable group |

Weekly detail lives in the session kit. This GDD does not change when a kit sharpens a lab.

---

## Secondary

Same game, different angle: SO waves/loot, prefabs, naming, playtest checklist, a “bad config” the tool should catch. Not a shortened C# Primary.

---

## Production

- Repo: class `horde-protocol` → **1 remote / pair** (see class git policy)
- Toolchain: Unity **6.3 LTS** (`6000.3.10f1`) · URP · Input System · VContainer (w9) · UTF · Addressables (w17)
- Modules: Gameplay / Data / Presentation / Editor / Tests — Presentation may depend on Gameplay+Data; Gameplay **does not** pull Editor
- DoD = PR `week-XX-…` → pair `main`, not class `main`
