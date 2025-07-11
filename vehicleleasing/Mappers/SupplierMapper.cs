using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vehicleleasing.Dtos.Supplier;
using vehicleleasing.Models;

namespace vehicleleasing.Mappers
{
    public static class SupplierMapper
    {
        public static SupplierDto ToSupplierDto(this Supplier supplier)
        {
            return new SupplierDto
            {
                Id = supplier.Id,
                name = supplier.name,
                contactPerson = supplier.contactPerson,
                email = supplier.email,
                contact = supplier.contact
            };
        }

          public static Supplier ToSupplierFromCreateDto(this CreateSupplierDto dto)
        {
            return new Supplier
            {
                name = dto.name,
                contactPerson = dto.contactPerson,
                email = dto.email,
                contact = dto.contact
            };
        }
    }
}