﻿using FluentNHibernate.Mapping;

namespace OsteoYoga.Domain.Models.Mapping
{
    public class DurationMap : ClassMap<Duration>
    {
        public DurationMap()
        {
            Id(x => x.Id);

            Map(x => x.Value);
            References(x => x.PratictionerOffice).Cascade.SaveUpdate();

            Table("Duration");
        }
    }
}
