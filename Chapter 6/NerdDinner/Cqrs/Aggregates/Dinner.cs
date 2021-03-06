﻿using System;
using System.Collections.Generic;
using CommonDomain.Core;
using NerdDinner.Models;

namespace NerdDinner.Cqrs.Aggregates
{
    public class Dinner : AggregateBase
    {
        public Dinner()
        {
            
        }

        private Dinner(HostDinner command)
        {
            RaiseEvent(new DinnerCreated(command.Id, command.HostedBy, command.Title, command.EventDate,
                                         command.Description, command.ContactPhone, command.Address, command.Country));
        }

        public void Apply(DinnerCreated e)
        {
            Id = Guid.NewGuid();
        }

        public static Dinner HostDinner(HostDinner command)
        {
            return new Dinner(command);
        }
    }
}