# cs2-bullet-effects
**a plugin that creates effects on shooting & attacking**

<br>

<details>
	<summary>showcase</summary>
	<img src="https://github.com/user-attachments/assets/5f9d1be2-a02c-4b7a-b133-37bca2c1fb4b" width="400px"> <br>
	<img src="https://github.com/user-attachments/assets/6348e94b-3da2-49b9-bacf-c78a1d38c257" width="300px"> <br>
	<img src="https://github.com/user-attachments/assets/a168fa3a-410b-49ce-a36a-82ef43c1aead" width="300px"> <br>
	<img src="https://github.com/user-attachments/assets/ccc52017-fcea-4742-935b-64696e523e3c" width="300px"> <br>
</details>

<br>

## information:

### requirements
- [MetaMod](https://cs2.poggu.me/metamod/installation)
- [CounterStrikeSharp](https://github.com/roflmuffin/CounterStrikeSharp)

<br>

## example config

**Enable** - Default: `false` (option to disable per effect) <br>
**File**: - Default: `see examples below` (particle file to use on the effect) <br>
**Permission** - Default: `""` (empty for no check, @css/reservation for vip) <br>
**Team** - Default: `""` (T for Terrorist, CT for CounterTerrorist or empty for both) <br>

**Color** - Default: `"random"` (value is RGB (255 255 255)) <br>
**Width** - Default: `1` (set how wide the beam should be) <br>
**Lifetime** - Default: `3` (how many seconds the the effect should last) <br>
**Height** - Default: `0` (how many units to add on vitim AbsOrigin) <br>

```json
{
  "Tracer": {
    "Enable": true,
    "Color": "random",
    "Width": 1,
    "Lifetime": 3
  },
  "Impact": {
    "Enable": true,
    "File": "particles/ambient_fx/aircraft_navred.vpcf",
  },
  "HitEffect": {
    "Enable": true,
    "File": "particles/weapons/cs_weapon_fx/weapon_taser_glow.vpcf",
    "Height": 32
  },
  "KillEffect": {
    "Enable": true,
    "File": "particles/explosions_fx/explosion_basic.vpcf",
    "Permission": "",
    "Team": "",
    "Height": 0
  }
}
```

<br> <a href="https://ko-fi.com/exkludera" target="blank"><img src="https://cdn.ko-fi.com/cdn/kofi5.png" height="48px" alt="Buy Me a Coffee at ko-fi.com"></a>
