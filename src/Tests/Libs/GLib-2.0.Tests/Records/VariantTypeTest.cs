﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GLib.Tests;

[TestClass, TestCategory("UnitTest")]
public class VariantTypeTest : Test
{
    [DataTestMethod]
    [DataRow("s")]
    [DataRow("b")]
    [DataRow("y")]
    [DataRow("n")]
    [DataRow("q")]
    [DataRow("i")]
    [DataRow("u")]
    [DataRow("x")]
    [DataRow("t")]
    [DataRow("h")]
    [DataRow("t")]
    [DataRow("v")]
    public void CanCreateTypeFromString(string type)
    {
        var variantType = VariantType.New(type);

        variantType.ToString().Should().Be(type);
    }

    [TestMethod]
    public void TypeStringIsString()
    {
        VariantType.String.ToString().Should().Be("s");
    }

    [TestMethod]
    public void TypeVariantIsVariant()
    {
        VariantType.Variant.ToString().Should().Be("v");
    }
}
