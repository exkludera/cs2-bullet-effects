using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Admin;
using CounterStrikeSharp.API.Modules.Utils;
using System.Drawing;

namespace BulletEffects;

public partial class Plugin : BasePlugin, IPluginConfig<Config>
{
    private bool HasPermission(CCSPlayerController player, string id)
    {
        string permission = string.Empty;
        string team = string.Empty;

        switch (id)
        {
            case "tracer":
                permission = Config.Tracer.Permission;
                team = Config.Tracer.Team;
                break;
            case "impact":
                permission = Config.Impact.Permission;
                team = Config.Impact.Team;
                break;
            case "hiteffect":
                permission = Config.HitEffect.Permission;
                team = Config.HitEffect.Team;
                break;
            case "killeffect":
                permission = Config.KillEffect.Permission;
                team = Config.KillEffect.Team;
                break;
        }

        return (string.IsNullOrEmpty(permission) || AdminManager.PlayerHasPermissions(player, permission)) &&
               isTeamValid(player, team);
    }

    public bool isTeamValid(CCSPlayerController player, string team)
    {
        return (team == "t" || team == "terrorist") && player.Team == CsTeam.Terrorist ||
               (team == "ct" || team == "counterterrorist") && player.Team == CsTeam.CounterTerrorist ||
               string.IsNullOrEmpty(team) || team == "both" || team == "all";
    }

    private void PrecacheResource(ResourceManifest manifest, string file)
    {
        if (!string.IsNullOrEmpty(file))
        {
            manifest.AddResource(file);
        }
    }

    public static Vector GetEyePosition(CCSPlayerController player)
    {
        Vector absorigin = player.PlayerPawn.Value!.AbsOrigin!;
        CPlayer_CameraServices camera = player.PlayerPawn.Value!.CameraServices!;

        return new Vector(absorigin.X, absorigin.Y, absorigin.Z + camera.OldPlayerViewOffsetZ);
    }

    public static QAngle GetNormalizedAngles(CCSPlayerController player)
    {
        QAngle AbsRotation = player.PlayerPawn.Value!.AbsRotation!;
        return new QAngle(
            AbsRotation.X,
            (float)Math.Round(AbsRotation.Y / 10.0) * 10,
            AbsRotation.Z
        );
    }

    private int colorIndex = 0;

    private Color ParseColor(string colorValue)
    {
        if (string.IsNullOrEmpty(colorValue) || colorValue.ToLower() == "random")
        {
            var color = rainbowColors[colorIndex];
            colorIndex = (colorIndex + 1) % rainbowColors.Length;
            return color;
        }
        var colorParts = colorValue.Split(' ');
        if (colorParts.Length == 3 &&
            int.TryParse(colorParts[0], out var r) &&
            int.TryParse(colorParts[1], out var g) &&
            int.TryParse(colorParts[2], out var b))
        {
            return Color.FromArgb(255, r, g, b);
        }
        return Color.FromArgb(255, 255, 255, 255);
    }

    Color[] rainbowColors = {
        Color.FromArgb(255, 255, 255, 255), // White
        Color.FromArgb(255, 255, 0, 0),     // Red
        Color.FromArgb(255, 255, 0, 255),   // Magenta
        Color.FromArgb(255, 255, 255, 0),   // Yellow
        Color.FromArgb(255, 0, 255, 0),     // Green
        Color.FromArgb(255, 0, 255, 255),   // Cyan
        Color.FromArgb(255, 0, 0, 255)      // Blue
    };
}