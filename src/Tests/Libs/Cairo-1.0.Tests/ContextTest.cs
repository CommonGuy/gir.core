﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cairo.Tests
{
    [TestClass, TestCategory("IntegrationTest")]
    public class ContextTest : Test
    {
        [TestMethod]
        public void BindingsShouldSucceed()
        {
            var surf = new ImageSurface(Format.Argb32, 400, 300);
            var cr = new Context(surf);
            cr.Status.Should().Be(Status.Success);
            cr.GetTarget().Status.Should().Be(Status.Success);

            cr.Save();
            cr.Restore();

            cr.PushGroup();
            var pattern = cr.PopGroup();
            pattern.Should().NotBeNull();
            cr.SetSource(pattern);
            cr.PushGroupWithContent(Content.Alpha);
            cr.PopGroupToSource();
            cr.GetGroupTarget().Status.Should().Be(Status.Success);

            cr.SetSourceRgb(0.1, 0.2, 0.3);
            cr.SetSourceRgba(0.1, 0.2, 0.3, 0.4);
            cr.SetSourceSurface(new ImageSurface(Format.Argb32, 16, 16), 0, 0);
            cr.GetSource().Should().NotBeNull();

            cr.Antialias = Antialias.Gray;
            cr.Antialias.Should().Be(Antialias.Gray);

            cr.FillRule = FillRule.EvenOdd;
            cr.FillRule.Should().Be(FillRule.EvenOdd);

            cr.LineCap = LineCap.Round;
            cr.LineCap.Should().Be(LineCap.Round);

            cr.LineJoin = LineJoin.Bevel;
            cr.LineJoin.Should().Be(LineJoin.Bevel);

            cr.LineWidth = 42;
            cr.LineWidth.Should().Be(42);

            cr.MiterLimit = 2.4;
            cr.MiterLimit.Should().Be(2.4);

            cr.Operator = Operator.Atop;
            cr.Operator.Should().Be(Operator.Atop);

            cr.Tolerance = 3.4;
            cr.Tolerance.Should().Be(3.4);

            cr.SetDash(new double[] { 1, 2, 1, 4 }, 0.2);
            cr.Status.Should().Be(Status.Success);
            cr.DashCount.Should().Be(4);

            cr.GetDash(out var dash_pattern, out var dash_offset);
            dash_pattern.Should().BeEquivalentTo(new double[] { 1, 2, 1, 4 });
            dash_offset.Should().Be(0.2);
        }
    }
}
