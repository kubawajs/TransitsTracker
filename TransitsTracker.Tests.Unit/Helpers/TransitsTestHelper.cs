using System;
using System.Collections.Generic;
using System.Text;
using TransitsTracker.Core.Domain;

namespace TransitsTracker.Tests.Unit.Helpers
{
    public static class TransitsTestHelper
    {
        public static IEnumerable<Transit> GetTestTransits()
            => CreateTestTransitsSet();

        public static Transit GetTestTransit(int i)
            => CreateTestTransit(i);

        private static List<Transit> CreateTestTransitsSet()
        {
            var transits = new List<Transit>();
            for (int i = 1; i <= 10; i++)
            {
                transits.Add(CreateTestTransit(i));
            }
            return transits;
        }

        private static Transit CreateTestTransit(int i)
            => new Transit
            {
                Date = DateTime.UtcNow.AddDays(-i),
                Price = i * 25,
                DestinationAddress = new Address(String.Concat("Test", i.ToString()), String.Concat("Test", i + 10), i.ToString()),
                SourceAddress = new Address(String.Concat("Test", i + 20), String.Concat("Test", i + 30), (i + 1).ToString()),
            };
    }
}
