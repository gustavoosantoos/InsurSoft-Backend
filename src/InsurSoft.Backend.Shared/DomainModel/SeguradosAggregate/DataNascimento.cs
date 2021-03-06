﻿using System;
using System.Collections.Generic;
using InsurSoft.Backend.Shared.Functional;

namespace InsurSoft.Backend.Shared.DomainModel.SeguradosAggregate
{
    public class DataNascimento : ValueObject
    {
        public static readonly DateTime DataMinimaNascimento = new DateTime(1900, 01, 01);

        public DateTime Data { get; set; }

        protected DataNascimento(DateTime data)
        {
            Data = data;
        }

        public static Result<DataNascimento> Create(Maybe<DateTime?> dataOrNothing)
        {
            return dataOrNothing
                .ToResult("A data de nascimento não deve ser vazia")
                .Ensure(data => data.HasValue && data.Value != default(DateTime),
                                "A data de nascimento não deve ser vazia")
                .Ensure(data => data.Value > DataMinimaNascimento,
                                $"A data de nascimento deve ser após {DataMinimaNascimento.ToString("d")}")
                .Ensure(data => data < DateTime.Today,
                                "A data de nascimento deve estar no passado")
                .Map(data => new DataNascimento(data.Value));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Data;
        }
    }
}
