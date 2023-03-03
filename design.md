# Design
## Overview
This design document provides an overview of what is expected of the system. It is not a specification.
This system is based on games like Borderland's weapon systems that allow for building or generating weapons from a set of components that each add or subtract from the weapon's stats.
For example. the stock of a weapon can add or remove (if no stock) handling or accuracy.

## Requirements
ComposedWeapon should be able to compose a group of WeaponComponents and provide an interface for interacting with them.

## Stats
- Damage
    How much raw damage the weapon does.
- Range/Distance
    The effective range the weapon deals damage.
- Accuracy/Spread
    When the weapon is fired, how much the projectile deviates from the intended target.
- Fire Rate
    Rounds per minute
- Reload Time
    How long it takes to fully reload the weapon.
- Magazine Size
    How many rounds the weapon can hold in a single reload.
- Recoil/Stability/View Kick
    How much and in what way the weapon moves while shooting.
- Handling/Control
    How quickly the weapon can be aimed and fired.
- Mobility
    How much the weapon affects the player's movement speed.
- Stealth
    How much noise the weapon makes when fired.

## Modifiers
- [Critical Hit] Chance
    The chance that a shot will be a critical hit.
- 
    


## Components
### Required

#### Component: `barrel`
- There can be multiple barrels, but there must always be at least 1.
- With each additional barrel, the weapon could change how it fires
  - Burst fire
  - Spin-up like a minigun
  - Multiple projectiles (shotgun-style)
- Accuracy
- [?] Projectile speed
- Range

#### Component: `magazine`
- Ammo capacity
- Reload speed

#### Component: `optic`
- If there are multiple optics, they can be toggled between. This would mainly be used for switching between a scope and a sight.
- Possible abilities:
  - zoom
  - aim assist
  - weak spot
- Accuracy

#### Component: `grip`
- [?] Handling
- Stability
- Accuracy

#### Component: `body`
- Weight
- [?] Durability
- Mobility
- Fire rate
- Base Damage

### Optional

#### Component: `stock`
- Handling
- Stability
- Minor accuracy

#### Component: `Underbarrel`
- Provides auxiliary projectile
- Possible projectiles:
  - Explosive
  - Some others...

#### Component: `muzzle`
- Recoil
- Accuracy
- Noise