using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntime.Reflection;
using ILRuntime.CLR.Utils;

namespace ILRuntime.Runtime.Generated
{
    unsafe class Knight_Framework_Character_CharacterAssetLoader_Binding_LoaderRequest_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(Knight.Framework.Character.CharacterAssetLoader.LoaderRequest);

            field = type.GetField("CharacterPrefabGo", flag);
            app.RegisterCLRFieldGetter(field, get_CharacterPrefabGo_0);
            app.RegisterCLRFieldSetter(field, set_CharacterPrefabGo_0);


        }



        static object get_CharacterPrefabGo_0(ref object o)
        {
            return ((Knight.Framework.Character.CharacterAssetLoader.LoaderRequest)o).CharacterPrefabGo;
        }
        static void set_CharacterPrefabGo_0(ref object o, object v)
        {
            ((Knight.Framework.Character.CharacterAssetLoader.LoaderRequest)o).CharacterPrefabGo = (UnityEngine.GameObject)v;
        }


    }
}
