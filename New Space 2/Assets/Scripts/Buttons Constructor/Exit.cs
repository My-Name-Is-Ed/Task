using UnityEngine;
using UnityEngine.SceneManagement;
using Test;
using Test.ShipModules.Abstraction;

public class Exit : MonoBehaviour
{
    public void ExitToSpace()
    {
        bool Cannon = false;
        bool Storage = false;
        bool Baterry = false;
        bool Collector = false;
        bool Engine = false;

        foreach (BaseModule modules in Ship.Modules)
        {
            if (modules.Type == TypeModule.Cannon)
            {
                Cannon = true;
            }
            else if (modules.Type == TypeModule.Storage)
            {
                Storage = true;
            }
            else if (modules.Type == TypeModule.Battery)
            {
                Baterry = true;
            }
            else if (modules.Type == TypeModule.Collector)
            {
                Collector = true;
            }
            else if (modules.Type == TypeModule.Engine)
            {
                Engine = true;
            }
        }
        if (Engine && Storage && Baterry && Collector && Cannon)
        {
            SceneManager.LoadScene(1);
        }
        
    }
}
