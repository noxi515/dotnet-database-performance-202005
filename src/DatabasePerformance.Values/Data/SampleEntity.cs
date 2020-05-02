using System;
using System.Collections.Generic;

namespace DatabasePerformance.Data
{
    public class SampleEntity
    {
        public static List<SampleEntity> CreateList(int count)
        {
            var list = new List<SampleEntity>(count);
            var date = new DateTime(2000, 1, 1, 0, 0, 0);
            for (var i = 0; i < count; i++)
            {
                list.Add(new SampleEntity
                {
                    Id = Guid.NewGuid(),
                    Name = $"This is name {i:D10}",
                    Age = count,
                    Date = date.AddDays(count)
                });
            }

            return list;
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public DateTime Date { get; set; }
    }
}