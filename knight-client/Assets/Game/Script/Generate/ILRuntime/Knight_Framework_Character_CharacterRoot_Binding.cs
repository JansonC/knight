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
    unsafe class Knight_Framework_Character_CharacterRoot_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(Knight.Framework.Character.CharacterRoot);
            args = new Type[]{};
            method = type.GetMethod("get_Instance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_Instance_0);

            field = type.GetField("KnightRoot", flag);
            app.RegisterCLRFieldGetter(field, get_KnightRoot_0);
            app.RegisterCLRFieldSetter(field, set_KnightRoot_0);
            field = type.GetField("MonsterRoot", flag);
            app.RegisterCLRFieldGetter(field, get_MonsterRoot_1);
            app.RegisterCLRFieldSetter(field, set_MonsterRoot_1);


        }


        static StackObject* get_Instance_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = Knight.Framework.Character.CharacterRoot.Instance;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


        static object get_KnightRoot_0(ref object o)
        {
            return ((Knight.Framework.Character.CharacterRoot)o).KnightRoot;
        }
        static void set_KnightRoot_0(ref object o, object v)
        {
            ((Knight.Framework.Character.CharacterRoot)o).KnightRoot = (UnityEngine.GameObject)v;
        }
        static object get_MonsterRoot_1(ref object o)
        {
            return ((Knight.Framework.Character.CharacterRoot)o).MonsterRoot;
        }
        static void set_MonsterRoot_1(ref object o, object v)
        {
            ((Knight.Framework.Character.CharacterRoot)o).MonsterRoot = (UnityEngine.GameObject)v;
        }


    }
}
