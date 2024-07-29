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

<a href='https://ko-fi.com/G2G2Y3Z9R' target='_blank'><img style='border:0px; height:75px;' src='https://storage.ko-fi.com/cdn/brandasset/kofi_s_tag_dark.png?_gl=1*6vhavf*_gcl_au*MTIwNjcwMzM4OC4xNzE1NzA0NjM5*_ga*NjE5MjYyMjkzLjE3MTU3MDQ2MTM.*_ga_M13FZ7VQ2C*MTcyMjIwMDA2NS4xNy4xLjE3MjIyMDA0MDUuNjAuMC4w' border='0' alt='Buy Me a Coffee at ko-fi.com' /></a>

<br>

## example config
```json
{
  "Tracer": {
    "Enable": true,
    "Permission": "",
    "Team": "",
    "Color": "random",
    "Width": 1,
    "Lifetime": 3
  },
  "Impact": {
    "Enable": true,
    "File": "particles/ambient_fx/aircraft_navred.vpcf",
    "Permission": "",
    "Team": ""
  },
  "HitEffect": {
    "Enable": true,
    "File": "particles/weapons/cs_weapon_fx/weapon_taser_glow.vpcf",
    "Permission": "",
    "Team": "",
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
