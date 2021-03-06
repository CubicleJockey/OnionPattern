﻿using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace OnionPattern.Mapping.Tests
{
    [TestClass]
    public class MappingProfileInitializerTests
    {
        [TestMethod]
        public void MappingProfilesAreValid()
        {
            Mapper.Reset();

            Action method = MappingProfileInitializer.ConfigureMappings;
            method.Should().NotThrow();
        }
    }
}
