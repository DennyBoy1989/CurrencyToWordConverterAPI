namespace Domain.Methods.Primitives;

public static class FuncMethods {

    /// <summary>
    /// Calls a given function a returns its result. Usefull e.g. when you youse pattern matching, because you cannot insert a execution block inside a case.
    /// </summary>
    public static TRes Call<TRes>(this Func<TRes> f) => f();
}
