using System.Reflection;

namespace DelegateDemo
{
    //1. delegate declaration should be same as that of the method signature
    //signature: 
    //a. number of arguments
    //b. data type of arguments
    //c. order of the arguments
    //d. return type
    //using a delegate you can method(s) matching to the delegate
    delegate string FacilityInvoker(int x);

    class FacilityInvoker1 //:MulticastDelegate:Delegate:Object
    {
        private Object _target;
        private MethodInfo _method;

        public Object Target { get => _target; }
        public MethodInfo Method { get => _method; }

        public FacilityInvoker1(object target, MethodInfo method)
        {
            this._target = target;
            this._method = method;
        }
        public string Invoke(int x)
        {
            if (_target == null)
                return (string)_method.Invoke(null, new object[] { x });
            else
                return (string)_method.Invoke(_target, new object[] { x });
        }
    }
}
