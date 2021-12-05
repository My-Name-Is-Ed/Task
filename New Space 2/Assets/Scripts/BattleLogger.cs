using System.IO;
using App = UnityEngine.Application;

public static class BattleLogger
{

    static string _writePath = "/log.txt";

    public static void LogPlayer(float damage, float strength)
    {
        Log($"Игрок наносит урон {damage}");
        Log($"Прочность противника{strength}");
    }

    public static void LogEnemy(float damage, float strength)
    {
        Log($"Враг наносит урон {damage},");
        Log($"Прочность игрока{strength}");
    }

    public static void Log(string log)
    {
        using var sw = new StreamWriter(App.dataPath + _writePath, true);
        sw.WriteLine(log);
    }
}
