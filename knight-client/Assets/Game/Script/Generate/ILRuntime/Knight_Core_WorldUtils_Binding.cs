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
    unsafe class Knight_Core_WorldUtils_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(Knight.Core.WorldUtils);
            args = new Type[]{};
            method = type.GetMethod("GetScreenWidth", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetScreenWidth_0);
            args = new Type[]{};
            method = type.GetMethod("GetScreenHeight", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetScreenHeight_1);
            args = new Type[]{};
            method = type.GetMethod("GetScreenMaxRadio", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetScreenMaxRadio_2);
            args = new Type[]{};
            method = type.GetMethod("GetScreenMinRadio", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetScreenMinRadio_3);

            field = type.GetField("MaxScreenHeight", flag);
            app.RegisterCLRFieldGetter(field, get_MaxScreenHeight_0);
            app.RegisterCLRFieldSetter(field, set_MaxScreenHeight_0);
            field = type.GetField("GamePixelUnit", flag);
            app.RegisterCLRFieldGetter(field, get_GamePixelUnit_1);
            app.RegisterCLRFieldSetter(field, set_GamePixelUnit_1);


        }


        static StackObject* GetScreenWidth_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = Knight.Core.WorldUtils.GetScreenWidth();

            __ret->ObjectType = ObjectTypes.Float;
            *(float*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static StackObject* GetScreenHeight_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = Knight.Core.WorldUtils.GetScreenHeight();

            __ret->ObjectType = ObjectTypes.Float;
            *(float*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static StackObject* GetScreenMaxRadio_2(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = Knight.Core.WorldUtils.GetScreenMaxRadio();

            __ret->ObjectType = ObjectTypes.Float;
            *(float*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static StackObject* GetScreenMinRadio_3(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = Knight.Core.WorldUtils.GetScreenMinRadio();

            __ret->ObjectType = ObjectTypes.Float;
            *(float*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }


        static object get_MaxScreenHeight_0(ref object o)
        {
            return Knight.Core.WorldUtils.MaxScreenHeight;
        }
        static void set_MaxScreenHeight_0(ref object o, object v)
        {
            Knight.Core.WorldUtils.MaxScreenHeight = (System.Single)v;
        }
        static object get_GamePixelUnit_1(ref object o)
        {
            return Knight.Core.WorldUtils.GamePixelUnit;
        }
        static void set_GamePixelUnit_1(ref object o, object v)
        {
            Knight.Core.WorldUtils.GamePixelUnit = (System.Single)v;
        }


    }
}
