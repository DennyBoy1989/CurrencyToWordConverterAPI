using Domain.Methods.Primitives;
using System.Linq;

namespace Domain.Test.Methods.Primitives;

[TestFixture]
public class IEnumerableMethodsTest {

    [Test]
    public void OnIEnumerable_ElementAtOrDefault_WhenIEnumerbaleDoesContainValueAtIndexPosition_ThenReturnValueAtIndexPosition() {

        var digitList = new List<char>() { '1', '2', '3', '4', '5', '6' };


        var result = digitList.ElementAtOrDefault(0, 'x');
        Assert.That(result, Is.EqualTo('1'));
    }

    [Test]
    public void OnIEnumerable_ElementAtOrDefault_WhenIEnumerbaleDoesNotContainValueAtIndexPosition_ThenReturnGivenDefaultValue() {

        var digitList = new List<char>() { '1', '2', '3', '4', '5', '6' };


        var result = digitList.ElementAtOrDefault(6, 'x');
        Assert.That(result, Is.EqualTo('x'));
    }


    [Test]
    public void OnIEnumerable_ElementAtCountedBackwardsOrDefault_WhenIEnumerbaleDoesContainValueAtIndexPosition_ThenReturnValueAtIndexPosition() {

        var digitList = new List<char>() { '1', '2', '3', '4', '5', '6' };


        var result = digitList.ElementAtCountedBackwardsOrDefault(0, 'x');
        Assert.That(result, Is.EqualTo('6'));
    }

    [Test]
    public void OnIEnumerable_ElementAtCountedBackwardsOrDefault_WhenIEnumerbaleDoesNotContainValueAtIndexPosition_ThenReturnGivenDefaultValue() {

        var digitList = new List<char>() { '1', '2', '3', '4', '5', '6' };


        var result = digitList.ElementAtCountedBackwardsOrDefault(6, 'x');
        Assert.That(result, Is.EqualTo('x'));
    }

    [Test]
    public void OnIEnumerable_TakeCountedBackwards_WhenRangeIsInBoundariesOfIEnumberable_ThenReturnNewCollectionWithValuesOfRange() {

        var digitList = new List<char>() { '1', '2', '3', '4', '5', '6' };


        var result = digitList.TakeCountedBackwards(new Range(0,3));
        Assert.That(result, Is.EquivalentTo(new List<char>() { '4','5','6'}));
    }

    [Test]
    public void OnIEnumerable_TakeCountedBackwards_WhenRangeExceedsBoundariesOfIEnumberable_ThenReturnNewCollectionWithPartOfValuesThatAreInRange() {

        var digitList = new List<char>() { '1', '2', '3', '4', '5', '6' };


        var result = digitList.TakeCountedBackwards(new Range(2, 8));
        Assert.That(result, Is.EquivalentTo(new List<char>() { '1', '2', '3', '4' }));
    }

    [Test]
    public void OnIEnumerable_TakeCountedBackwards_WhenRangeIsCompletlyOutsideOfBoundariesOfIEnumberable_ThenReturnNewCollectionWithNoValues() {

        var digitList = new List<char>() { '1', '2', '3', '4', '5', '6' };


        var result = digitList.TakeCountedBackwards(new Range(6, 12));
        Assert.That(result, Is.EquivalentTo(new List<char>() { }));
    }
}
