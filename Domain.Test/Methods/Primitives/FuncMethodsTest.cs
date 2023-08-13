using Domain.Methods.Primitives;

namespace Domain.Test.Methods.Primitives;

[TestFixture]
public class FuncMethodsTest {

    [Test]
    public void OnFunc_Call_ThenReturnResultOfFunc() {

        var result = FuncMethods.Call(() => 1);
        Assert.That(result, Is.EqualTo(1));
    }
}
