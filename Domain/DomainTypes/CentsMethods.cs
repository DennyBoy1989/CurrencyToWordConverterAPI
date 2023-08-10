﻿namespace Domain.DomainTypes;

public static class CentsMethods {

    public static string GetWordRepresentationOfCents(this Cents cents) {

        string hundredsNumber = cents.Value.GetWordRepresentationOfDigitOfTensAndDigitOfUnits();
        if (cents.Value.IntValue == 1) {
            return $"{hundredsNumber} cent";
        }
        return $"{hundredsNumber} cents";
    }
}