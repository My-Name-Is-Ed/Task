using UnityEngine;
using Test.ShipModules.Abstraction;

public class ButtonBuild : MonoBehaviour
{
    public ConstructorBlock ParentScript;

    public TypeModule Type;

    void Prepare(ConstructorBlock Script, TypeModule Type)
    {
        switch (Type)
        {
            case TypeModule.Corpus:
                Script.Build(Script.Corpus);
                return;

            case TypeModule.Engine:
                Script.Build(Script.Engine);
                return;

            case TypeModule.Battery:
                Script.Build(Script.Battery);
                return;

            case TypeModule.Storage:
                Script.Build(Script.Storage);
                return;

            case TypeModule.Cannon:
                Script.Build(Script.Cannon);
                return;

            case TypeModule.Collector:
                Script.Build(Script.Collector);
                return;

            case TypeModule.Converter:
                Script.Build(Script.Converter);
                return;

            case TypeModule.Generator:
                Script.Build(Script.Generator);
                return;

            case TypeModule.Repairer:
                Script.Build(Script.Repeirer);
                return;
            default:
                Script.Error();
                return;
        }
    }
    public void Build()
    {
        Prepare(ParentScript, Type);
    }
}