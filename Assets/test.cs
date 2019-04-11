using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;
using UnityEngine.UI;
using System.IO;
using MoonSharp.Interpreter.Loaders;
using MoonSharp.VsCodeDebugger;
using System;
using MoonSharp.Interpreter.Serialization;

public class test : MonoBehaviour
{
    [SerializeField]
    private GameObject testobj;

    private DynValue maker;
    private object rotator;
    private Script script = new Script();

    // Start is called before the first frame update
    void Start()
    {
       //MoonSharp.Interpreter.UserData.RegisterType(typeof(GameObject), MoonSharp.Interpreter.InteropAccessMode.Preoptimized, "GameObjectMS");
        //MoonSharp.Interpreter.UserData.RegisterType(typeof(Transform), MoonSharp.Interpreter.InteropAccessMode.Preoptimized, "TransformMS");

        //Table dump = UserData.GetDescriptionOfRegisteredTypes(true);
        //File.WriteAllText(@"e:\projects\tamashi\moonsharp\moonsharp\Assets\Resources\Scripts\testdump.lua", SerializationExtensions.Serialize(dump));

        HardWired.Initialize();
        //Transform.Initialize();
        script.Options.ScriptLoader = new UnityAssetsScriptLoader("Scripts");
        var dv = script.DoFile("test_script_1");
        maker = script.Call(dv.Table["make"], testobj, 10);
        rotator = maker.Table["rotate"];
    }

    // Update is called once per frame
    void Update()
    {
        script.Call(rotator, maker, Time.deltaTime);
    }
}
