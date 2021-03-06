﻿using Ardalis.GuardClauses;

namespace CleanArch.Domain.Entities.OrderAggregation
{
    public class Address
    {
        public string Street { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public string Country { get; private set; }

        public string ZipCode { get; private set; }

        private Address() { }

        public Address(string street, string city, string state, string country, string zipcode)
        {
            Guard.Against.NullOrWhiteSpace(street, nameof(street));
            Guard.Against.NullOrWhiteSpace(city, nameof(city));
            Guard.Against.NullOrWhiteSpace(country, nameof(country));
            Guard.Against.NullOrWhiteSpace(zipcode, nameof(zipcode));

            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
        }
    }
}
