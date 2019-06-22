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
    unsafe class Knight_Framework_Character_CharacterControllerContainer_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(Knight.Framework.Character.CharacterControllerContainer);
            args = new Type[]{typeof(System.Action<System.String>)};
            method = type.GetMethod("BindAnimaCbAction", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, BindAnimaCbAction_0);

            field = type.GetField("CharacterControllerClass", flag);
            app.RegisterCLRFieldGetter(field, get_CharacterControllerClass_0);
            app.RegisterCLRFieldSetter(field, set_CharacterControllerClass_0);


        }


        static StackObject* BindAnimaCbAction_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Action<System.String> @action = (System.Action<System.String>)typeof(System.Action<System.String>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            Knight.Framework.Character.CharacterControllerContainer instance_of_this_method = (Knight.Framework.Character.CharacterControllerContainer)typeof(Knight.Framework.Character.CharacterControllerContainer).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.BindAnimaCbAction(@action);

            return __ret;
        }


        static object get_CharacterControllerClass_0(ref object o)
        {
            return ((Knight.Framework.Character.CharacterControllerContainer)o).CharacterControllerClass;
        }
        static void set_CharacterControllerClass_0(ref object o, object v)
        {
            ((Knight.Framework.Character.CharacterControllerContainer)o).CharacterControllerClass = (System.String)v;
        }


    }
}
