using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Utils;
using System.Drawing;
using static CounterStrikeSharp.API.Core.Listeners;

namespace BulletEffects;

public partial class Plugin : BasePlugin, IPluginConfig<Config>
{
    public override string ModuleName => "Bullet Effects";
    public override string ModuleVersion => "1.0.0";
    public override string ModuleAuthor => "exkludera";

    public override void Load(bool hotReload)
    {
        RegisterEventHandler<EventBulletImpact>(BulletImpact);
        RegisterListener<OnServerPrecacheResources>(OnServerPrecacheResources);

    }
    public override void Unload(bool hotReload)
    {
        RemoveListener<OnServerPrecacheResources>(OnServerPrecacheResources);
    }

    public Config Config { get; set; } = new Config();
    public void OnConfigParsed(Config config)
    {
        Config = config;
    }

    public void OnServerPrecacheResources(ResourceManifest manifest)
    {
        PrecacheResource(manifest, Config.Impact.File);
        PrecacheResource(manifest, Config.HitEffect.File);
        PrecacheResource(manifest, Config.KillEffect.File);
    }

    private void CreateEffect(string effectName, CCSPlayerController player, Vector Position, string effectFile, string colorValue = "", float width = 0, float lifetime = 1.0f)
    {
        switch (effectName.ToLower())
        {
            case "hiteffect":
                Position.Z += Config.HitEffect.Height;
                break;
            case "killeffect":
                Position.Z += Config.KillEffect.Height;
                break;
        }

        if (effectName == "tracer")
        {
            var tracer = Utilities.CreateEntityByName<CBeam>("env_beam")!;

            Color color = ParseColor(colorValue);
            tracer.Render = color;

            tracer.Width = width;
            tracer.DispatchSpawn();

            var AbsOrigin = GetEyePosition(player);
            tracer.Teleport(AbsOrigin);

            tracer.EndPos.X = Position.X;
            tracer.EndPos.Y = Position.Y;
            tracer.EndPos.Z = Position.Z;

            Utilities.SetStateChanged(tracer, "CBeam", "m_vecEndPos");

            AddTimer(lifetime, tracer.Remove);
        }
        else
        {
            var particle = Utilities.CreateEntityByName<CParticleSystem>("info_particle_system")!;

            particle.EffectName = effectFile;
            particle.DispatchSpawn();
            particle.AcceptInput("Start");

            Vector bulletDestination = new Vector(Position.X, Position.Y, Position.Z);
            particle.Teleport(bulletDestination);

            AddTimer(1.0f, particle.Remove);
        }
    }

    public HookResult BulletImpact(EventBulletImpact @event, GameEventInfo info)
    {
        var player = @event.Userid;

        if (player == null)
            return HookResult.Continue;

        Vector EndPos = new Vector(@event.X, @event.Y, @event.Z);

        if (Config.Tracer.Enable && HasPermission(player, "tracer"))
            CreateEffect("tracer", player, EndPos, "", Config.Tracer.Color, Config.Tracer.Width, Config.Tracer.Lifetime);

        if (Config.Impact.Enable && HasPermission(player, "impact"))
            CreateEffect("impact", player, EndPos, Config.Impact.File);

        return HookResult.Continue;
    }

    [GameEventHandler]
    public HookResult PlayerHurt(EventPlayerHurt @event, GameEventInfo info)
    {
        if (@event.Userid == null || @event.Attacker == null)
            return HookResult.Continue;

        if (Config.HitEffect.Enable && HasPermission(@event.Attacker, "hiteffect"))
            CreateEffect("hiteffect", @event.Attacker, @event.Userid.PlayerPawn.Value!.AbsOrigin!, Config.HitEffect.File);

        return HookResult.Continue;
    }

    [GameEventHandler]
    public HookResult PlayerDeath(EventPlayerDeath @event, GameEventInfo info)
    {
        if (@event.Userid == null || @event.Attacker == null)
            return HookResult.Continue;

        if (Config.KillEffect.Enable && HasPermission(@event.Attacker, "killeffect"))
            CreateEffect("killeffect", @event.Attacker, @event.Userid.PlayerPawn.Value!.AbsOrigin!, Config.KillEffect.File);

        return HookResult.Continue;
    }
}