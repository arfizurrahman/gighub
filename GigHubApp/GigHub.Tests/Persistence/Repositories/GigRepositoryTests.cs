﻿using FluentAssertions;
using GigHub.Tests.Extensions;
using GigHubApp.Core.Models;
using GigHubApp.Persistence;
using GigHubApp.Persistence.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Data.Entity;

namespace GigHub.Tests.Persistence.Repositories
{
    [TestClass]
    public class GigRepositoryTests
    {
        private GigRepository _repository;
        private Mock<DbSet<Gig>> _mockGigs;
        private Mock<DbSet<Attendance>> _mockAttendances;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockGigs = new Mock<DbSet<Gig>>();
            _mockAttendances = new Mock<DbSet<Attendance>>();
            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(c => c.Gigs).Returns(_mockGigs.Object);
            mockContext.SetupGet(c => c.Attendances).Returns(_mockAttendances.Object);

            _repository = new GigRepository(mockContext.Object);
        }

        [TestMethod]
        public void GetUpcomingGigsByArtist_GigIsIntThePast_ShouldNoBeReturned()
        {
            var gig = new Gig() { DateTime = DateTime.Now.AddDays(-1), ArtistId = "1" };

            _mockGigs.SetSource(new[] { gig });

            var gigs = _repository.GetUpcomingGigsByArtist("1");

            gigs.Should().BeEmpty();
        }

        [TestMethod]
        public void GetUpcomingGigsByArtist_GigIsCanceled_ShouldNoBeReturned()
        {
            var gig = new Gig() { DateTime = DateTime.Now.AddDays(1), ArtistId = "1" };
            gig.Cancel();

            _mockGigs.SetSource(new[] { gig });

            var gigs = _repository.GetUpcomingGigsByArtist("1");

            gigs.Should().BeEmpty();
        }

        [TestMethod]
        public void GetUpcomingGigsByArtist_GigIsForADifferentArtist_ShouldNotBeReturned()
        {
            var gig = new Gig() { DateTime = DateTime.Now.AddDays(1), ArtistId = "1" };

            _mockGigs.SetSource(new[] { gig });

            var gigs = _repository.GetUpcomingGigsByArtist(gig.ArtistId + "-");

            gigs.Should().BeEmpty();
        }

        [TestMethod]
        public void GetUpcomingGigsByArtist_GigIsForTheGivenArtistAndIsInTheFuture_ShouldBeReturned()
        {
            var gig = new Gig() { DateTime = DateTime.Now.AddDays(1), ArtistId = "1" };

            _mockGigs.SetSource(new[] { gig });

            var gigs = _repository.GetUpcomingGigsByArtist("1");

            gigs.Should().Contain(gig);
        }

        [TestMethod]
        public void GetGigsUserAttending_AttendanceIsForADifferentUser_ShouldNotBeReturned()
        {
            var gig = new Gig() { DateTime = DateTime.Now.AddDays(1) };
            var attendance = new Attendance() { Gig = gig, AttendeeId = "1" };
            _mockAttendances.SetSource(new[] { attendance });

            var gigs = _repository.GetGigsUserAttending(attendance.AttendeeId + "-");

            gigs.Should().BeEmpty();
        }

        [TestMethod]
        public void GetGigsUserAttending_GigIsInThePast_ShouldNotBeReturned()
        {
            var gig = new Gig() { DateTime = DateTime.Now.AddDays(-1) };
            var attendance = new Attendance() { Gig = gig, AttendeeId = "1" };
            _mockAttendances.SetSource(new[] { attendance });

            var gigs = _repository.GetGigsUserAttending(attendance.AttendeeId);

            gigs.Should().BeEmpty();
        }

        [TestMethod]
        public void GetGigsUserAttending_UpComingGigsUserAttending_ShouldNotBeReturned()
        {
            var gig = new Gig() { DateTime = DateTime.Now.AddDays(1) };
            var attendance = new Attendance() { Gig = gig, AttendeeId = "1" };
            _mockAttendances.SetSource(new[] { attendance });

            var gigs = _repository.GetGigsUserAttending(attendance.AttendeeId);

            gigs.Should().Contain(gigs);
        }
    }
}
