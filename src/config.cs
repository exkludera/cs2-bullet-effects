using CounterStrikeSharp.API.Core;

public class Config : BasePluginConfig
{
    public Tracer Tracer { get; set; } = new Tracer();
    public Impact Impact { get; set; } = new Impact();
    public HitEffect HitEffect { get; set; } = new HitEffect();
    public KillEffect KillEffect { get; set; } = new KillEffect();
}

public class Tracer
{
    public bool Enable { get; set; } = false;
    public string Permission { get; set; } = "";
    public string Team { get; set; } = "";
    public string Color { get; set; } = "random";
    public int Width { get; set; } = 1;
    public float Lifetime { get; set; } = 3;
}

public class Impact
{
    public bool Enable { get; set; } = false;
    public string File { get; set; } = "particles/ambient_fx/aircraft_navred.vpcf";
    public string Permission { get; set; } = "";
    public string Team { get; set; } = "";
    public string Color { get; set; } = "random";
    public int Width { get; set; } = 1;
    public float Lifetime { get; set; } = 3;
}

public class HitEffect
{
    public bool Enable { get; set; } = false;
    public string File { get; set; } = "particles/ambient_fx/ambient_sparks_glow.vpcf";
    public string Permission { get; set; } = "";
    public string Team { get; set; } = "";
    public float Height { get; set; } = 32;
    public string Sound { get; set; } = "";
}

public class KillEffect
{
    public bool Enable { get; set; } = false;
    public string File { get; set; } = "particles/explosions_fx/explosion_basic.vpcf";
    public string Permission { get; set; } = "";
    public string Team { get; set; } = "";
    public float Height { get; set; } = 0;
    public string Sound { get; set; } = "";
}