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
    unsafe class Knight_Framework_Stage_StageControllerContainer_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(Knight.Framework.Stage.StageControllerContainer);

            field = type.GetField("StageControllerClass", flag);
            app.RegisterCLRFieldGetter(field, get_StageControllerClass_0);
            app.RegisterCLRFieldSetter(field, set_StageControllerClass_0);


        }



        static object get_StageControllerClass_0(ref object o)
        {
            return ((Knight.Framework.Stage.StageControllerContainer)o).StageControllerClass;
        }
        static void set_StageControllerClass_0(ref object o, object v)
        {
            ((Knight.Framework.Stage.StageControllerContainer)o).StageControllerClass = (System.String)v;
        }


    }
}
