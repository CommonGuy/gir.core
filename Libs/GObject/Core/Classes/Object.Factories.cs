using System;

namespace GObject
{
    public partial class Object
    {
        protected IProperty<T> Property<T>(string name, Func<string, T> get, Action<T, string> set) => new GProperty<T>(this, name, get, set);
        protected ReadOnlyProperty<T> ReadOnlyProperty<T>(string name, Func<string, T> get) => new GReadOnlyProperty<T>(this, name, get);
        protected IProperty<T1> Property<T1, T2>(string name, Func<string, T2> get, Action<T2, string> set, System.Converter<T1, T2> to, System.Converter<T2, T1> from) => new GConvertingProperty<T1, T2>(this, name, get, set, to, from);

        protected IProperty<bool> PropertyOfBool(string name) => Property<bool>(name, GetBool, Set);
        protected IProperty<uint> PropertyOfUint(string name) => Property<uint>(name, GetUInt, Set);
        protected IProperty<string> PropertyOfString(string name) => Property<string>(name, GetStr, Set);
        protected IProperty<int> PropertyOfInt(string name) => Property<int>(name, GetInt, Set);
        protected ReadOnlyProperty<double> ReadOnlyPropertyOfDouble(string name) => ReadOnlyProperty<double>(name, GetDouble);
        protected ReadOnlyProperty<bool> ReadOnlyPropertyOfBool(string name) => ReadOnlyProperty<bool>(name, GetBool);
    }
}