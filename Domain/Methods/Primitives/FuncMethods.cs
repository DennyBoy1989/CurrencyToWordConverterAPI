namespace Domain.Methods.Primitives;

/// <summary>
/// Extensions methods for function objects.
/// </summary>
public static class FuncMethods {

    /// <summary>
    /// Calls a given function a returns its result. Usefull e.g. when you youse pattern matching, because you cannot insert a execution block inside a case.
    /// </summary>
    public static TRes Call<TRes>(Func<TRes> f) => f();
}
