﻿using InsurSoft.Backend.Shared.Funcional;
using System;
using System.Collections.Generic;

namespace InsurSoft.Backend.Shared.Domain.Entities.Seguros
{
    public class NumeroApolice : ValueObject
    {
        public static readonly NumeroApolice Empty = new NumeroApolice(null);

        public string Numero { get; private set; }

        protected NumeroApolice(string numero)
        {
            Numero = numero;
        }

        public static Result<NumeroApolice> Create(Maybe<string> apoliceOrNothing)
        {
            return apoliceOrNothing
                .ToResult("O número de apólice não deve ser vazio.")
                .Ensure(apolice => !string.IsNullOrWhiteSpace(apolice), "O número de apólice não deve ser vazio.")
                .Ensure(apolice => apolice.Trim().Length > 3, "O número de apólice deve possuir no mínimo 3 caracteres.")
                .Map(apolice => new NumeroApolice(apolice));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Numero;
        }
    }
}